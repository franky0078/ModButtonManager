import { DockController, nearest } from "./dock.mjs";
console.log("[ModButtonManager] UI build: independent-docks-1");

// CS2's UI loader only requests the matching .css file for modules with this
// named export (the same contract used by CSSPresencePlugin in the other mods).
export const hasCSS = true;

const React = window.React;
const { createElement: h, useEffect, useLayoutEffect, useRef, useState } = React;
const { bindValue, useValue, trigger } = window["cs2/api"];
const { useLocalization } = window["cs2/l10n"];
const { Panel, Tooltip, Scrollable } = window["cs2/ui"];
const group = "modButtonManager";
const bindings = {
    enabled: bindValue(group, "enabled", false),
    grouping: bindValue(group, "grouping", 0),
    direction: bindValue(group, "direction", 0),
    leftDirection: bindValue(group, "leftDirection", 1),
    rightDirection: bindValue(group, "rightDirection", 2),
    locked: bindValue(group, "locked", false),
    editVisibility: bindValue(group, "editVisibility", false),
    rows: bindValue(group, "rows", 1),
    x: bindValue(group, "x", 840),
    y: bindValue(group, "y", 85),
    leftX: bindValue(group, "leftX", 10),
    leftY: bindValue(group, "leftY", 85),
    rightX: bindValue(group, "rightX", 960),
    rightY: bindValue(group, "rightY", 85),
    open: bindValue(group, "open", false),
    leftOpen: bindValue(group, "leftOpen", false),
    rightOpen: bindValue(group, "rightOpen", false),
    excluded: bindValue(group, "excluded", "")
};
let hookAvailable = false;

function useText() {
    const { translate } = useLocalization();
    return key => translate(`ModButtonManager.UI.${key}`) || key;
}

// Cohtml does not render native HTML checkbox inputs like a desktop browser.
// Use a semantic button and an explicit SVG checkmark, as a game UI control.
function Checkbox({ label, checked, disabled = false, onChange, className = "", ...events }) {
    return h("button", { ...events, type: "button", role: "checkbox", className: `mbm-check ${className}`,
        "aria-label": label, "aria-checked": checked, disabled,
        onClick: event => { event.stopPropagation(); if (!disabled) onChange(!checked); } },
        h("span", { className: "mbm-check-box", "aria-hidden": true }, checked &&
            h("svg", { viewBox: "0 0 20 20", width: 16, height: 16 },
                h("path", { d: "M4 10l4 4 8-10", fill: "none", stroke: "currentColor", strokeWidth: 2 }))),
        h("span", { className: "mbm-check-text" }, label));
}

function Manager() {
    const grouping = useValue(bindings.grouping);
    const [editor, setEditor] = useState(null);
    const selecting = useValue(bindings.editVisibility);
    const setSelection = value => trigger(group, "setOption", "editVisibility", String(!!value));
    useEffect(() => { setEditor(null); }, [grouping]);
    return h(React.Fragment, null, ...(grouping === 1 ? ["left", "right"] : ["all"]).map(side =>
        h(Dock, { key: side, side, grouping, editing: editor === side, selecting,
            setEditor, setSelection })));
}

function Dock({ side, grouping, editing, selecting, setEditor, setSelection }) {
    const t = useText();
    const enabled = useValue(bindings.enabled);
    const directionKey = side === "all" ? "direction" : `${side}Direction`;
    const direction = useValue(bindings[directionKey]);
    const locked = useValue(bindings.locked);
    const rows = Math.max(1, Math.min(3, useValue(bindings.rows)));
    const x = useValue(bindings[side === "all" ? "x" : `${side}X`]);
    const y = useValue(bindings[side === "all" ? "y" : `${side}Y`]);
    const openKey = side === "all" ? "open" : `${side}Open`;
    const savedOpen = useValue(bindings[openKey]);
    const excluded = useValue(bindings.excluded) || "";
    const anchor = useRef(null);
    const controller = useRef(null);
    const drag = useRef(null);
    const suppressClick = useRef(false);
    const lastRightDown = useRef(0);
    const [open, setOpen] = useState(savedOpen);
    const [position, setPosition] = useState({ x, y });
    const [viewport, setViewport] = useState({ width: window.innerWidth, height: window.innerHeight });
    const [view, setView] = useState({ items: [], count: 0, page: 0, pages: 1 });
    const currentPosition = useRef(position);
    currentPosition.current = position;
    const generic = t("Generic");
    const config = { enabled, direction, rows, topLeft: true, source: side, excluded, selecting };
    const currentConfig = useRef(config);
    currentConfig.current = config;

    useEffect(() => setPosition({ x, y }), [x, y]);
    useEffect(() => setOpen(savedOpen), [savedOpen]);
    useLayoutEffect(() => {
        const instance = new DockController(anchor.current, currentConfig.current, setView, generic,
            (id, include) => trigger(group, "include", id, include));
        controller.current = instance;
        return () => { instance.stop(); controller.current = null; };
    }, [generic, side]);
    useLayoutEffect(() => {
        controller.current?.update(config, open || editing || selecting);
    }, [enabled, direction, rows, excluded, selecting, open, editing, position.x, position.y, viewport, generic, side]);

    useEffect(() => {
        const move = event => {
            if (!drag.current || locked) return;
            const deltaX = event.clientX - drag.current.clientX;
            const deltaY = event.clientY - drag.current.clientY;
            if (Math.abs(deltaX) + Math.abs(deltaY) > 5) drag.current.moved = true;
            if (!drag.current.moved) return;
            suppressClick.current = true;
            const bounds = anchor.current.getBoundingClientRect();
            const left = Math.max(0, Math.min(window.innerWidth - bounds.width, drag.current.left + deltaX));
            const top = Math.max(0, Math.min(window.innerHeight - bounds.height, drag.current.top + deltaY));
            setPosition({ x: Math.round(left / window.innerWidth * 1000), y: Math.round(top / window.innerHeight * 1000) });
        };
        const stop = () => {
            if (!drag.current || locked) return;
            if (drag.current.moved) {
                const position = currentPosition.current;
                trigger(group, side === "all" ? "position" : side === "left" ? "positionLeft" : "positionRight", position.x, position.y);
            }
            drag.current = null;
        };
        const resize = () => setViewport({ width: window.innerWidth, height: window.innerHeight });
        const key = event => {
            if (event.key === "Escape" && (editing || selecting)) {
                setEditor(null);
            }
        };
        const outside = event => {
            if (event.button !== 0 || nearest(event.target, "[data-mbm-ui], [data-mbm-managed], .mbm-editor")) return;
            if (editing) setEditor(null);
        };
        window.addEventListener("mousemove", move);
        window.addEventListener("mouseup", stop);
        window.addEventListener("blur", stop);
        window.addEventListener("resize", resize);
        window.addEventListener("keydown", key);
        document.addEventListener("mousedown", outside, true);
        return () => {
            window.removeEventListener("mousemove", move);
            window.removeEventListener("mouseup", stop);
            window.removeEventListener("blur", stop);
            window.removeEventListener("resize", resize);
            window.removeEventListener("keydown", key);
            document.removeEventListener("mousedown", outside, true);
        };
    }, [editing, selecting, side, locked]);
    useEffect(() => { if (locked) { drag.current = null; setPosition({ x, y }); } }, [locked, x, y]);

    const setOption = (name, value) => trigger(group, "setOption", name, String(value));
    const changeOpen = value => { setOpen(value); setOption(openKey, value); };
    const check = (key, checked, change) => h(Checkbox, { label: t(key), checked, onChange: change });
    const choose = (key, value, values, optionKey = key.toLowerCase()) => h("div", { className: "mbm-option" },
        h("span", null, t(key)), h("div", { className: "mbm-choices" }, values.map(item =>
            h("button", { key: item.value, type: "button", className: value === item.value ? "mbm-selected" : "",
                "aria-pressed": value === item.value, onClick: () => setOption(optionKey, item.value) }, item.label))));
    const scale = anchor.current ? anchor.current.getBoundingClientRect().width / 40 || 1 : 1;
    const left = Math.max(0, Math.min(viewport.width - 40 * scale, position.x / 1000 * viewport.width));
    const top = Math.max(0, Math.min(viewport.height - 40 * scale, position.y / 1000 * viewport.height));
    const editorWidth = Math.min(370 * scale, viewport.width - 16 * scale);
    const editorLeft = Math.max(8 * scale, Math.min(left, viewport.width - editorWidth - 8 * scale));
    const editorTop = Math.max(8 * scale, Math.min(top + 52 * scale, viewport.height - 490 * scale));
    const excludedIds = new Set((view.excluded ?? excluded).split("|"));

    return h("div", { "data-mbm-ui": "true", className: "mbm-ui" },
        h(Tooltip, { tooltip: selecting ? t("SelectHint") : t("Toggle") }, h("button", {
            ref: anchor, type: "button", className: `mbm-launcher ${open || editing ? "mbm-selected" : ""} ${selecting ? "mbm-selecting" : ""}`,
            style: { left, top, position: "fixed", width: "40rem", height: "40rem" },
            "data-mbm-side": side,
            "aria-label": t(side === "all" ? "Title" : side === "left" ? "LeftLauncher" : "RightLauncher"), "aria-expanded": open || editing || selecting,
            onMouseDown: event => {
                event.stopPropagation();
                if (event.button === 2 || event.which === 3) {
                    event.preventDefault();
                    lastRightDown.current = Date.now();
                    setEditor(editing ? null : side);
                    return;
                }
                if (event.button !== 0 || locked) return;
                suppressClick.current = false;
                const rect = event.currentTarget.getBoundingClientRect();
                drag.current = { clientX: event.clientX, clientY: event.clientY, left: rect.left, top: rect.top, moved: false };
            },
            onClick: event => {
                event.stopPropagation();
                if (suppressClick.current) { suppressClick.current = false; return; }
                setEditor(null);
                changeOpen(!open);
            },
            onContextMenu: event => {
                event.preventDefault(); event.stopPropagation();
                if (Date.now() - lastRightDown.current > 1000) setEditor(editing ? null : side);
            }
        }, h("svg", { viewBox: "0 0 32 32", width: 28, height: 28,
            style: { width: "28rem", height: "28rem" }, "aria-hidden": true },
            [4, 13, 22].flatMap(x => [4, 13, 22].map(y => h("rect", { key: `${x}-${y}`, x, y, width: 6, height: 6, rx: 1, fill: "currentColor" })))),
            h("span", { className: "mbm-badge" }, view.count))),
        (open || editing || selecting) && view.pages > 1 && h("div", { className: "mbm-controls",
            style: { left: Math.max(0, Math.min(left, viewport.width - 100 * scale)), top: Math.max(0, top - 30 * scale) } },
                h("button", { type: "button", disabled: view.page === 0, "aria-label": t("Previous"),
                    onClick: () => controller.current?.changePage(-1) },
                    h("svg", { viewBox: "0 0 16 16", width: 16, height: 16 }, h("path", { d: "M10 3L5 8l5 5", fill: "none", stroke: "currentColor", strokeWidth: 2 }))),
                h("span", null, `${view.page + 1}/${view.pages}`),
                h("button", { type: "button", disabled: view.page + 1 >= view.pages, "aria-label": t("Next"),
                    onClick: () => controller.current?.changePage(1) },
                    h("svg", { viewBox: "0 0 16 16", width: 16, height: 16 }, h("path", { d: "M6 3l5 5-5 5", fill: "none", stroke: "currentColor", strokeWidth: 2 })))),
        editing && h(Panel, { className: "mbm-editor", header: t("Settings"), draggable: true,
            initialPosition: { x: editorLeft / viewport.width, y: editorTop / viewport.height },
            onClose: () => setEditor(null) },
            h("div", { className: "mbm-editor-body",
                onMouseDown: event => event.stopPropagation(), onClick: event => event.stopPropagation(),
                onWheel: event => event.stopPropagation() },
                check("Enabled", enabled, value => setOption("enabled", value)),
                check("Locked", locked, value => setOption("locked", value)),
                check("EditVisibility", selecting, value => setSelection(value)),
                choose("Grouping", grouping, [{ value: 0, label: t("Combined") }, { value: 1, label: t("Separate") }]),
                choose("Direction", direction, [0, 1, 2].map((value, index) => ({ value, label: t(["Below", "Right", "Left"][index]) })), directionKey),
                choose("Rows", rows, [1, 2, 3].map(value => ({ value, label: String(value) }))),
                h("button", { type: "button", className: "mbm-reset", onClick: () => {
                    setOption("enabled", true); changeOpen(true); setEditor(null); setSelection(!selecting);
                } }, t(selecting ? "FinishSelection" : "SelectButtons")),
                h("div", { className: "mbm-selection-title" }, `${t("Selection")} (${view.items.length})`),
                h("p", { className: "mbm-hint" }, t("SelectionHint")),
                !hookAvailable && h("p", { className: "mbm-hint" }, t("Unavailable")),
                view.items.length === 0 && h("p", { className: "mbm-hint" }, t("Empty")),
                h(Scrollable, { className: "mbm-list", vertical: true, horizontal: false, trackVisibility: "scrollable" }, view.items.map(item => h(Checkbox, {
                    key: item.id, className: `mbm-item ${item.supported ? "" : "mbm-unsupported"}`,
                    label: item.name, checked: item.supported && !excludedIds.has(item.id),
                    disabled: !item.supported || !selecting,
                    title: item.supported ? item.name : t("Unsupported"),
                    onMouseEnter: () => controller.current?.highlight(item.id, true),
                    onMouseLeave: () => controller.current?.highlight(item.id, false),
                    onChange: include => controller.current?.includeButton(item.id, include)
                }))),
                h("button", { type: "button", className: "mbm-reset", onClick: () => trigger(group, "reset") }, t("Reset")))));
}

// Extending the hook itself covers existing and later registrations. No
// interception of append(), no enumeration of private registry internals.
export default function register(registry) {
    const path = "game-ui/modding/modding-hook.tsx";
    try {
        if (typeof registry.get(path, "ModdingHook") !== "function") throw new Error("ModdingHook unavailable");
        registry.extend(path, "ModdingHook", Previous => function DockScope(props) {
            const start = useRef(null);
            const tracked = props.name === "GameTopRight" || props.name === "GameTopLeft";
            useLayoutEffect(() => {
                if (!tracked || !start.current?.parentElement) return;
                const parent = start.current.parentElement;
                const previous = parent.getAttribute("data-mbm-scope");
                parent.setAttribute("data-mbm-scope", props.name);
                return () => {
                    if (previous === null) parent.removeAttribute("data-mbm-scope");
                    else parent.setAttribute("data-mbm-scope", previous);
                };
            }, [tracked, props.name]);
            if (!tracked) return h(Previous, props);
            // Invisible range markers preserve the original flex parent, child
            // selectors and spacing. No wrapper remains when the dock is off.
            return h(React.Fragment, null,
                h("span", { ref: start, "data-mbm-start": props.name, style: { display: "none" } }),
                h(Previous, props),
                h("span", { "data-mbm-end": props.name, style: { display: "none" } }));
        });
        hookAvailable = true;
    } catch (error) {
        console.warn("[ModButtonManager] Shared mod UI hook unavailable; original buttons are unchanged.", error);
    }
    registry.append("Game", Manager);
}
