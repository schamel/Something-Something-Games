using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	public Sprite spritePressed;
	public Sprite spriteUnpressed;

	private bool pressed;
	public bool Pressed {
		get {
			return pressed;
		}
		set {
			pressed = value;
			if (pressed) {
				GetComponent<SpriteRenderer> ().sprite = spritePressed;
			} else {
				GetComponent<SpriteRenderer> ().sprite = spriteUnpressed;
			}
		}
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D trigger) {
		switch (trigger.gameObject.tag) {
		case "Player":
			Pressed = !Pressed;
			break;
		}
	}
}
