using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEditor;
using UnityEngine;

[Tiled2Unity.CustomTiledImporter]
class DeadlyObjects : Tiled2Unity.ICustomTiledImporter
{
	public void HandleCustomProperties (UnityEngine.GameObject gameObject, IDictionary<string, string> props)
	{
		// Check that this game object has the correct object value
		if (!props.ContainsKey ("deadly") || props ["deadly"] != "true") {
			return;
		}
		
		// Set the tag to let the game know this object will kill the player (Does not work if another tag has already been set!)
		if (gameObject.tag == "Untagged") {
			gameObject.tag = "Deadly";
		}
	}
	
	public void CustomizePrefab (UnityEngine.GameObject prefab)
	{
		// Do nothing
	}
}

