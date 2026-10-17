# 0.1.0 — Experimental test build

Latest additions:

- Added a native-style blurred settings background with a separate backdrop layer.
- Added French, Italian and Spanish for options, tooltips and the manager interface;
  English and German remain supported. Language follows the game setting.
- Added a read-only version display in mod options.
- Centralized the version in Version.props; rebuild to update DLL/UI metadata,
  the publish version and the current README heading automatically.
- Added build-time checks for missing translations.

Earlier corrections:

- Apply button selection and checkbox feedback immediately while settings are saved.
- Observe source button visibility changes directly instead of waiting for fallback polling.
- Resolve delayed Gameface layout changes over a bounded number of frames.
- Keep selection previews inside the Game UI tree so they disappear with it on menu transitions.
- Remove previews before restoring owned styles during cleanup.


- Choose one shared launcher or separate launchers for left and right mod buttons.
- Added independent saved positions and open states for each launcher.
- Button bars stay open when clicking elsewhere or pressing Escape.
- Added a selection mode: right-click mod buttons to include or exclude them.
- Added the CityMonitor-style Hide buttons selection option: enable it to edit,
  right-click manager icons to exclude them, disable it to finish.
- Excluded originals immediately return to the normal game UI. While selecting,
  the manager shows inert previews at 40% opacity; finishing removes those previews.
- Right-clicking a preview includes its original button again without remounting it.
- Right-click settings now handle mouse-down directly; trailing contextmenu events
  are deduplicated. Outside clicks and Escape leave the selection option enabled.
- Added independent opening directions for combined, left and right launchers.
- Added a position lock in mod options and the launcher menu; backend also rejects moves while locked.
- Matched the launcher style and size to the existing light-blue mod buttons.
- Removed the extra gear button; settings remain available by right-clicking the launcher.
- Replaced paging glyphs with SVG arrows and kept paging controls inside the screen.
- Updated English and German localization.

Earlier fixes in this test series:

- Fixed stylesheet loading with the required hasCSS export.
- Added DOM compatibility fallbacks and stable repeated button detection.
- Added support for translated and scaled parent elements.

Compatibility still depends on the source mods using the shared top-left or
right launcher hooks; larger mod windows and incompatible transforms are excluded.
