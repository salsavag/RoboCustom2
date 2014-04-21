using UnityEngine;
using System.Collections;

public class TriShot : Weapon {

	bool secondShot;
	bool thirdShot;

	protected override void Start () {
		base.Start();
		projSpeed = 40.0f;
		damage = 20.0f;
		fireRate = 2.0f;
		thirdShot = false;
		secondShot = false;
	}

	protected override void Update () {
		base.Update();
		if(coolDown <= 1.85 && !secondShot)
		{
			secondShot = true;
			CreateProj();
		}
		else if(coolDown <= 1.7f && !thirdShot)
		{
			thirdShot = true;
			CreateProj();
		}
	}

	override public void Fire()
	{
		if(coolDown <= 0.0f)
		{
			CreateProj();
			coolDown = fireRate;
			secondShot = false;
			thirdShot = false;
		}
	}
}
