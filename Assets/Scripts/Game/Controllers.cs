using UnityEngine;
using System.Collections;

public class Controllers : MonoBehaviour
{
	float[] timers1;
	float[] inputs1;
	float[] timedInputs1;

	float[] timers2;
	float[] inputs2;
	float[] timedInputs2;

	float timer = 0.15f;

	static string[] inputNames = {"A", "B", "X", "Y", "LTrig", "RTrig",
								  "LJoyH", "LJoyV", "RJoyH", "RJoyV",
								  "LBump", "RBump", "Start"};

	public Transform robo;
	
	public Robo robo1;
	public Robo robo2;

	Vector3 startPos1 = new Vector3(-25, 8, 25);
	Vector3 startPos2 = new Vector3(25, 8, -25);

	void Start ()
	{
		inputs1 = new float[13];
		timedInputs1 = new float[13];
		timers1 = new float[13];

		inputs2 = new float[13];
		timedInputs2 = new float[13];
		timers2 = new float[13];

		Transform newRobo = Instantiate(robo, startPos1, Quaternion.identity) as Transform;
		robo1 = newRobo.GetComponent<Robo>();

		newRobo = Instantiate(robo, startPos2, Quaternion.identity) as Transform;
		robo2 = newRobo.GetComponent<Robo>();



		robo1.CustomizeRobot(Utility.player1Body,
		                     Utility.player1LeftWeapon,
		                     Utility.player1RightWeapon,
		                     Utility.player1Special,
		                     Utility.player1Primary,
		                     Utility.player1Secondary,
		                     robo2.transform);

		robo2.CustomizeRobot(Utility.player2Body,
		                     Utility.player2LeftWeapon,
		                     Utility.player2RightWeapon,
		                     Utility.player2Special,
		                     Utility.player2Primary,
		                     Utility.player2Secondary,
		                     robo1.transform);
	}

	void Update ()
	{
		GetControllers();
		GetKeyBoard();

		if(Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	void GetKeyBoard()
	{
		if(Input.GetAxis("Jump") != 0.0f)
		{
			robo2.Jump();
		}
		if(Input.GetKey(KeyCode.Period))
			robo2.FireRight();
		
		if(Input.GetKey(KeyCode.Comma))
			robo2.FireLeft();

		Vector3 cameraForward = transform.forward;
		cameraForward.y = 0;
		cameraForward.Normalize();
		float angle = Vector3.Angle(Vector3.forward, cameraForward);
		if(Vector3.Cross(Vector3.forward, cameraForward).y < 0)
		{
			angle = -angle;
		}
		Vector3 playerMove = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		playerMove = Quaternion.AngleAxis(angle, Vector3.up) * playerMove;
		robo2.Move(playerMove);
		
		if(Input.GetKey (KeyCode.Q) || Input.GetKey (KeyCode.E))
			robo2.Thrust(playerMove);
	}

	void GetControllers()
	{
		GetOSXInputsXbox();
//		GetOSXInputsPS3();

//		GetWinInputsXbox();
//		GetWinInputsPS3();

		if(A1 != 0.0f)
			robo1.Jump();
		if(RTrig1 != 0.0f && RTrig1 != -1.0f)
			robo1.FireRight();
		if(LTrig1 != 0.0f  && LTrig1 != -1.0f)
			robo1.FireLeft();

		Vector3 player1Move = Quaternion.AngleAxis(transform.rotation.y, Vector3.up) * new Vector3(LJoyH1, 0, LJoyV1);
		robo1.Move(player1Move);

		if(RBump1 != 0.0f || LBump1 != 0.0f)
			robo1.Thrust(player1Move);

		if(A2 != 0.0f)
			robo2.Jump();
		if(RTrig2 != 0.0f && RTrig2 != -1.0f)
			robo2.FireRight();
		if(LTrig2 != 0.0f  && LTrig2 != -1.0f)
			robo2.FireLeft();

		Vector3 player2Move = Quaternion.AngleAxis(transform.rotation.y, Vector3.up) * new Vector3(LJoyH2, 0, LJoyV2);
		robo2.Move(player2Move);
		
		if(RBump2 != 0.0f || LBump2 != 0.0f)
			robo2.Thrust(player2Move);
	}

	void GetOSXInputsXbox()
	{
		//Debug.Log ("Input A1 :" + Input.GetAxis("OSX Xbox A1"));
		A1 = Input.GetAxis("OSX Xbox A1");
		//Debug.Log ("Reading A1 :" + A1);
		B1 = Input.GetAxis("OSX Xbox B1");
		X1 = Input.GetAxis("OSX Xbox X1");
		Y1 = Input.GetAxis("OSX Xbox Y1");
		LJoyH1 = Input.GetAxis("OSX LJoyH1");
		LJoyV1 = Input.GetAxis("OSX LJoyV1");
		RJoyH1 = Input.GetAxis("OSX Xbox RJoyH1");
		RJoyV1 = Input.GetAxis("OSX Xbox RJoyV1");
		LTrig1 = Input.GetAxis("OSX Xbox LTrig1");
		RTrig1 = Input.GetAxis("OSX Xbox RTrig1");
		LBump1 = Input.GetAxis("OSX Xbox LBump1");
		RBump1 = Input.GetAxis("OSX Xbox RBump1");
		StartButton1 = Input.GetAxis("OSX Xbox Start1");

		/*Debug.Log ("Input A2 :" + Input.GetAxis("OSX Xbox A2"));
		A2 = Input.GetAxis("OSX Xbox A2");
		Debug.Log ("Reading A2 :" + A2);
		B2 = Input.GetAxis("OSX Xbox B2");
		X2 = Input.GetAxis("OSX Xbox X2");
		Y2 = Input.GetAxis("OSX Xbox Y2");
		LJoyH2 = Input.GetAxis("OSX LJoyH2");
		LJoyV2 = Input.GetAxis("OSX LJoyV2");
		RJoyH2 = Input.GetAxis("OSX Xbox RJoyH2");
		RJoyV2 = Input.GetAxis("OSX Xbox RJoyV2");
		LTrig2 = Input.GetAxis("OSX Xbox LTrig2");
		RTrig2 = Input.GetAxis("OSX Xbox RTrig2");
		LBump2 = Input.GetAxis("OSX Xbox LBump2");
		RBump2 = Input.GetAxis("OSX Xbox RBump2");
		StartButton2 = Input.GetAxis("OSX Xbox Start2");*/
	}

	void GetOSXInputsPS3()
	{
		A1 = Input.GetAxis("OSX PS3 A1");
		B1 = Input.GetAxis("OSX PS3 B1");
		X1 = Input.GetAxis("OSX PS3 X1");
		Y1 = Input.GetAxis("OSX PS3 Y1");
		LJoyH1 = Input.GetAxis("OSX LJoyH1");
		LJoyV1 = Input.GetAxis("OSX LJoyV1");
		RJoyH1 = Input.GetAxis("OSX PS3 RJoyH1");
		RJoyV1 = Input.GetAxis("OSX PS3 RJoyV1");
		LTrig1 = Input.GetAxis("OSX PS3 LTrig1");
		RTrig1 = Input.GetAxis("OSX PS3 RTrig1");
		LBump1 = Input.GetAxis("OSX PS3 LBump1");
		RBump1 = Input.GetAxis("OSX PS3 RBump1");
		StartButton1 = Input.GetAxis("OSX PS3 Start1");

		A2 = Input.GetAxis("OSX PS3 A2");
		B2 = Input.GetAxis("OSX PS3 B2");
		X2 = Input.GetAxis("OSX PS3 X2");
		Y2 = Input.GetAxis("OSX PS3 Y2");
		LJoyH2 = Input.GetAxis("OSX LJoyH2");
		LJoyV2 = Input.GetAxis("OSX LJoyV2");
		RJoyH2 = Input.GetAxis("OSX PS3 RJoyH2");
		RJoyV2 = Input.GetAxis("OSX PS3 RJoyV2");
		LTrig2 = Input.GetAxis("OSX PS3 LTrig2");
		RTrig2 = Input.GetAxis("OSX PS3 RTrig2");
		LBump2 = Input.GetAxis("OSX PS3 LBump2");
		RBump2 = Input.GetAxis("OSX PS3 RBump2");
		StartButton2 = Input.GetAxis("OSX PS3 Start2");
	}

	void GetWinInputsPS3()
	{

	}

	void GetWinInputsXbox()
	{
		
	}

	float _A1
	{
		get{
			return timedInputs1[(int)InputKeys.A];
		}
	}
	
	float _B1
	{
		get{return timedInputs1[(int)InputKeys.B];}
	}
	
	float _X1
	{
		get{return timedInputs1[(int)InputKeys.X];}
	}
	
	float _Y1
	{
		get{return timedInputs1[(int)InputKeys.Y];}
	}
	
	float _StartButton1
	{
		get{return timedInputs1[(int)InputKeys.Start];}
	}
	
	float _LTrig1
	{
		get{return timedInputs1[(int)InputKeys.LTrig];}
	}
	
	float _RTrig1
	{
		get{return timedInputs1[(int)InputKeys.RTrig];}
	}
	
	float _LBump1
	{
		get{return timedInputs1[(int)InputKeys.LBump];}
	}
	
	float _RBump1
	{
		get{return timedInputs1[(int)InputKeys.RBump];}
	}
	
	float _LJoyH1
	{
		get{return timedInputs1[(int)InputKeys.LJoyH];}
	}
	
	float _LJoyV1
	{
		get{return timedInputs1[(int)InputKeys.LJoyV];}
	}
	
	float _RJoyH1
	{
		get{return timedInputs1[(int)InputKeys.RJoyH];}
	}
	
	float _RJoyV1
	{
		get{return timedInputs1[(int)InputKeys.RJoyV];}
	}

	float A1
	{
		get{return inputs1[(int)InputKeys.A];}

		set{InputUpdate1((int)InputKeys.A, value);}
	}

	float B1
	{
		get{return inputs1[(int)InputKeys.B];}

		set{InputUpdate1((int)InputKeys.B, value);}
	}

	float X1
	{
		get{return inputs1[(int)InputKeys.X];}
		
		set{InputUpdate1((int)InputKeys.X, value);}
	}

	float Y1
	{
		get{return inputs1[(int)InputKeys.Y];}
		
		set{InputUpdate1((int)InputKeys.Y, value);}
	}

	float StartButton1
	{
		get{return inputs1[(int)InputKeys.Start];}
		
		set{InputUpdate1((int)InputKeys.Start, value);}
	}

	float LTrig1
	{
		get{return inputs1[(int)InputKeys.LTrig];}
		
		set{InputUpdate1((int)InputKeys.LTrig, value, -1.0f);}
	}

	float RTrig1
	{
		get{return inputs1[(int)InputKeys.RTrig];}
		
		set{InputUpdate1((int)InputKeys.RTrig, value, -1.0f);}
	}

	float LBump1
	{
		get{return inputs1[(int)InputKeys.LBump];}
		
		set{InputUpdate1((int)InputKeys.LBump, value);}
	}

	float RBump1
	{
		get{return inputs1[(int)InputKeys.RBump];}
		
		set{InputUpdate1((int)InputKeys.RBump, value);}
	}

	float LJoyH1
	{
		get{return inputs1[(int)InputKeys.LJoyH];}
		
		set{InputUpdate1((int)InputKeys.LJoyH, value);}
	}

	float LJoyV1
	{
		get{return inputs1[(int)InputKeys.LJoyV];}
		
		set{InputUpdate1((int)InputKeys.LJoyV, value);}
	}

	float RJoyH1
	{
		get{return inputs1[(int)InputKeys.RJoyH];}
		
		set{InputUpdate1((int)InputKeys.RJoyH, value);}
	}
	
	float RJoyV1
	{
		get{return inputs1[(int)InputKeys.RJoyV];}
		
		set{InputUpdate1((int)InputKeys.RJoyV, value);}
	}

	void InputUpdate1(int index, float value, float altVal = 0.0f)
	{
		inputs1[index] = value;
		if(timers1[index] <= 0.0f)
		{
			timedInputs1[index] = value;
			if(value == altVal)
				timedInputs1[index] = 0.0f;

			if(value != 0.0f && value != altVal)
				timers1[index] = timer;
		}
		else
		{
			timedInputs1[index] = 0.0f;
			timers1[index] -= Time.deltaTime;
		}
	}

	float _A2
	{
		get{
			return timedInputs2[(int)InputKeys.A];
		}
	}
	
	float _B2
	{
		get{return timedInputs2[(int)InputKeys.B];}
	}
	
	float _X2
	{
		get{return timedInputs2[(int)InputKeys.X];}
	}
	
	float _Y2
	{
		get{return timedInputs2[(int)InputKeys.Y];}
	}
	
	float _StartButton2
	{
		get{return timedInputs2[(int)InputKeys.Start];}
	}
	
	float _LTrig2
	{
		get{return timedInputs2[(int)InputKeys.LTrig];}
	}
	
	float _RTrig2
	{
		get{return timedInputs2[(int)InputKeys.RTrig];}
	}
	
	float _LBump2
	{
		get{return timedInputs2[(int)InputKeys.LBump];}
	}
	
	float _RBump2
	{
		get{return timedInputs2[(int)InputKeys.RBump];}
	}
	
	float _LJoyH2
	{
		get{return timedInputs2[(int)InputKeys.LJoyH];}
	}
	
	float _LJoyV2
	{
		get{return timedInputs2[(int)InputKeys.LJoyV];}
	}
	
	float _RJoyH2
	{
		get{return timedInputs2[(int)InputKeys.RJoyH];}
	}
	
	float _RJoyV2
	{
		get{return timedInputs2[(int)InputKeys.RJoyV];}
	}
	
	float A2
	{
		get{return inputs2[(int)InputKeys.A];}
		
		set{InputUpdate2((int)InputKeys.A, value);}
	}
	
	float B2
	{
		get{return inputs2[(int)InputKeys.B];}
		
		set{InputUpdate2((int)InputKeys.B, value);}
	}
	
	float X2
	{
		get{return inputs2[(int)InputKeys.X];}
		
		set{InputUpdate2((int)InputKeys.X, value);}
	}
	
	float Y2
	{
		get{return inputs2[(int)InputKeys.Y];}
		
		set{InputUpdate2((int)InputKeys.Y, value);}
	}
	
	float StartButton2
	{
		get{return inputs2[(int)InputKeys.Start];}
		
		set{InputUpdate2((int)InputKeys.Start, value);}
	}
	
	float LTrig2
	{
		get{return inputs2[(int)InputKeys.LTrig];}
		
		set{InputUpdate2((int)InputKeys.LTrig, value, -1.0f);}
	}
	
	float RTrig2
	{
		get{return inputs2[(int)InputKeys.RTrig];}
		
		set{InputUpdate2((int)InputKeys.RTrig, value, -1.0f);}
	}
	
	float LBump2
	{
		get{return inputs2[(int)InputKeys.LBump];}
		
		set{InputUpdate2((int)InputKeys.LBump, value);}
	}
	
	float RBump2
	{
		get{return inputs2[(int)InputKeys.RBump];}
		
		set{InputUpdate2((int)InputKeys.RBump, value);}
	}
	
	float LJoyH2
	{
		get{return inputs2[(int)InputKeys.LJoyH];}
		
		set{InputUpdate2((int)InputKeys.LJoyH, value);}
	}
	
	float LJoyV2
	{
		get{return inputs2[(int)InputKeys.LJoyV];}
		
		set{InputUpdate2((int)InputKeys.LJoyV, value);}
	}
	
	float RJoyH2
	{
		get{return inputs2[(int)InputKeys.RJoyH];}
		
		set{InputUpdate2((int)InputKeys.RJoyH, value);}
	}
	
	float RJoyV2
	{
		get{return inputs2[(int)InputKeys.RJoyV];}
		
		set{InputUpdate2((int)InputKeys.RJoyV, value);}
	}

	void InputUpdate2(int index, float value, float altVal = 0.0f)
	{
		inputs2[index] = value;
		if(timers2[index] <= 0.0f)
		{
			timedInputs2[index] = value;
			if(value == altVal)
				timedInputs2[index] = 0.0f;
			
			if(value != 0.0f && value != altVal)
				timers2[index] = timer;
		}
		else
		{
			timedInputs2[index] = 0.0f;
			timers2[index] -= Time.deltaTime;
		}
	}
}

public enum InputKeys : int
{
	A = 0, B, X, Y, LTrig, RTrig,
	LJoyH, LJoyV, RJoyH, RJoyV,
	LBump, RBump, Start
}




