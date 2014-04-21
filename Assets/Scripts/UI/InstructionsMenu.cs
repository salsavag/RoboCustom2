using UnityEngine;
using System.Collections;

public class InstructionsMenu : MonoBehaviour {

	public Texture background;
	public GUISkin skin;

	private float buttonHeight = Screen.height / 20;
	private float buttonWidth = Screen.width / 5;
	private float offset = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.skin = skin;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background);

		if (GUI.Button (new Rect (offset, Screen.height - buttonHeight - offset, buttonWidth, buttonHeight), "Back"))
		{
			Application.LoadLevel("MainMenu");
		}
	}
}
