Using Tiled Maps in Unity
================================================================================

This guide will get you started creating maps in Tiled that can be used in Unity.

This guide does not cover making parts of the map animated currently, as I have  
not worked on that yet, but I know it is possible to do with all this also, so  
we will need to figure that out if we want to have animation in our maps (which  
I would assume we do want some.)

Needed Tools
--------------------------------------------------------------------------------

Tiled Map Editor		http://www.mapeditor.org/
Tiled2Unity Utility		http://www.seanba.com/Tiled2Unity

Creating You Map
--------------------------------------------------------------------------------

 1. Open Tiled and create a new map

	a. Orientation should be set to "Orthogonal"
	b. Tile layer format can be set to anything (I recommend CSV)
	c. The default tile render order of "Right Down" is fine
	d. Map size and Tile size are pretty obvious

 2. Add your spritesheets using "Map > New Tileset"

 3. Setup the collision of each tile by using "View > Tile Collision Editor"

 4. Configure your game objects (these are the objects the user interacts with,  
	such as Item Blocks, Springs, etc.) by adding a custom property to them  
	named "object" with the value being the name of prefab this object relates  
	to in Unity (these prefabs don't have to be made yet!)

 5. Add your new tiles to your map separating them into layers as you see fit

	a. You may want to enable "Snap to Grid" under "View" to force tiles to line up nicely
	b. Only place game objects on an "Object Layer" and not a "Tile Layer"

 6. Save your map
 
Getting Unity Ready
--------------------------------------------------------------------------------

 1. Create the unity project
 
 2. Import the Tiled2Unity package (import everything, for some reason it  
	complains later if you tell it not to add the _readme files)
 
 3. Create the prefabs needed for your game objects
 
 4. Create a "CustomTiledImporter" to handle replacing the object markers with  
	the actual objects (I have written a simple script that should handle all  
	objects so long as they don't need any special configuration.)
 
Getting your map into Unity
--------------------------------------------------------------------------------

 1. Open the Tiled2Unity utility

 2. Set the Vertex Scale to "0.01"

 3. Open your map file

 4. Set the Export Directory to your Unity Project Directory

 5. Hit the the "Big Ass Export Button" and you should now have your map  
	as a prefab in unity which can be added to your scene