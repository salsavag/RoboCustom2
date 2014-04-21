using UnityEngine;
using System.Collections.Generic;

public class TwoPlayerCustom2 : MonoBehaviour
{

	private int bufferArea = Screen.width / 40;
	private int buttonSpacing = Screen.width / 100;
	
	private int boxWidth = (int)(Screen.width / 3.55);
	private int boxHeight = Screen.height / 8;
	private int buttonWidth = Screen.width / 9;
	private int buttonHeight = Screen.height / 20;

	private Rect cameraOverlay1;
	private Rect cameraOverlay2;

	public Texture overlay;

	public Camera player1Camera;
	public Camera player2Camera;
	
	public RobotModel robo1;
	public RobotModel robo2;

	public GameObject player1Robot;
	public GameObject player2Robot;

	private enum SelectedArea {
		Selector,
		Body,
		LeftArm,
		RightArm,
		Special
	};

	public GUISkin skin;

	private static string[] EnumStrings = {"Selector", "Body", "Left Arm", "Right Arm", "Special"};

	private SelectedArea player1SelectedType;
	private SelectedArea player2SelectedType;

	private bool player1Picking = false;
	private bool player2Picking = false;

	private int[] player1SelectedParts = new int[5];
	private int[] player2SelectedParts = new int[5];

	private List<List<PartData>> partLists;

	private List<Color> colors = new List<Color>();
	private int player1Primary;
	private int player1Secondary;

	private int player2Primary;
	private int player2Secondary;

	private Texture primary1;
	private Texture secondary1;

	private Texture primary2;
	private Texture secondary2;

	// Use this for initialization
	void Start ()
	{
		cameraOverlay1 = new Rect(Screen.width / 2, 0, Screen.width / 2 + 1, Screen.height / 2 + 1);
		cameraOverlay2 = new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2 + 1, Screen.height / 2 + 1);

		partLists = PartData.GetAllPartData();

		for(int i = 1; i < 5; i++)
		{
			player1SelectedParts[i] = 0;
			player2SelectedParts[i] = 0;
		}

		// Colors
		colors.Add(Color.white);
		colors.Add(Color.red);
		colors.Add(new Color(1.0f, 130.0f/255.0f, 0)); // orange
		colors.Add(Color.yellow);
		colors.Add(new Color(0.0f, 0.7f, 0.0f)); // green
		colors.Add(Color.cyan);
		colors.Add(new Color(0.0f, 56f/255f, 128.0f/255f)); // blue
		colors.Add(Color.magenta);
		colors.Add(Color.black);
		colors.Add(Color.gray);

		Random.seed = (int)(Time.realtimeSinceStartup * 100000000);
		player1Primary = 0;
		player1Secondary = 0;
		player2Primary = 0;
		player2Secondary = 0;

		while(player1Primary == player1Secondary)
		{
			player1Primary = (int)Random.Range(0.0f, colors.Count) % colors.Count;
			player1Secondary = (int)Random.Range(0.0f, colors.Count) % colors.Count;
		}

		while(player2Primary == player2Secondary || (player1Primary == player2Primary && player1Secondary == player2Secondary))
		{
			player2Primary = (int)Random.Range(0.0f, colors.Count) % colors.Count;
			player2Secondary = (int)Random.Range(0.0f, colors.Count) % colors.Count;
		}

		AddRobot (1, "Astro");
		AddRobot (2, "Salsa");

		ChangePrimaryPlayer1();
		ChangeSecondaryPlayer1();
		//ChangePrimaryPlayer2();
		//ChangeSecondaryPlayer2();

//		UpdateParts (1);
//		UpdateParts (2);


		AddRobot (1, "Salsa");
		AddRobot (2, "Salsa");
	}

	void ChangePrimaryPlayer1()
	{
		player1Primary++;
		if(player1Primary >= colors.Count)
		{
			player1Primary = 0;
		}
		Utility.SetPrimary(robo1.gameObject, colors[player1Primary]);
		SetTexture(2, colors[player1Primary]);
	}

	void ChangeSecondaryPlayer1()
	{
		player1Secondary++;
		if(player1Secondary >= colors.Count)
		{
			player1Secondary = 0;
		}
		Utility.SetSecondary(robo1.gameObject, colors[player1Secondary]);
		SetTexture(3, colors[player1Secondary]);
	}

	void ChangePrimaryPlayer2()
	{
		player2Primary++;
		if(player2Primary >= colors.Count)
		{
			player2Primary = 0;
		}
		Utility.SetPrimary(robo2.gameObject, colors[player2Primary]);
		SetTexture(4, colors[player2Primary]);
	}
	
	void ChangeSecondaryPlayer2()
	{
		player2Secondary++;
		if(player2Secondary >= colors.Count)
		{
			player2Secondary = 0;
		}
		Utility.SetSecondary(robo2.gameObject, colors[player2Secondary]);
		SetTexture(5, colors[player2Secondary]);
	}


	void SetTexture(int index, Color color)
	{
		Texture2D texture = new Texture2D(16, 16);
		for (int y = 0; y < texture.height; ++y)
		{
			for (int x = 0; x < texture.width; ++x)
			{
				texture.SetPixel(x, y, color);
			}
		}
		texture.Apply();
		skin.customStyles[index].normal.background = texture;
	}

	void Player1Input()
	{
		if(Input.GetKeyDown(KeyCode.S))
		{
			if(player1Picking)
			{
				int partNum = player1SelectedParts[(int)player1SelectedType];
				int listSize = partLists[(int)player1SelectedType - 1].Count;
				partNum++;
				if(partNum >= listSize)
				{
					partNum = listSize - 1;
				}
				player1SelectedParts[(int)player1SelectedType] = partNum;
			}
			else
			{
				int selectedNum = (int)(player1SelectedType) + 1;
				if(selectedNum > 4)
					selectedNum = 4;
				player1SelectedType = (SelectedArea)selectedNum;
			}
		}
		if(Input.GetKeyDown(KeyCode.W))
		{
			if(player1Picking)
			{
				int partNum = player1SelectedParts[(int)player1SelectedType];
				partNum--;
				if(partNum < 0)
				{
					partNum = 0;
				}
				player1SelectedParts[(int)player1SelectedType] = partNum;
			}
			else
			{
				int selectedNum = (int)(player1SelectedType) - 1;
				if(selectedNum < 1)
					selectedNum = 1;
				player1SelectedType = (SelectedArea)selectedNum;
			}
		}
		if(Input.GetKeyDown(KeyCode.A))
		{
			if(player1SelectedType != SelectedArea.Selector)
				player1Picking = false;
		}
		if(Input.GetKeyDown(KeyCode.D))
		{
			if(player1SelectedType != SelectedArea.Selector)
				player1Picking = true;
		}

		if(Input.GetKeyDown(KeyCode.Q))
		{
			ChangePrimaryPlayer1();
		}

		if(Input.GetKeyDown(KeyCode.E))
		{
			ChangeSecondaryPlayer1();
		}


		if(Input.GetKeyDown("OSX LJoyV"))
		{
			Debug.Log("poop");
		}

		if(Input.GetKeyDown("OSX LJoyH"))
		{
			Debug.Log("poop");
		}

	}

	void Player2Input()
	{
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			if(player2Picking)
			{
				int partNum = player2SelectedParts[(int)player2SelectedType];
				int listSize = partLists[(int)player2SelectedType - 1].Count;
				partNum++;
				if(partNum >= listSize)
				{
					partNum = listSize - 1;
				}
				player2SelectedParts[(int)player2SelectedType] = partNum;
			}
			else
			{
				int selectedNum = (int)(player2SelectedType) + 1;
				if(selectedNum > 4)
					selectedNum = 4;
				player2SelectedType = (SelectedArea)selectedNum;
			}
		}
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			if(player2Picking)
			{
				int partNum = player2SelectedParts[(int)player2SelectedType];
				partNum--;
				if(partNum < 0)
				{
					partNum = 0;
				}
				player2SelectedParts[(int)player2SelectedType] = partNum;
			}
			else
			{
				int selectedNum = (int)(player2SelectedType) - 1;
				if(selectedNum < 1)
					selectedNum = 1;
				player2SelectedType = (SelectedArea)selectedNum;
			}
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			if(player2SelectedType != SelectedArea.Selector)
				player2Picking = false;
		}
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			if(player2SelectedType != SelectedArea.Selector)
				player2Picking = true;
		}

		if(Input.GetKeyDown(KeyCode.Comma))
		{
			ChangePrimaryPlayer2();
		}
		
		if(Input.GetKeyDown(KeyCode.Period))
		{
			ChangeSecondaryPlayer2();
		}

	}

	// Update is called once per frame
	void Update ()
	{
		Player1Input();
		Player2Input();
	}

	void OnGUI ()
	{
		GUI.skin = skin;

		GUI.DrawTexture(cameraOverlay1, overlay);
		GUI.DrawTexture (cameraOverlay2, overlay);
		// ---------------------------------------------------------------------------------------------------------------------------
		//Top Left Quadrant
		GUI.BeginGroup (new Rect (bufferArea / 2, bufferArea / 2, Screen.width / 2 - bufferArea, Screen.height / 2 - bufferArea));
		GUI.Box (new Rect (0, 0, Screen.width / 2 - bufferArea, Screen.height / 2 - bufferArea), "");
		GUI.Label (new Rect (3 * bufferArea + buttonWidth, 0, buttonWidth, buttonHeight), EnumStrings[(int)player1SelectedType]);

		// part types
		GUI.BeginGroup (new Rect (bufferArea, bufferArea, buttonWidth, buttonHeight * 4 + bufferArea * 3));
		//GUI.Box (new Rect (0, 0, buttonWidth, buttonHeight * 4 + buttonSpacing * 3), "");

		for(int i = 1; i < 5; i++)
		{
			bool clicked = false;
			if((SelectedArea)(i) == player1SelectedType)
			{
				clicked = GUI.Button(new Rect(0,
				                              (buttonSpacing + buttonHeight) * (i - 1),
				                              buttonWidth,
				                              buttonHeight),
				                     EnumStrings[i],
				                     skin.customStyles[0]);
			}
			else
			{
				clicked = GUI.Button(new Rect(0,
			                                  (buttonSpacing + buttonHeight) * (i - 1),
			                                  buttonWidth,
			                                  buttonHeight),
				                     EnumStrings[i]);
			}
			if(clicked)
			{
				player1SelectedType = (SelectedArea)(i);
				player1Picking = true;
			}
		}
		GUI.EndGroup();

		// parts selected
		GUI.BeginGroup (new Rect (Screen.width / 6, bufferArea, buttonWidth + buttonSpacing * 2, buttonHeight * 5 + bufferArea * 4));
		//GUI.Box (new Rect (0, 0, buttonWidth + buttonSpacing * 2, buttonHeight * 4 + buttonSpacing * 3), "");
		for(int i = 1; i < 5; i++)
		{
			string partname = partLists[i - 1][player1SelectedParts[i]].partName;
			GUI.Button(new Rect(0,
			                    (buttonSpacing + buttonHeight) * (i -1),
			                    buttonWidth,
			                    buttonHeight),
			           partname,
			           skin.customStyles[1]);
		}
		GUI.EndGroup();

		// part options
		GUI.BeginGroup (new Rect ((int)(Screen.width / 3.05), bufferArea - buttonSpacing / 2, buttonWidth + buttonSpacing * 1, buttonHeight * 4 + buttonSpacing * 3 + buttonSpacing));
		GUI.Box (new Rect (0, 0, buttonWidth + buttonSpacing * 1, buttonHeight * 4 + buttonSpacing * 3 + buttonSpacing), "");
		if (player1SelectedType == SelectedArea.Selector) {
			
		}
		else
		{
			for(int i = 1; i < 5; i++)
			{
				if(player1SelectedType == (SelectedArea)(i))
				{
					List<PartData> parts = partLists[i - 1];
					for(int j = 0; j < parts.Count; j++)
					{
						bool clicked = false;
						if(player1Picking && player1SelectedParts[i] == j)
						{
							clicked = GUI.Button(new Rect(buttonSpacing / 2,
							                              buttonSpacing / 2 + (buttonSpacing + buttonHeight) * (j),
							                              buttonWidth,
							                              buttonHeight),
							                     parts[j].partName,
							                     skin.customStyles[0]);
						}
						else
						{
							clicked = GUI.Button(new Rect(buttonSpacing / 2,
							                              buttonSpacing / 2 + (buttonSpacing + buttonHeight) * (j),
							                              buttonWidth,
							                              buttonHeight),
							                     parts[j].partName);
						}
						if(clicked)
						{
							player1SelectedParts[i] = j;
							player1Picking = true;
							string partName = partLists[i - 1][player1SelectedParts[i]].partName;
							Debug.Log ("Player 1 selected " + partLists[i - 1][player1SelectedParts[i]].partName);

							// new body
							if(i == 1)
							{
								AddRobot(1, partName);
							}

							// left arm
							if(i == 2)
							{
								AddItemToRobot(1, "left_arm", "LeftWeapon", partName);
							}

							// right arm
							if(i == 3)
							{
								AddItemToRobot(1, "right_arm", "RightWeapon", partName);
							}

							// special
							if(i == 4)
							{
								RemoveSpecial(1);
								if(partName == "Wings") AddItemToRobot(1, "body", "Wings", partName);
								if(partName == "Armor") AddItemToRobot(1, "body", "Armor", partName);
								if(partName == "Booster") AddItemToRobot(1, "body", "Wings", partName);
							}
						}
					}
					break;
				}
			}
		}
		GUI.EndGroup();
		string description1 = "";
		string name1 = "";
		if(player1SelectedType != SelectedArea.Selector && player1Picking)
		{
			name1 = partLists[(int)(player1SelectedType) - 1][player1SelectedParts[(int)player1SelectedType]].partName;
			description1 = partLists[(int)(player1SelectedType) - 1][player1SelectedParts[(int)player1SelectedType]].description;
		}

		GUI.BeginGroup(new Rect (Screen.width / 6, bufferArea + (buttonSpacing + buttonHeight) * 4, boxWidth, boxHeight));
		GUI.Box (new Rect (0, 0, boxWidth, boxHeight), name1);
		GUI.Label(new Rect (buttonSpacing / 2, buttonSpacing * 2, boxWidth - buttonSpacing, boxHeight - buttonSpacing * 2), description1);
		GUI.EndGroup();

		// colors
		GUI.BeginGroup(new Rect (bufferArea, bufferArea + (buttonSpacing + buttonHeight) * 4, buttonWidth, boxHeight));
		GUI.Box (new Rect (0, 0, buttonWidth, boxHeight), "Colors");
		GUI.Label(new Rect (buttonSpacing / 2, buttonSpacing * 2, buttonWidth /2 , buttonHeight), "Primary");
		GUI.Box  (new Rect (buttonWidth / 2 + buttonSpacing, buttonSpacing * 2, buttonWidth / 3 , buttonHeight / 2), "", skin.customStyles[2]);
		GUI.Label(new Rect (buttonSpacing / 2, buttonSpacing * 4, buttonWidth /2 , buttonHeight), "Secondary");
		GUI.Box  (new Rect (buttonWidth / 2 + buttonSpacing, buttonSpacing * 4, buttonWidth / 3 , buttonHeight / 2), "", skin.customStyles[3]);
		GUI.EndGroup();

		// End Top Left Quadrant
		GUI.EndGroup();

		//---------------------------------------------------------------------------------------------------------------------------------------
		// Bottom Left Quad
		// End Bottom Left Quad
	}

	private void RemoveSpecial(int robotNum)
	{
		Transform hardpoint;
		if(robotNum == 1) hardpoint = player1Robot.transform.FindChild("body").FindChild("Wings");
		else hardpoint = player2Robot.transform.FindChild("body").FindChild("Wings");

		foreach(Transform child in hardpoint)
		{
			Destroy(child.gameObject);
		}

		if(robotNum == 1) hardpoint = player1Robot.transform.FindChild("body").FindChild("Armor");
		else hardpoint = player2Robot.transform.FindChild("body").FindChild("Armor");

		foreach(Transform child in hardpoint)
		{
			Destroy(child.gameObject);
		}
	}

	private void AddRobot(int robotNum, string partName)
	{
		if (robotNum == 1)
		{
			Debug.Log ("Creating a " + partName + " for player 1.");
			if(player1Robot != null) Destroy (player1Robot);
			player1Robot = (GameObject) Instantiate(Resources.Load ("Body/" + partName),
			                                       Vector3.zero, Quaternion.identity);

			if(partName == "Astro") player1Robot.transform.position = new Vector3(0,-6,0);
			else if(partName == "Salsa") player1Robot.transform.position = new Vector3(0,-10,0);
			else if(partName == "HummingBird") player1Robot.transform.position = new Vector3(0,-6,0);
			else if(partName == "Matron") player1Robot.transform.position = new Vector3(0,-6,0);

			player1Robot.layer = LayerMask.NameToLayer ("Player1");
			foreach (Transform child in player1Robot.transform) child.gameObject.layer = LayerMask.NameToLayer ("Player1");

			UpdateParts(1);
		}
		else
		{
			Debug.Log ("Creating a " + partName + " for player 2.");
			if(player2Robot != null) Destroy (player2Robot);
			player2Robot = (GameObject) Instantiate(Resources.Load ("Body/" + partName),
			                                        Vector3.zero, Quaternion.identity);
			
			if(partName == "Astro") player2Robot.transform.position = new Vector3(0,-6,0);
			else if(partName == "Salsa") player2Robot.transform.position = new Vector3(0,-10,0);
			else if(partName == "HummingBird") player2Robot.transform.position = new Vector3(0,-6,0);
			else if(partName == "Matron") player2Robot.transform.position = new Vector3(0,-6,0);
			
			player2Robot.layer = LayerMask.NameToLayer ("Player2");
			foreach (Transform child in player2Robot.transform) child.gameObject.layer = LayerMask.NameToLayer ("Player2");
			
			UpdateParts(1);
		}
	}

	private void UpdateParts(int robotNum)
	{
		if (robotNum == 1)
		{
			Debug.Log ("Updating robot components for player 1");
			for(int i = 2; i < 5; i++)
			{
				string partName = partLists[i - 1][player1SelectedParts[i]].partName;
				Debug.Log ("Adding " + partName);

				if(i == 2)
				{
					AddItemToRobot(1, "left_arm", "LeftWeapon", partName);
				}
				
				// right arm
				if(i == 3)
				{
					AddItemToRobot(1, "right_arm", "RightWeapon", partName);
				}
				
				// special
				if(i == 4)
				{
					RemoveSpecial(1);
					if(partName == "Wings") AddItemToRobot(1, "body", "Wings", partName);
					if(partName == "Armor") AddItemToRobot(1, "body", "Armor", partName);
					if(partName == "Booster") AddItemToRobot(1, "body", "Wings", partName);
				}
			}
		}
		else
		{
			Debug.Log ("Updating robot components for player 2");
			for(int i = 2; i < 5; i++)
			{
				string partName = partLists[i - 1][player2SelectedParts[i]].partName;
				Debug.Log ("Adding " + partName);

				if(i == 2)
				{
					AddItemToRobot(2, "left_arm", "LeftWeapon", partName);
				}
				
				// right arm
				if(i == 3)
				{
					AddItemToRobot(2, "right_arm", "RightWeapon", partName);
				}
				
				// special
				if(i == 4)
				{
					RemoveSpecial(2);
					if(partName == "Wings") AddItemToRobot(2, "body", "Wings", partName);
					if(partName == "Armor") AddItemToRobot(2, "body", "Armor", partName);
					if(partName == "Booster") AddItemToRobot(2, "body", "Wings", partName);
				}
			}
		}
	}

	private void AddItemToRobot(int robotNum, string location, string hardpointname, string partName)
	{
		// get hard point
		Transform hardpoint;
		if(robotNum == 1) hardpoint = player1Robot.transform.FindChild(location).FindChild(hardpointname);
		else hardpoint = player2Robot.transform.FindChild(location).FindChild(hardpointname);

		// delete old one
		foreach(Transform child in hardpoint)
		{
			Destroy(child.gameObject);
		}
		
		// Instantiate the add on object as gameobject
		Debug.Log ("Creating from " + "Prefabs/" + partName );
		GameObject weap = (GameObject) Instantiate(Resources.Load ("Prefabs/" + partName),
		                                           Vector3.zero, Quaternion.identity);

		// put it in its place, set its orientation and parent
		weap.transform.position = hardpoint.position;
		weap.transform.rotation = hardpoint.rotation;
		weap.transform.parent = hardpoint;

		// set camera layer
		if (robotNum == 1) {
			weap.layer = LayerMask.NameToLayer ("Player1");
			foreach (Transform child in weap.transform) child.gameObject.layer = LayerMask.NameToLayer ("Player1");
		} else {
			weap.layer = LayerMask.NameToLayer ("Player2");
			foreach(Transform child in weap.transform) child.gameObject.layer = LayerMask.NameToLayer ("Player2");
		}
		Debug.Log ("Created.");
	}
}
