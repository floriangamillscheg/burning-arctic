# Switch animal

## How does it works
It has an empty `GameObject` player who holds all the availables animals prefabs for the level. **Only one is activated and the other aren't.** When pressing the "X" key, it deactivate the current animal and activate the next one.

All the scripts and things common to all the animals are inside the player object. This include the `Rigid Body 2D`, the movement script, the infobox diplay script, ...

The animals hold their `Collider 2D`, sprite and animal script which defines their speed, health, weight, ...

If needed, the players scripts fetch some values in the animals script like the speed.