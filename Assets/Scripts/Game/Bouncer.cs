using UnityEngine;
using System.Collections;

public class Bouncer : Weapon {

	// Use this for initialization
	protected override void Start () {
		base.Start();
		projSpeed = 30.0f;
		damage = 50.0f;
		fireRate = 3.0f;
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
	}
	
	protected override void FireProj()
	{
		CreateProj();
	}
}
