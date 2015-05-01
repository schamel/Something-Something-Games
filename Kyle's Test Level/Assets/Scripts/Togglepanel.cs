using UnityEngine;
using System.Collections;

public class Togglepanel : MonoBehaviour {
	public GameObject panel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			panel.SetActive(!panel.activeSelf);
		}
	}
}
