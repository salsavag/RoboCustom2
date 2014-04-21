using UnityEngine;
using System.Collections;

public class Robo : MonoBehaviour
{	
	bool grounded;
	public float jumpSpeed = 20.0f;
	public float moveSpeed = 2.0f;

	public float projSpeed;
	public Transform projectile;
	public Weapon RightWeapon;
	public Weapon LeftWeapon;
	public float fireRate;
	public Transform enemyBot;

	public float health;
	float leftFireTimer = 0.0f;
	float rightFireTimer = 0.0f;

	bool thrusting;
	float thrustTimer;
	float thrustStart;
	Vector3 thrustDir;

	public float thrustCD;
	public float thrustTime;
	public float thrustSpeed;

	void Start () {
		health = 300.0f;
		grounded = false;
		thrusting = false;
		thrustTimer = 0.0f;
		thrustStart = 0.0f;
	}

	void FixedUpdate()
	{
		transform.rigidbody.angularVelocity = Vector3.zero;
	}

	void Update () {
		Vector3 toward = new Vector3(enemyBot.position.x, transform.position.y, enemyBot.position.z) - transform.position;
		float angle = Vector3.Angle(transform.forward, toward) * Mathf.Sign(Vector3.Cross(transform.forward, toward).y);
		
		transform.RotateAround(transform.position, Vector3.up, angle);
		if(leftFireTimer > 0.0f)
			leftFireTimer -= Time.deltaTime;
		if(rightFireTimer > 0.0f)
			rightFireTimer -= Time.deltaTime;

		if(thrustTimer > 0.0f)
		{
			thrustTimer -= Time.deltaTime;
			thrustStart -= Time.deltaTime;
			if(thrustStart <= 0.0f)
				thrusting = false;
			else
			{
				Vector3 vel = (thrustDir.normalized * thrustSpeed);
				vel.y = transform.rigidbody.velocity.y;
				transform.rigidbody.velocity = vel;
			}
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Ground")
			grounded = true;
	}

	void OnCollisionExit(Collision collision)
	{
		if(collision.gameObject.tag == "Ground")
			grounded = false;
	}

	public void FireLeft()
	{
		LeftWeapon.Fire();
	}


	public void FireRight()
	{
		RightWeapon.Fire();
	}

	public void Jump()
	{
		if(grounded && !thrusting)
		{
			Vector3 vel = transform.rigidbody.velocity;
			vel.y = jumpSpeed;
			transform.rigidbody.velocity = vel;
		}
	}

	public void Move(Vector3 dir)
	{
		if(!thrusting)
		{
			Vector3 vel = (dir.normalized * moveSpeed);
			vel.y = transform.rigidbody.velocity.y;
			transform.rigidbody.velocity = vel;
		}
	}

	public void ApplyDamage(float damage)
	{
		health -= damage;
	}

	public void Thrust(Vector3 dir)
	{
		if(thrustTimer <= thrustCD && !thrusting && dir.magnitude > 0.1f)
		{
			thrustDir = dir;
			thrustTimer += thrustCD;
			thrusting = true;
			thrustStart = thrustTime;
		}
	}
}
