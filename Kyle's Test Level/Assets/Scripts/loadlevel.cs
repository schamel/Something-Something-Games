using UnityEngine;
using System.Collections;

public class loadlevel : MonoBehaviour {

	public void load(string level){
		Application.LoadLevel (level);
	}
}
