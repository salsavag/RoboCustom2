using UnityEngine;
using System.Collections;

public class IdleRobot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(animation["Idel"])
		{
			if(!animation.IsPlaying("Idle"))
				this.animation.Play ("Idle");
		}
	}
}
