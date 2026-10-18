
const MANAGED = "data-mbm-managed";
const HIDDEN = "data-mbm-hidden";
const OWNED = [MANAGED, HIDDEN, "data-mbm-highlight", "data-mbm-excluded"];
const VARIABLES = ["--mbm-left", "--mbm-top"];

export function attached(element) {
    if (!element) return false;
    if (typeof element.isConnected === "boolean") return element.isConnected;
    for (let current = element; current; current = current.parentNode)
        if (current === document || current === document.documentElement || current === document.body) return true;
    return false;
}

export function nearest(element, selector) {
    if (!element) return null;
    if (typeof element.closest === "function") return element.closest(selector);
    const matches = Array.from(document.querySelectorAll(selector));
    for (let current = element; current; current = current.parentElement)
        if (matches.indexOf(current) >= 0) return current;
    return null;
}

function computed(element) { return getComputedStyle(element) || {}; }

function contains(parent, child) {
    for (let current = child; current; current = current.parentElement) if (current === parent) return true;
    return false;
}

export function hash(value) {
    let result = 2166136261;
    for (let i = 0; i < value.length; i++) {
        result ^= value.charCodeAt(i);
        result = Math.imul(result, 16777619);
    }
    return (result >>> 0).toString(16).padStart(8, "0");
}

function classSignature(element) {
    return (element.getAttribute("class") || "").split(/\s+/)
        .filter(name => name && !/active|selected|disabled|hover|focus|pressed/i.test(name))
        // CSS module hashes can change between mod builds.
        .map(name => name.replace(/_[a-zA-Z0-9+/=-]{3,}$/, "")).sort().join(".");
}

export function buttonSignature(button, scope) {
    const parts = [scope.getAttribute("data-mbm-scope") || ""];
    let current = button;
    for (let i = 0; current && current !== scope && i < 5; i++, current = current.parentElement)
        parts.push(classSignature(current));
    const icons = Array.from(button.querySelectorAll("img, use, path, polygon, circle, rect"));
    for (const icon of icons) {
        parts.push(icon.tagName, icon.getAttribute("src")?.split("?")[0] || "",
            icon.getAttribute("href") || icon.getAttribute("xlink:href") || "",
            icon.getAttribute("d") || icon.getAttribute("points") || "",
            icon.getAttribute("cx") || "", icon.getAttribute("r") || "");
    }
    // Names are a last resort: avoid losing selections on a language change.
    if (!parts.slice(1).some(Boolean))
        parts.push(button.getAttribute("aria-label") || button.getAttribute("title") || button.textContent || "");
    return hash(parts.join("|"));
}

function visible(element) {
    if (!attached(element)) return false;
    const managed = nearest(element, `[${MANAGED}="true"]`);
    let belowManaged = !!managed;
    for (let current = element; current; current = current.parentElement) {
        const style = computed(current);
        if (current.hidden === true || style.display === "none" || style.opacity === "0" ||
            current.style?.display === "none" || current.style?.visibility === "hidden" ||
            (!belowManaged && (style.visibility === "hidden" || style.visibility === "collapse"))) return false;
        if (current === managed) belowManaged = false;
    }
    return true;
}

function carrierFor(button) {

    return button;
}

function inHookRange(element, scope) {

    let child = element;
    while (child && child.parentElement !== scope) child = child.parentElement;
    if (!child) return false;
    const name = scope.getAttribute("data-mbm-scope");
    for (let sibling = child.previousSibling; sibling; sibling = sibling.previousSibling) {
        if (sibling.getAttribute?.("data-mbm-end") === name) return false;
        if (sibling.getAttribute?.("data-mbm-start") === name) return true;
    }
    return false;
}

function trafficToolLaunchers(scope) {
    // TTE's FloatingButton is a div inside its direct Tooltip wrapper. Its
    // panels are siblings, and also contain images: never scan all clickable
    // divs or all icons in the mod root. Support both vanilla and fallback CSS.
    return Array.from(scope.querySelectorAll("#c2vm-tle > div > div > img"))
        .filter(icon => icon.parentElement.children.length === 1 &&
            icon.parentElement.parentElement.children.length === 1)
        .map(icon => icon.parentElement);
}

function eligible(button, scope, launcherRoot = null) {
    if (nearest(button, "[data-mbm-ui], [role=dialog], [role=menu], [role=listbox]")) return false;
    if (nearest(button.parentElement, "button, [role=button]")) return false;
    if (!visible(button)) return false;
    const rect = button.getBoundingClientRect();
    if (rect.width < 12 || rect.height < 12 || rect.width > 96 || rect.height > 96) return false;
    // GameTopLeft is also used for windows. Do not grab their action buttons.
    for (let parent = button.parentElement; parent && parent !== scope && parent !== launcherRoot; parent = parent.parentElement) {
        const bounds = parent.getBoundingClientRect();
        // Narrow vertical tool panels (for example Network Tools) are not
        // launchers either. Their controls must remain in the source panel.
        // Prefer leaving an ambiguous toolbar untouched to stealing its tools.
        if (bounds.height > 112 ||
            parent.querySelector("input, select, textarea, [role=slider]")) return false;
    }
    return true;
}

function positioningContext(carrier) {
    let block = null;
    for (let parent = carrier.parentElement; parent; parent = parent.parentElement) {
        const style = computed(parent);
        const transform = style.transform || "none";
        if (style.perspective && style.perspective !== "none") return null;
        if (transform !== "none") {
            const matrix = transform.match(/^matrix\(([^)]+)\)$/);
            if (matrix) {
                const m = matrix[1].split(/[,\s]+/).map(Number);
                if (m.length !== 6 || m.some(value => !Number.isFinite(value)) ||
                    Math.abs(m[1]) > 0.00001 || Math.abs(m[2]) > 0.00001 || m[0] <= 0 || m[3] <= 0) return null;
            } else if (!/^(?:(?:translate(?:X|Y)?|scale(?:X|Y)?)\([^)]*\)\s*)+$/.test(transform)) return null;
        }
        if (!block && (transform !== "none" || (style.filter && style.filter !== "none") ||
            /paint|layout|strict|content/.test(style.contain || "") ||
            /transform|perspective|filter/.test(style.willChange || ""))) block = parent;
    }
    if (!block) return { left: 0, top: 0, scaleX: 1, scaleY: 1 };
    const rect = block.getBoundingClientRect();
    const width = Number(block.offsetWidth);
    const height = Number(block.offsetHeight);
    if (!(width > 0 && height > 0)) return null;
    const scaleX = rect.width / width;
    const scaleY = rect.height / height;
    if (!(scaleX > 0 && scaleY > 0)) return null;
    return { left: rect.left + (Number(block.clientLeft) || 0) * scaleX,
        top: rect.top + (Number(block.clientTop) || 0) * scaleY, scaleX, scaleY };
}

function nameFor(button, generic, index) {
    const name = button.getAttribute("aria-label") || button.getAttribute("title") ||
        button.querySelector("img[alt]")?.getAttribute("alt") || button.textContent?.trim();
    if (name) return name.replace(/\s+/g, " ").slice(0, 100);
    const icon = button.querySelector("img[src]")?.getAttribute("src")?.split("/").pop()?.split(".")[0];
    const className = classSignature(button).split(".").find(part => !/^(button|launcher|icon)$/i.test(part));
    return `${generic} ${index + 1}${icon || className ? ` · ${icon || className}` : ""}`;
}

export function calculateLayout(anchor, count, direction, requestedRows, viewport, cell) {
    const gap = Math.max(4, cell * 0.12);
    const margin = gap;
    const screenColumns = Math.max(1, Math.floor((viewport.width - 2 * margin) / cell));
    const rows = Math.max(1, Math.min(requestedRows, Math.floor((viewport.height - 2 * margin) / cell)));
    let maximumColumns = screenColumns;
    let resolvedDirection = direction;
    if (direction === 1 || direction === 2) {
        const available = direction === 1 ? viewport.width - anchor.right - gap - margin : anchor.left - gap - margin;
        maximumColumns = Math.min(screenColumns, Math.floor(available / cell));
        if (maximumColumns < 1 || (count > maximumColumns * rows && count <= screenColumns * rows)) {
            resolvedDirection = 0;
            maximumColumns = screenColumns;
        }
    }
    const capacity = Math.max(1, maximumColumns * rows);
    const columns = Math.min(maximumColumns, Math.max(1, Math.ceil(Math.min(count, capacity) / rows)));
    const width = columns * cell;
    const height = Math.min(rows, Math.max(1, count)) * cell;
    let left = resolvedDirection === 1 ? anchor.right + gap :
        resolvedDirection === 2 ? anchor.left - gap - width : anchor.left;
    let top = resolvedDirection === 0 ? anchor.bottom + gap : anchor.top;
    if (top + height > viewport.height - margin && resolvedDirection === 0)
        top = anchor.top - gap - height;
    left = Math.max(margin, Math.min(left, viewport.width - width - margin));
    top = Math.max(margin, Math.min(top, viewport.height - height - margin));
    return { left, top, width, height, columns, rows, cell, capacity, pages: Math.max(1, Math.ceil(count / capacity)) };
}

export class DockController {
    constructor(anchor, config, onChange, generic, onInclude = () => {}) {
        this.anchor = anchor;
        this.config = config;
        this.onChange = onChange;
        this.generic = generic;
        this.onInclude = onInclude;
        this.owned = new Map();
        this.items = [];
        this.renderedItems = [];
        this.previews = new Map();
        this.open = false;
        this.page = 0;
        this.highlighted = null;
        this.snapshot = "";
        this.stopped = false;
        this.frame = 0;
        this.scopes = [];
        this.appliedStyles = new Map();
        this.pendingIncludes = new Map();
        this.settleFrames = 0;
        this.editEvent = event => {
            if (!this.config.selecting || !this.open) return;
            let item = this.renderedItems.find(item => item.supported && contains(item.carrier, event.target) &&
                item.carrier.getAttribute(MANAGED) === "true" && item.carrier.getAttribute(HIDDEN) !== "true");

            const tail = event.type !== "mousedown" && (event.button === 2 || event.type === "contextmenu");
            if (!item && tail && this.selectionGesture && Date.now() - this.selectionGesture.time < 1000 &&
                contains(this.selectionGesture.carrier, event.target))
                item = this.items.find(entry => entry.id === this.selectionGesture.id);
            if (!item) return;
            event.preventDefault();
            event.stopPropagation();
            event.stopImmediatePropagation?.();

            const rightDown = event.type === "mousedown" && (event.button === 2 || event.which === 3);
            const duplicateMenu = event.type === "contextmenu" && this.lastRightDown?.id === item.id &&
                Date.now() - this.lastRightDown.time < 1000;
            if (rightDown || (event.type === "contextmenu" && !duplicateMenu)) {
                if (rightDown) {
                    this.lastRightDown = { id: item.id, time: Date.now() };
                    this.selectionGesture = { id: item.id, carrier: item.carrier, time: Date.now() };
                }
                this.includeButton(item.id, this.config.excluded.split("|").indexOf(item.id) >= 0);
            }
        };
        this.editEvents = ["mousedown", "mouseup", "click", "dblclick", "contextmenu"];
        for (const event of this.editEvents) document.addEventListener(event, this.editEvent, true);
        this.request = () => {
            if (!this.frame && !this.stopped) this.frame = requestAnimationFrame(() => {
                this.frame = 0;
                this.refresh();
                if (this.settleFrames > 0) { this.settleFrames--; this.request(); }
            });
        };
        this.observer = typeof MutationObserver === "function" ? new MutationObserver(records => {
            if (records.some(record => {
                if (nearest(record.target, "[data-mbm-ui]")) return false;
                return record.type !== "attributes" || record.attributeName !== "style" ||
                    this.appliedStyles.get(record.target) !== record.target.getAttribute("style");
            })) this.settle();
        }) : null;
        this.timer = setInterval(this.request, 750);
        window.addEventListener("resize", this.request);
        this.refresh();
    }

    settle() {
        this.settleFrames = 2;
        this.request();
    }

    includeButton(id, include) {
        this.pendingIncludes.set(id, include);
        const excluded = new Set(this.config.excluded.split("|").filter(Boolean));
        if (include) excluded.delete(id); else excluded.add(id);
        this.config = { ...this.config, excluded: Array.from(excluded).join("|") };
        this.refresh();
        this.settle();
        this.onInclude(id, include);
    }

    update(config, open) {
        const excluded = new Set(config.excluded.split("|").filter(Boolean));
        for (const [id, include] of this.pendingIncludes) {
            if (excluded.has(id) === !include) this.pendingIncludes.delete(id);
            else if (include) excluded.delete(id); else excluded.add(id);
        }
        this.config = { ...config, excluded: Array.from(excluded).join("|") };
        this.open = open;
        this.refresh();
        this.settle();
    }

    changePage(delta) {
        this.page = Math.max(0, this.page + delta);
        this.refresh();
    }

    own(carrier) {
        if (this.owned.has(carrier)) return;
        this.owned.set(carrier, {
            attributes: OWNED.map(name => [name, carrier.getAttribute(name)]),
            variables: VARIABLES.map(name => [name, carrier.style.getPropertyValue(name), carrier.style.getPropertyPriority?.(name) || ""])
        });
    }

    restore(keep = null) {
        for (const [element, state] of this.owned) {
            if (keep?.has(element)) continue;
            for (const [name, value] of state.attributes) {
                if (value === null) element.removeAttribute(name); else element.setAttribute(name, value);
            }
            for (const [name, value, priority] of state.variables) {
                if (value) element.style.setProperty(name, value, priority); else element.style.removeProperty(name);
            }
            this.owned.delete(element);
        }
    }

    preview(item) {
        const markup = item.button.outerHTML;
        let preview = this.previews.get(item.id);
        if (!preview) {
            const carrier = document.createElement("div");
            carrier.setAttribute("data-mbm-ui", "true");
            carrier.setAttribute("data-mbm-preview", item.id);
            carrier.style.pointerEvents = "auto";
            carrier.style.display = "flex";
            carrier.style.alignItems = "center";
            carrier.style.justifyContent = "center";
            (nearest(this.anchor, "[data-mbm-ui]") || this.anchor.parentElement).appendChild(carrier);
            preview = { carrier, markup: null };
            this.previews.set(item.id, preview);
        }
        const rect = item.button.getBoundingClientRect();
        const context = positioningContext(preview.carrier) || { left: 0, top: 0, scaleX: 1, scaleY: 1 };
        preview.carrier.style.width = `${rect.width / context.scaleX}px`;
        preview.carrier.style.height = `${rect.height / context.scaleY}px`;
        if (preview.markup !== markup) {
            const copy = item.button.cloneNode(true);
            const originals = [item.button, ...Array.from(item.button.querySelectorAll("*"))];
            const copies = [copy, ...Array.from(copy.querySelectorAll("*"))];
            const ids = new Map();
            copies.forEach(node => {
                const id = node.getAttribute("id");
                if (id) ids.set(id, `mbm-preview-${item.id}-${id}`);
            });
            copies.forEach((node, index) => {
                for (const attribute of Array.from(node.attributes)) {
                    if (/^on/i.test(attribute.name) || attribute.name === "data-fixture" ||
                        attribute.name.startsWith("data-mbm-")) node.removeAttribute(attribute.name);
                    else {
                        let value = attribute.value;
                        if (attribute.name === "id") value = ids.get(value);
                        for (const [oldId, newId] of ids) {
                            if ((attribute.name === "href" || attribute.name === "xlink:href") && value === `#${oldId}`) value = `#${newId}`;
                            value = value.split(`url(#${oldId})`).join(`url(#${newId})`);
                        }
                        if (value !== attribute.value) node.setAttribute(attribute.name, value);
                    }
                }
                const style = computed(originals[index]);
                for (const property of ["width", "height", "color", "background-color", "background-image",
                    "padding-top", "padding-right", "padding-bottom", "padding-left",
                    "border-top-width", "border-right-width", "border-bottom-width", "border-left-width",
                    "border-top-style", "border-right-style", "border-bottom-style", "border-left-style",
                    "border-top-color", "border-right-color", "border-bottom-color", "border-left-color",
                    "border-top-left-radius", "border-top-right-radius", "border-bottom-right-radius", "border-bottom-left-radius",
                    "display", "align-items", "justify-content", "font-size", "font-family",
                    "fill", "stroke", "mask-image", "mask-size", "mask-position", "mask-repeat"]) {
                    const value = style.getPropertyValue(property);
                    if (value && value !== "auto" && value !== "initial") node.style.setProperty(property, value);
                }
                node.setAttribute("tabindex", "-1");
            });
            copy.style.position = "relative";
            copy.style.left = "auto";
            copy.style.top = "auto";
            copy.style.margin = "0";
            while (preview.carrier.firstChild) preview.carrier.removeChild(preview.carrier.firstChild);
            preview.carrier.appendChild(copy);
            preview.markup = markup;
            preview.button = copy;
        }
        return { ...item, carrier: preview.carrier, button: preview.button,
            context };
    }

    highlight(id, active) {
        this.highlighted = active ? id : null;
        const item = this.items.find(entry => entry.id === id);
        if (!attached(item?.carrier)) return;
        this.own(item.carrier);
        if (active) item.carrier.setAttribute("data-mbm-highlight", "true");
        else item.carrier.removeAttribute("data-mbm-highlight");
    }

    refresh() {
        if (this.stopped || !attached(this.anchor)) return;
        const previous = new Map(this.items.map(item => [item.button, item]));
        const items = [];
        const duplicates = new Map();
        const seen = new Set();
        let candidates = 0;
        const scopes = Array.from(document.querySelectorAll("[data-mbm-scope]"));
        if (scopes.length !== this.scopes.length || scopes.some((scope, i) => scope !== this.scopes[i])) {
            this.observer?.disconnect();
            for (const scope of scopes) this.observer?.observe(scope, { childList: true, subtree: true, attributes: true,
                attributeFilter: ["class", "style", "hidden", "aria-hidden"] });
            this.scopes = scopes;
        }
        for (const scope of scopes) {
            const target = scope.getAttribute("data-mbm-scope");
            if (this.config.source === "left" && target !== "GameTopLeft") continue;
            if (this.config.source === "right" && target !== "GameTopRight") continue;
            if (scope.getAttribute("data-mbm-scope") === "GameTopLeft" && !this.config.topLeft) continue;
            const trafficLaunchers = new Set(trafficToolLaunchers(scope));
            for (const button of [...Array.from(scope.querySelectorAll("button, [role=button]")), ...trafficLaunchers]) {
                candidates++;
                const launcherRoot = trafficLaunchers.has(button) ? nearest(button, "#c2vm-tle") : null;
                if (nearest(button, "[data-mbm-scope]") !== scope || !inHookRange(button, scope) || seen.has(button) || !eligible(button, scope, launcherRoot)) continue;
                seen.add(button);
                const signature = buttonSignature(button, scope);
                const occurrence = duplicates.get(signature) || 0;
                duplicates.set(signature, occurrence + 1);
                const old = previous.get(button);
                const carrier = carrierFor(button);
                const context = positioningContext(carrier);
                items.push({ id: old ? old.id : `${signature}-${occurrence}`, button, carrier,
                    context, name: nameFor(button, this.generic, items.length), supported: !!context });
            }
        }
        this.items = items;
        const excluded = new Set(this.config.excluded.split("|").filter(Boolean));
        const included = this.config.enabled ? items.filter(item => item.supported && !excluded.has(item.id)) : [];
        const highlighted = items.find(item => item.id === this.highlighted);
        // Excluded originals return to their native toolbar in both modes.
        this.restore(new Set([...included.map(item => item.carrier), ...Array.from(this.previews)
            .filter(([id]) => this.config.enabled && this.config.selecting && excluded.has(id))
            .map(([, preview]) => preview.carrier)]));
        const previewIds = new Set();
        const collected = this.config.enabled && this.config.selecting ? items.filter(item => item.supported).map(item => {
            if (!excluded.has(item.id)) return item;
            previewIds.add(item.id);
            return this.preview(item);
        }) : included;
        for (const [id, preview] of this.previews) {
            if (previewIds.has(id)) continue;
            preview.carrier.parentNode?.removeChild(preview.carrier);
            this.owned.delete(preview.carrier);
            this.previews.delete(id);
        }
        this.renderedItems = collected;
        const anchor = this.anchor.getBoundingClientRect();
        const scale = Math.max(0.5, anchor.width / 40);
        const maximumSize = collected.reduce((max, item) => {
            const rect = item.carrier.getBoundingClientRect();
            return Math.max(max, rect.width, rect.height);
        }, 40 * scale);
        const cell = maximumSize + 8 * scale;
        const viewport = { width: window.innerWidth, height: window.innerHeight };
        const layout = calculateLayout(anchor, collected.length, this.config.direction, this.config.rows, viewport, cell);
        this.page = Math.min(this.page, layout.pages - 1);
        const start = this.page * layout.capacity;
        collected.forEach((item, index) => {
            const local = index - start;
            const rect = item.carrier.getBoundingClientRect();
            this.own(item.carrier);
            item.carrier.setAttribute(MANAGED, "true");
            item.carrier.setAttribute(HIDDEN, String(!this.open || local < 0 || local >= layout.capacity));
            item.carrier.setAttribute("data-mbm-excluded", String(!!this.config.selecting && excluded.has(item.id)));
            const left = layout.left + (Math.max(0, local) % layout.columns) * cell + (cell - rect.width) / 2;
            const top = layout.top + Math.floor(Math.max(0, local) / layout.columns) * cell + (cell - rect.height) / 2;
            item.carrier.style.setProperty("--mbm-left", `${(left - item.context.left) / item.context.scaleX}px`);
            item.carrier.style.setProperty("--mbm-top", `${(top - item.context.top) / item.context.scaleY}px`);
        });
        if (highlighted) {
            this.own(highlighted.carrier);
            highlighted.carrier.setAttribute("data-mbm-highlight", "true");
        }
        const view = { items: items.map(({ id, name, supported }) => ({ id, name, supported })),
            excluded: this.config.excluded, count: included.length, page: this.page, pages: layout.pages,
            detection: { scopes: scopes.length, candidates, found: items.length,
                supported: items.filter(item => item.supported).length } };
        this.appliedStyles.clear();
        for (const carrier of this.owned.keys()) this.appliedStyles.set(carrier, carrier.getAttribute("style"));
        const snapshot = JSON.stringify(view);
        if (snapshot !== this.snapshot) { this.snapshot = snapshot; this.onChange(view); }
        const diagnostics = JSON.stringify(view.detection);
        if (diagnostics !== this.diagnostics) {
            this.diagnostics = diagnostics;
            console.log("[ModButtonManager] Detection " + (this.config.source || "all") + " " + diagnostics);
        }
    }

    stop() {
        this.stopped = true;
        clearInterval(this.timer);
        cancelAnimationFrame(this.frame);
        window.removeEventListener("resize", this.request);
        for (const event of this.editEvents) document.removeEventListener(event, this.editEvent, true);
        this.observer?.disconnect();
        for (const preview of this.previews.values()) {
            preview.carrier.parentNode?.removeChild(preview.carrier);
            this.owned.delete(preview.carrier);
        }
        this.previews.clear();
        this.restore();
        this.appliedStyles.clear();
        this.pendingIncludes.clear();
        this.renderedItems = [];
        this.items = [];
        this.scopes = [];
    }
}
