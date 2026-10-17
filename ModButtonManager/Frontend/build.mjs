import fs from "node:fs";
import path from "node:path";
import { fileURLToPath } from "node:url";

const root = path.dirname(fileURLToPath(import.meta.url));
const project = path.dirname(root);
const writeChanged = (file, content) => {
    if (!fs.existsSync(file) || fs.readFileSync(file, "utf8") !== content) fs.writeFileSync(file, content);
};
const version = fs.readFileSync(path.join(project, "Version.props"), "utf8").match(/<Version>(\d+\.\d+\.\d+)<\/Version>/)?.[1];
if (!version || version.split(".").some(part => Number(part) > 65534))
    throw new Error("Version.props must contain a numeric major.minor.patch version (0..65534 per part).");
for (const filename of ["mod.json", "package.json"]) {
    const file = path.join(root, filename);
    const content = fs.readFileSync(file, "utf8");
    if (typeof JSON.parse(content).version !== "string") throw new Error(`Missing version in ${filename}`);
    writeChanged(file, content.replace(/("version"\s*:\s*")[^"]*(")/, (_, start, end) => start + version + end));
}
const publishFile = path.join(project, "Properties/PublishConfiguration.xml");
writeChanged(publishFile, fs.readFileSync(publishFile, "utf8").replace(/<ModVersion Value="[^"]*"/, `<ModVersion Value="${version}"`));
const readmeFile = path.join(project, "../README.md");
writeChanged(readmeFile, fs.readFileSync(readmeFile, "utf8").replace(/^(# Mod Button Manager — )\S+/m, `$1${version}`));

// Localizations are maintained directly as C# source files.
const localeSource = fs.readFileSync(path.join(project, "Settings/Locale.cs"), "utf8");
const required = new Set();
for (const m of localeSource.matchAll(/Text\("([^"]*)"\)/g)) required.add(m[1]);
for (const m of localeSource.matchAll(/UI\(entries, "[^"]+", "([^"]*)"\)/g)) required.add(m[1]);
for (const m of localeSource.matchAll(/Option\(entries, nameof\(Setting\.\w+\),\s*"([^"]*)",\s*"([^"]*)"\)/g)) {
    required.add(m[1]); required.add(m[2]);
}
for (const code of ["EN", "DE", "FR", "IT", "ES"]) {
    const source = fs.readFileSync(path.join(project, `Localization/Locale${code}.cs`), "utf8");
    const texts = new Map([...source.matchAll(/\{\s*("(?:\\.|[^"\\])*")\s*,\s*("(?:\\.|[^"\\])*")\s*\}/g)]
        .map(m => [JSON.parse(m[1]), JSON.parse(m[2])]));
    if (texts.size !== required.size || [...required].some(key => typeof texts.get(key) !== "string" || !texts.get(key).trim()))
        throw new Error(`Incomplete translations: Locale${code}.cs. Update every text key from Settings/Locale.cs.`);
}
const metadata = JSON.parse(fs.readFileSync(path.join(root, "mod.json"), "utf8"));
const core = fs.readFileSync(path.join(root, "src/dock.mjs"), "utf8").replace(/^export /gm, "");
const entry = fs.readFileSync(path.join(root, "src/index.mjs"), "utf8")
    .replace('import { DockController, nearest } from "./dock.mjs";', core);
const banner = `/**\n * Cities: Skylines II UI Module\n *\n * Id: ${metadata.id}\n * Author: ${metadata.author}\n * Version: ${metadata.version}\n * Dependencies: ${metadata.dependencies.join(",")}\n */\n`;
const outputs = [path.join(root, "build")];
// Matches the SDK's local Mods deployment folder, as in the existing mods.
if (process.env.CSII_USERDATAPATH)
    outputs.push(path.join(process.env.CSII_USERDATAPATH, "Mods", metadata.id));
for (const directory of outputs) {
    fs.mkdirSync(directory, { recursive: true });
    fs.writeFileSync(path.join(directory, `${metadata.id}.mjs`), banner + entry);
    fs.copyFileSync(path.join(root, "src/dock.css"), path.join(directory, `${metadata.id}.css`));
    console.log(`Built ${metadata.id} ${metadata.version}: ${directory}`);
}
