using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEditor;
using UnityEngine;

[Tiled2Unity.CustomTiledImporter]
class CustomTiledImporterForGameObjects : Tiled2Unity.ICustomTiledImporter
{
	public void HandleCustomProperties (UnityEngine.GameObject gameObject, IDictionary<string, string> props)
	{
		// Check that this game object has an object property
		if (!props.ContainsKey ("object")) {
			return;
		}

		// Load the prefab asset
		UnityEngine.Object spawn = AssetDatabase.LoadAssetAtPath ("Assets/Prefabs/" + props ["object"] + ".prefab", typeof(GameObject));
		
		if (spawn == null) {
			return;
		}
		
		// Instantiate the asset
		GameObject spawnInstance = (GameObject)GameObject.Instantiate (spawn);
		spawnInstance.name = spawn.name;

		// Position the asset
		spawnInstance.transform.parent = gameObject.transform.parent;
		spawnInstance.transform.localPosition = gameObject.transform.localPosition;
		
		// Remove the old object
		GameObject.DestroyImmediate (gameObject);
	}
	
	public void CustomizePrefab (UnityEngine.GameObject prefab)
	{
		// Do nothing
	}
}

