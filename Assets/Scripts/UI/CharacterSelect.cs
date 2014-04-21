using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour {

	public int playerOneSelected;
	public int playerTwoSelected;

	public int numChars;

	private GUIStyle TitleStyle;

	Vector2 scrollPosition;

	// Use this for initialization
	void Start () {
		TitleStyle = new GUIStyle ();
		TitleStyle.fontSize = 20;

		numChars = 100;

		scrollPosition = Vector2.zero;
	}

	// GUI Items
	void OnGUI() {

		// Containing box
		GUI.Box (new Rect(25,25, Screen.width - 50, Screen.height - 50), "");

		// Title
		Vector2 titleSize = TitleStyle.CalcSize(new GUIContent("Robot Select"));
		GUI.Label (new Rect (Screen.width / 2 - (titleSize.x / 2.0f), 35, titleSize.x, titleSize.y), "Robot Select", TitleStyle);

		// Player tags
		titleSize = TitleStyle.CalcSize(new GUIContent("Player 1"));
		GUI.Label (new Rect (35, 35, titleSize.x, titleSize.y), "Player 1", TitleStyle);
		
		titleSize = TitleStyle.CalcSize(new GUIContent("Player 2"));
		GUI.Label (new Rect (Screen.width - titleSize.x - 35, 35, titleSize.x, titleSize.y), "Player 2", TitleStyle);

		float button_pos_x = 0;
		float button_pos_y = 0;
		float buttonSize = (Screen.width - 109) / 10;
		int extra = 1;
		if (numChars % 10 == 0) extra = 0;

		GUI.BeginGroup (new Rect (35, 205, Screen.width - 70, Screen.height - 273));
		scrollPosition = GUI.BeginScrollView (new Rect (0, 0, Screen.width - 70, Screen.height - 273), scrollPosition, new Rect (0, 0, Screen.width - 87, buttonSize*(numChars/10 + extra) + 3 * numChars/10));

		for (int i = 0; i < numChars; i++) {

			button_pos_x = buttonSize * (i % 10) + 3 * (i % 10);
			button_pos_y = buttonSize * (i / 10) + 3 * (i / 10);

			if(GUI.Button (new Rect(button_pos_x, button_pos_y, buttonSize, buttonSize), "Champ"))
			{
				Debug.Log("Clicked button " + i.ToString());
			}
		}

		GUI.EndScrollView ();
		GUI.EndGroup ();

		float button_x = 75.0f;
		float button_y = 20.0f;

		if (GUI.Button (new Rect (35, Screen.height - 35 - button_y, button_x, button_y), "Back")) {
			Camera.main.gameObject.AddComponent<MainMenu>();
			Destroy(Camera.main.GetComponent<CharacterSelect>());
		}

		if (GUI.Button (new Rect (Screen.width - 35 - button_x, Screen.height - 35 - button_y, button_x, button_y), "Play")) {
			//Destroy(Camera.main.GetComponent<CharacterSelect>());
			Application.LoadLevel ("Game");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
