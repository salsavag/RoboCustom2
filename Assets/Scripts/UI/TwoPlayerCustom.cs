using UnityEngine;
using System.Collections;

public class TwoPlayerCustom : MonoBehaviour {

	private GUIStyle LogoStyle;

	// The position on of the scrolling viewport
	Vector2 scrollPosition;

	private int bufferArea = Screen.width / 40;
	private int buttonSpacing = Screen.width / 50;
	
	private int boxWidth = Screen.width / 3;
	private int boxHeight = Screen.height / 8;
	private int buttonWidth = Screen.width / 9;
	private int buttonHeight = Screen.height / 20;

	private Rect cameraOverlay1;
	private Rect cameraOverlay2;

	public Texture overlay;

	private enum SelectedArea {
		Selector,
		RightArm,
		LeftArm,
		Body,
		Special
	};

	public GUISkin skin;

	private static string[] EnumStrings = {"Selector", "Right Arm", "Left Arm", "Body", "Special"};

	private SelectedArea topValue;
	private SelectedArea bottomValue;

	// Use this for initialization
	void Start () {
		LogoStyle = new GUIStyle ();
		LogoStyle.fontSize = 20;
		scrollPosition = Vector2.zero;

		cameraOverlay1 = new Rect(Screen.width / 2, 0, Screen.width/2, Screen.height/2);
		cameraOverlay2 = new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2);

	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			topValue = (SelectedArea)(((int)(topValue) % 4) + 1);
		}
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			topValue = (SelectedArea)(((int)(topValue + 3) % 4) + 1);
		}
	}

	void OnGUI () {
	
		GUI.skin = skin;

		GUI.DrawTexture(cameraOverlay1, overlay);
		GUI.DrawTexture (cameraOverlay2, overlay);

		//Top Left Quadrant
		GUI.BeginGroup (new Rect (bufferArea, bufferArea, Screen.width / 2 - bufferArea, Screen.height / 2 - bufferArea));
		GUI.Label (new Rect (3 * bufferArea + buttonWidth, 0, buttonWidth, buttonHeight), EnumStrings[(int)topValue]);

		for(int i = 0; i < 4; i++)
		{
			if(GUI.Button(new Rect(bufferArea, bufferArea + (buttonSpacing + buttonHeight) * i, buttonWidth, buttonHeight), EnumStrings[i + 1]))
			{
				topValue = (SelectedArea)(i + 1);
			}
		}

		GUI.BeginGroup (new Rect (Screen.width / 5, bufferArea, Screen.width / 4, Screen.height / 4));

		if (topValue == SelectedArea.Selector) { 

		}
		else
		{
			for(int i = 1; i < 5; i++)
			{
				if(topValue == (SelectedArea)(i))
				{
					for(int j = 0; j < 4; j++)
					{
						GUI.Button(new Rect(0, j * 40, (int)(boxWidth * .25), 30), EnumStrings[i] + " " + (j + 1));
					}
					break;
				}
			}
		}

		GUI.EndGroup();
//
//		if (topValue == SelectedArea.Selector) { 
//						//Top right quadrant
//
//						if (GUI.Button (new Rect (bufferArea, bufferArea, buttonWidth, buttonHeight), "Right Arm")) {
//							topValue = SelectedArea.RightArm;
//						}
//
//						if (GUI.Button (new Rect (bufferArea, bufferArea + (buttonSpacing + buttonHeight), buttonWidth, buttonHeight), "Left Arm")) {
//							topValue = SelectedArea.LeftArm;
//						}
//
//						if (GUI.Button (new Rect (bufferArea, bufferArea + 2 * (buttonSpacing + buttonHeight), buttonWidth, buttonHeight), "Body")) {
//							topValue = SelectedArea.Body;
//						}
//
//						if (GUI.Button (new Rect (bufferArea, bufferArea + 3 * (buttonSpacing + buttonHeight), buttonWidth, buttonHeight), "Special")) {
//							topValue = SelectedArea.Special;
//						}
//		}
//		else { 
//			if (GUI.Button (new Rect (boxWidth + buttonSpacing, bufferArea, buttonWidth, buttonHeight), "Back")) {
//				topValue = SelectedArea.Selector;
//			}
//			GUI.Box (new Rect (0, bufferArea, boxWidth, boxHeight), "");
//
//			if (topValue == SelectedArea.RightArm) {
//
//			}
//			
//			if (topValue == SelectedArea.LeftArm) {
//
//			}
//			
//			if (topValue == SelectedArea.Body) {
//
//			}
//			
//			if (topValue == SelectedArea.Special) {
//
//			}
//		}
		GUI.EndGroup();

		//Botton Left Quadrant
		GUI.BeginGroup (new Rect (bufferArea, bufferArea + Screen.height /2, Screen.width / 2 - bufferArea, Screen.height / 2 - bufferArea));
		GUI.Label (new Rect (3 * bufferArea + buttonWidth, 0, buttonWidth, buttonHeight), EnumStrings[(int)bottomValue]);

		if (bottomValue == SelectedArea.Selector) { 
			//Top right quadrant
			
			if (GUI.Button (new Rect (bufferArea, bufferArea, buttonWidth, buttonHeight), "Right Arm")) {
				bottomValue = SelectedArea.RightArm;
			}
			
			if (GUI.Button (new Rect (bufferArea, bufferArea + (buttonSpacing + buttonHeight), buttonWidth, buttonHeight), "Left Arm")) {
				bottomValue = SelectedArea.LeftArm;
			}
			
			if (GUI.Button (new Rect (bufferArea, bufferArea + 2 * (buttonSpacing + buttonHeight), buttonWidth, buttonHeight), "Body")) {
				bottomValue = SelectedArea.Body;
			}
			
			if (GUI.Button (new Rect (bufferArea, bufferArea + 3 * (buttonSpacing + buttonHeight), buttonWidth, buttonHeight), "Special")) {
				bottomValue = SelectedArea.Special;
			}
		}
		else { 
			if (GUI.Button (new Rect (boxWidth + buttonSpacing, bufferArea, buttonWidth, buttonHeight), "Back")) {
				bottomValue = SelectedArea.Selector;
			}
			GUI.Box (new Rect (0, bufferArea, boxWidth, boxHeight), "");
			
			scrollPosition = GUI.BeginScrollView (new Rect (0, boxHeight + (int)(1.5 * bufferArea), boxWidth, boxHeight * 2), scrollPosition, new Rect (0, 0, boxWidth - 20, boxHeight * 5));
			
			if (bottomValue == SelectedArea.RightArm) {
				GUI.Button (new Rect (0, 0, boxWidth - 20, 20), "First");
				GUI.Button (new Rect (0, 25, boxWidth - 20, 20), "Second");
				GUI.Button (new Rect (0, 50, boxWidth - 20, 20), "Third");
				GUI.Button (new Rect (0, 75, boxWidth - 20, 20), "Fourth");
				GUI.Button (new Rect (0, 100, boxWidth - 20, 20), "Fifth");
			}
			
			if (bottomValue == SelectedArea.LeftArm) {
				
			}
			
			if (bottomValue == SelectedArea.Body) {
				
			}
			
			if (bottomValue == SelectedArea.Special) {
				
			}
			GUI.EndScrollView ();
		}
		GUI.EndGroup();
	}
}
