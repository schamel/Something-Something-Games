using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	 

	public GameObject LevelSelectPanel;
	
	// Use this for initialization
	void Start () {
		LevelSelectPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void load(string level){
		Application.LoadLevel(level);
	}

	public void quit(){
		Application.Quit ();
	}

	public void panelopen() {
		if (!LevelSelectPanel.activeSelf) {
			LevelSelectPanel.SetActive(true);
		}
		else if (LevelSelectPanel.activeSelf) {
			LevelSelectPanel.SetActive(false);
		}
	}
}
