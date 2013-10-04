using UnityEngine;
using System.Collections;

public class MainMenuGui : MonoBehaviour {

	// Use this for initialization
	void OnGui() 
	{
		GUI.Label (new Rect(25,25,100,30), "Label");
	}
	
}
