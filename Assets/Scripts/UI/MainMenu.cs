using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	private GUIStyle LogoStyle;

	private string gameName;

	private float buttonWidth;
	private float buttonLength;
	private float buttonOffset;
	private float x_offset;
	private float y_offset;

	public Texture background;

	public GUISkin skin;
	
	// Use this for initialization
	void Start () {

		LogoStyle = new GUIStyle ();
		LogoStyle.fontSize = 20;

		gameName = "RoboCustom";

		x_offset = 20.0f;
		y_offset = 20.0f;
		buttonWidth = 20.0f;
		buttonLength = Screen.width * .167f;
		buttonOffset = 15.0f;
	}

	void OnGUI()
	{
		GUI.skin = skin;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background);

		if(GUI.Button (new Rect(x_offset, Screen.height / 2.0f - buttonOffset - buttonWidth - buttonWidth / 2.0f, buttonLength, buttonWidth), "Battle"))
		{
			Application.LoadLevel("Customize");
		}
		if(GUI.Button (new Rect(x_offset, Screen.height / 2.0f - buttonWidth / 2.0f, buttonLength, buttonWidth), "Instructions"))
		{
			Application.LoadLevel("Instructions");
		}
		if(GUI.Button (new Rect(x_offset, Screen.height / 2.0f + buttonOffset + buttonWidth - buttonWidth / 2.0f, buttonLength, buttonWidth), "Quit"))
		{
			Application.Quit();
		}

		Vector2 logoSize = LogoStyle.CalcSize(new GUIContent(gameName));
		GUI.Label (new Rect (Screen.width - logoSize.x - x_offset, y_offset, 100,100), gameName, LogoStyle);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
