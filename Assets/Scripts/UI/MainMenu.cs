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
	
	// Use this for initialization
	void Start () {

		LogoStyle = new GUIStyle ();
		LogoStyle.fontSize = 20;

		gameName = "Augment: Robots";

		x_offset = 20.0f;
		y_offset = 20.0f;
		buttonWidth = 20.0f;
		buttonLength = Screen.width * .167f;
		buttonOffset = 15.0f;
	}

	void OnGUI()
	{
		if(GUI.Button (new Rect(x_offset, Screen.height / 2.0f - buttonOffset - buttonWidth - buttonWidth / 2.0f, buttonLength, buttonWidth), "Battle"))
		{
			Camera.main.gameObject.AddComponent<CharacterSelect>();
			Destroy(Camera.main.GetComponent<MainMenu>());
		}
		if(GUI.Button (new Rect(x_offset, Screen.height / 2.0f - buttonWidth / 2.0f, buttonLength, buttonWidth), "Customize"))
		{
			Camera.main.gameObject.AddComponent<CustomizeScreen>();
			Destroy(Camera.main.GetComponent<MainMenu>());
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
