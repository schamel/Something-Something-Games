using UnityEngine;
using System.Collections;

public class Tooltip : MonoBehaviour
{
	public Texture2D backdrop;
	public string toolTipText;

	private GUIStyle toolTipStyle;			
	private bool showToolTip = false;
	
	private void Start ()
	{
		// Fix the newlines in the tooltip text
		toolTipText = toolTipText.Replace ("\\n", "\n");
	
		// Setup the tooltip style
		toolTipStyle = new GUIStyle ();
		toolTipStyle.normal.textColor = Color.black;
		toolTipStyle.alignment = TextAnchor.MiddleCenter;
		toolTipStyle.wordWrap = true;
		toolTipStyle.fixedWidth = backdrop.width - 20;
	}
	
	private void OnMouseEnter ()
	{
		showToolTip = true;
	}
	
	private void OnMouseExit ()
	{
		showToolTip = false;
	}
	
	private void OnGUI ()
	{
		if (showToolTip) {
			var x = Event.current.mousePosition.x - (backdrop.width / 2);
			var y = Event.current.mousePosition.y + 20;
			
			GUI.Label (new Rect (x, y, backdrop.width, backdrop.height), backdrop);
			GUI.Label (new Rect (x - 5, y, backdrop.width - 20, backdrop.height), toolTipText, toolTipStyle);
		}
	} 
}
