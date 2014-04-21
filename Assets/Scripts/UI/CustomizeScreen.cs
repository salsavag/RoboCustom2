using UnityEngine;
using System.Collections;

public class CustomizeScreen : MonoBehaviour {

	private GUIStyle LogoStyle;

	private bool main = true;
	private bool newRobo = false;
	private bool chooseEdit = false;
	private bool editRobo = false;

	private string roboName = "";

	GUIContent[] bodyList;
	private ComboBox bodyBox = new ComboBox();
	private GUIStyle bodyStyle = new GUIStyle();

	GUIContent[] rightList;
	private ComboBox rightBox = new ComboBox();

	GUIContent[] leftList;
	private ComboBox leftBox = new ComboBox();

	GUIContent[] specList;
	private ComboBox specBox = new ComboBox();

	// Use this for initialization
	void Start () {

		bodyList = new GUIContent[5];
		bodyList[0] = new GUIContent("(Body)");
		bodyList[1] = new GUIContent("The PussyCrusher");
		bodyList[2] = new GUIContent("Brobot");
		bodyList[3] = new GUIContent("Steve");
		bodyList[4] = new GUIContent("The Thing");

		rightList = new GUIContent[5];
		rightList[0] = new GUIContent("(Right)");
		rightList[1] = new GUIContent("Machine Gun");
		rightList[2] = new GUIContent("Pistol");
		rightList[3] = new GUIContent("Sniper");
		rightList[4] = new GUIContent("Shotty");

		leftList = new GUIContent[5];
		leftList[0] = new GUIContent("(Left)");
		leftList[1] = new GUIContent("Machine Gun");
		leftList[2] = new GUIContent("Pistol");
		leftList[3] = new GUIContent("Sniper");
		leftList[4] = new GUIContent("Shotty");

		specList = new GUIContent[5];
		specList[0] = new GUIContent("(Special)");
		specList[1] = new GUIContent("Wings");
		specList[2] = new GUIContent("Boosters");
		specList[3] = new GUIContent("Launcher");
		specList[4] = new GUIContent("Salsa");
	
		LogoStyle = new GUIStyle ();
		LogoStyle.fontSize = 20;

	}

	void OnGUI(){

		if (main) {

			float x_offset = 20.0f;
			float y_offset = 20.0f;
			float buttonWidth = 20.0f;
			float buttonLength = Screen.width * .167f;
			float buttonOffset = 15.0f;

			GUI.Label(new Rect(x_offset, y_offset, 500, 500), "Customize Your Robot!", LogoStyle);

			if (GUI.Button (new Rect(Screen.width - x_offset - buttonLength, Screen.height / 2.0f - buttonOffset - buttonWidth - buttonWidth / 2.0f, buttonLength, buttonWidth), "Edit Robot")) {
				main = false;
				chooseEdit = true;	
			}
			if (GUI.Button (new Rect(Screen.width - x_offset - buttonLength, Screen.height / 2.0f - buttonWidth / 2.0f, buttonLength, buttonWidth), "New Robot")) {
				main = false;
				newRobo = true;
			}
			if (GUI.Button (new Rect(Screen.width - x_offset - buttonLength, Screen.height / 2.0f + buttonOffset + buttonWidth - buttonWidth / 2.0f, buttonLength, buttonWidth), "Back")) {
				Camera.main.gameObject.AddComponent<MainMenu> ();
				Destroy (Camera.main.GetComponent<CustomizeScreen> ());
			}
		}
		else if(newRobo){

			GUI.Box (new Rect(Screen.width / 2 - (Screen.width / 12) - 5, 5, Screen.width / 6 + 10, 53), "");

			roboName = GUI.TextField(new Rect(Screen.width / 2 - (Screen.width / 12), 10, Screen.width / 6, 20), roboName);

			if (GUI.Button (new Rect (Screen.width / 2 - (Screen.width / 12), 33, Screen.width / 12, 20), "Save")) {

			}
			if (GUI.Button (new Rect (Screen.width / 2, 33, Screen.width / 12, 20), "Back")) {
				main = true;
				newRobo = false;
			}

			// Body drop down
			int selectedbody = bodyBox.GetSelectedItemIndex();
			selectedbody = bodyBox.List(new Rect(0, 0, Screen.width/6, 20), bodyList[selectedbody].text, bodyList, bodyStyle );

			GUI.Box (new Rect(0, 20, Screen.width / 6, 150), "");

			// Right weapon
			int selectedright = rightBox.GetSelectedItemIndex();
			selectedright = rightBox.List(new Rect(Screen.width * 5 / 6, 0, Screen.width/6, 20), rightList[selectedright].text, rightList, bodyStyle );
			
			GUI.Box (new Rect(Screen.width * 5 / 6, 20, Screen.width / 6, 150), "");

			// Left weapon
			int selectedleft = leftBox.GetSelectedItemIndex();
			selectedleft = leftBox.List(new Rect(Screen.width * 5 / 6, Screen.height - 170, Screen.width/6, 20), leftList[selectedleft].text, leftList, bodyStyle );
			
			GUI.Box (new Rect(Screen.width * 5 / 6, Screen.height - 150, Screen.width / 6, 150), "");

			// special weapon
			int selectedspec = specBox.GetSelectedItemIndex();
			selectedspec = specBox.List(new Rect(0, Screen.height - 170, Screen.width/6, 20), specList[selectedspec].text, specList, bodyStyle );
			
			GUI.Box (new Rect(0, Screen.height - 150, Screen.width / 6, 150), "");

		}
		else if(editRobo){

			GUI.Box (new Rect(Screen.width / 2 - (Screen.width / 12) - 5, 5, Screen.width / 6 + 10, 53), "");
			
			roboName = GUI.TextField(new Rect(Screen.width / 2 - (Screen.width / 12), 10, Screen.width / 6, 20), roboName);
			
			if (GUI.Button (new Rect (Screen.width / 2 - (Screen.width / 12), 33, Screen.width / 12, 20), "Save")) {
				
			}
			if (GUI.Button (new Rect (Screen.width / 2, 33, Screen.width / 12, 20), "Back")) {
				chooseEdit = true;
				editRobo = false;
			}
			
			// Body drop down
			int selectedbody = bodyBox.GetSelectedItemIndex();
			selectedbody = bodyBox.List(new Rect(0, 0, Screen.width/6, 20), bodyList[selectedbody].text, bodyList, bodyStyle );
			
			GUI.Box (new Rect(0, 20, Screen.width / 6, 150), "");
			
			// Right weapon
			int selectedright = rightBox.GetSelectedItemIndex();
			selectedright = rightBox.List(new Rect(Screen.width * 5 / 6, 0, Screen.width/6, 20), rightList[selectedright].text, rightList, bodyStyle );
			
			GUI.Box (new Rect(Screen.width * 5 / 6, 20, Screen.width / 6, 150), "");
			
			// Left weapon
			int selectedleft = leftBox.GetSelectedItemIndex();
			selectedleft = leftBox.List(new Rect(Screen.width * 5 / 6, Screen.height - 170, Screen.width/6, 20), leftList[selectedleft].text, leftList, bodyStyle );
			
			GUI.Box (new Rect(Screen.width * 5 / 6, Screen.height - 150, Screen.width / 6, 150), "");
			
			// special weapon
			int selectedspec = specBox.GetSelectedItemIndex();
			selectedspec = specBox.List(new Rect(0, Screen.height - 170, Screen.width/6, 20), specList[selectedspec].text, specList, bodyStyle );
			
			GUI.Box (new Rect(0, Screen.height - 150, Screen.width / 6, 150), "");

		}

		else if (chooseEdit) {
			GUI.BeginGroup(new Rect(Screen.width * 2 / 6, Screen.height * 2 / 6, Screen.width / 3, Screen.height / 3));

			GUI.Box (new Rect(0, 0, Screen.width / 3, Screen.height / 3), "");

			GUI.Label (new Rect(10, 10, 500, 500), "Choose a Robot", LogoStyle);

			if(GUI.Button(new Rect(10, Screen.height / 3 - 30, Screen.width / 12, 20), "Back"))
			{
				chooseEdit = false;
				main = true;
			}

			if(GUI.Button(new Rect(Screen.width / 3 - Screen.width / 12 - 10, Screen.height / 3 - 30, Screen.width / 12, 20), "Edit"))
			{
				chooseEdit = false;
				editRobo = true;
			}

			GUI.EndGroup();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
