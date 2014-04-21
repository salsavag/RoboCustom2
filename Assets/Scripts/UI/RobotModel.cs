using UnityEngine;
using System.Collections;

public class RobotModel : MonoBehaviour {

	public Color primary;
	public Color secondary;

	void Start ()
	{
		Utility.SetPrimary(gameObject, primary);
		Utility.SetSecondary(gameObject, secondary);
	}

	void Update()
	{

	}
}
