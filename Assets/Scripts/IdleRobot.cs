using UnityEngine;
using System.Collections;

public class IdleRobot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!this.animation.isPlaying) this.animation.Play ("Idle");
	}
}
