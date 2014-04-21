using UnityEngine;
using System.Collections;

public class SplashPageUI : MonoBehaviour {

	private GUIStyle LogoStyle;

	// Use this for initialization
	void Start () {
		LogoStyle = new GUIStyle ();
		LogoStyle.fontSize = 20;
	}

	void OnGUI()
	{
		GUI.Box (new Rect (0, 0, Screen.width, Screen.height - 50), "");
		GUI.Box (new Rect (0, Screen.height - 50 , Screen.width, 50),"");
		GUI.Label (new Rect (5, Screen.height - 70, 100, 100), "Custom Robo", LogoStyle);
		if (GUI.Button (new Rect (Screen.width - 210, Screen.height - 40 , 200, 30), "Start")) {
			// Start game, switch scripts to main menu
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
