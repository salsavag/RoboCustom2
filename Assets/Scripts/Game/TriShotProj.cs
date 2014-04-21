using UnityEngine;
using System.Collections;

public class TriShotProj : Projectile {
	
	void Start () {
		speed = 40.0f;
		damage = 20.0f;
		explosionRadius = 0.0f;
		target = null;
	}

	void Update () {

	}

	protected override void Explode ()
	{
		base.Explode ();
	}
}
