# Infobox Object

## How does it works

It works with two types of objects : the player and the infoboxes.

### Player
The player has a basic `Collider 2D` and has the script *DisplayInfoBox.cs* wich turn on/off the display of the info box.

### The infobox
The infobox object is composed of a `SpriteRenderer` and a `Collider 2D` in trigger mode. It also has the `InfoBox` tag. The infobox object has a `Canvas` which is inactive and display the infobox message when activated.

## Add a new object to my scene
1. Add the prefab to the scene.
1. Activate the **canva *object*** (not the component of the object!).
1. Links the canva component to the main camera. *(maybe change that part when we have a moving camera).*
1. Set the infobox message however you want.
1. Deactivate the canva object.