﻿using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public Transform proj;
	public float fireRate;
	public float damage;
	public float projSpeed;
	protected float coolDown;

	public Transform firePos;

	public Transform target;

	protected virtual void Start () {
		coolDown = 0.0f;
		target = transform.parent.GetComponent<Robo>().enemyBot;
	}

	protected virtual void Update () {
		if(coolDown > 0.0f)
			coolDown -= Time.deltaTime;

		transform.LookAt(target);
	}

	public virtual void Fire()
	{
		if(coolDown <= 0.0f)
		{
			CreateProj();
			coolDown = fireRate;
		}
	}

	protected void CreateProj()
	{
		Transform newProj = GameObject.Instantiate(proj, firePos.position, firePos.rotation) as Transform;
		Projectile projComp = newProj.GetComponent<Projectile>();
		projComp.Init(projSpeed, damage, transform.parent.GetComponent<Robo>(), target);
	}
}
