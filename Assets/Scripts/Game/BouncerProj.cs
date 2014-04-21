using UnityEngine;
using System.Collections;

public class BouncerProj : Projectile
{
	float liveTimer;
	float dropRate;
	public float liveTime;

	void Start () {
		speed = 30.0f;
		damage = 50.0f;
		explosionRadius = 0.0f;
		liveTimer = liveTime;
		dropRate = 4.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		liveTimer -= Time.deltaTime;
		if(liveTimer < 0.0f)
		{
			Destroy(this.gameObject);
		}
		rigidbody.velocity = rigidbody.velocity.normalized * speed;
		if(transform.position.y > 6.0f)
		{
			Vector3 pos = transform.position;
			pos.y -= dropRate * Time.deltaTime;
			transform.position = pos;
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Robo")
		{
			Robo hitRobo = collision.gameObject.GetComponent<Robo>();
			if(hitRobo != robo)
			{
				hitRobo.ApplyDamage(damage);
				Destroy(gameObject);
			}
		}
		else if(collision.gameObject.tag != "Proj")
		{
			Debug.Log("bounce");
		}
	}
	
	protected virtual void OnTriggerEnter(Collider collision)
	{
		return;
	}
}
