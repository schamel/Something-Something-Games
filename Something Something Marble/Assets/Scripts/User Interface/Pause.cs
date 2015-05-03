using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pause : MonoBehaviour
{
	public GameObject pauseMenu;
	
	private static Pause _instance;

	public static Pause Instance {
		get {
			if (_instance == null) {
				_instance = FindObjectOfType<Pause> ();
			}

			return _instance;
		}
	}
	
	private void FixedUpdate ()
	{		
		if (Input.GetKeyDown (KeyCode.Escape)) {
			pauseMenu.SetActive (!pauseMenu.activeSelf);
		}
	}
	
	public void NewGame ()
	{
		PlayerPrefs.SetString ("Character", "Default");
		Application.LoadLevel ("Level 1");
	}
	
	public void MainMenu ()
	{
		Application.LoadLevel ("Main Menu");
	}
	
	public void Quit ()
	{
		Application.Quit ();
	}
	
	public bool IsPaused ()
	{
		return pauseMenu.activeSelf;
	}
}
