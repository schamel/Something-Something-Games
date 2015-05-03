using UnityEngine;
using System.Collections;

public class LevelExit : MonoBehaviour
{
	private void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			// Load the next level
			int level = Application.loadedLevel + 1;
			
			if (level >= Application.levelCount && PlayerPrefs.GetString ("Character") == "Default") {
				PlayerPrefs.SetString ("Character", "Crazy Eight");
				level = 1;
			}
			
			if (level < Application.levelCount) {
				Application.LoadLevel ("Level " + level);
			} else {
				Application.LoadLevel ("Main Menu");
			}
		}
	}
}
