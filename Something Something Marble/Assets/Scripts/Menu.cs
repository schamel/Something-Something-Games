using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour
{
	public GameObject optionsPanel;
	public GameObject passwordPanel;
	public InputField passwordInput;

	private void Start ()
	{
		// Hide the password input
		passwordPanel.SetActive (false);
	}
	
	public void NewGame ()
	{
		PlayerPrefs.SetString ("Character", "Default");
		Application.LoadLevel ("Level 1");
	}
	
	public void EnterPassword (string password)
	{
		int level = 0;

		// Make the password be all caps
		password = password.ToUpper ();
		
		// Check which character the player wants to play as
		if (password.Length >= 2 && password.Substring (0, 2) == "CE") {
			PlayerPrefs.SetString ("Character", "Crazy Eight");
			password = password.Substring (2);
			level = 1;
		} else {
			PlayerPrefs.SetString ("Character", "Default");
		}
		
		// Check which level the user wants to load and load it if it exists
		if (password.Length > 0) {
			int.TryParse (password, out level);
		}

		if (level > 0 && level < Application.levelCount) {
			Application.LoadLevel ("Level " + level);
		} else {
			passwordInput.text = "Invalid Password!";
		}
	}
	
	public void TogglePasswordPanel ()
	{
		// Toggle the options and password input
		optionsPanel.SetActive (!optionsPanel.activeSelf);
		passwordPanel.SetActive (!passwordPanel.activeSelf);
	}
	
	public void Quit ()
	{
		Application.Quit ();
	}
	
	private void OnGUI ()
	{
		// Check for password entry		
		if (passwordInput.isFocused) {
			Event e = Event.current;

			if (e.keyCode == KeyCode.Return) {
				EnterPassword (passwordInput.text);
			}
		}
	}
}
