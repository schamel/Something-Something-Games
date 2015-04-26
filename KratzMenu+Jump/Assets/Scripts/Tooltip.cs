using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {
	private Text tooltip;
	private Image tipbackground;
	private string tg;

	// Use this for initialization
	void Start () {
		//Get the Image and Tooltip by name;
		tooltip = GameObject.Find ("Tooltip").GetComponent<Text>();
		tipbackground = GameObject.Find ("TooltipBackground").GetComponent<Image>();
		tg = gameObject.tag;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseOver(){

		//Set the position of the tooltip
		tipbackground.transform.position = new Vector2(Input.mousePosition.x + 30, Input.mousePosition.y+10);
	
		//determine tooltip by tag;
		switch (tg) {
		case "Spring":
			tooltip.text="Springs launch you in\nthe implied direction.";
			break;
		case "Switch":
			tooltip.text="Switches change \n something in the world";
			break;
		case "Dash_panel":
			tooltip.text="Dash panels add speed\n in the implied direction";
			break;
		case "Jump_pad":
			tooltip.text="Jump pads launch\nyou into the air";
			break;
		case "Dash Ring":
			tooltip.text="Dash rings propel you in\n the implied direction";
			break;
		}

		//display the tooltip
		tooltip.enabled = true;
		tipbackground.enabled = true;
	}

	void OnMouseExit(){
		tooltip.enabled = false;
		tipbackground.enabled = false;
	}
}
