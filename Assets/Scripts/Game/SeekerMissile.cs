using UnityEngine;
using System.Collections;

public class SeekerMissile : Projectile {

	bool atPeak;
	bool start;
	public Vector3 peak;
	public Vector3 dest;
	public float height = 20.0f;

	void Start () {
		speed = 60.0f;
		damage = 50.0f;
		explosionRadius = 0.0f;
		height = 20.0f;
		atPeak = false;
		peak = (target.position + transform.position) / 2;
		peak.y = height;
		transform.LookAt(peak);
		transform.rigidbody.velocity = transform.forward.normalized * speed;
		dest = target.position;
	}
	
	// Update is called once per frame
	void Update () {

		if(!atPeak)
		{
			transform.LookAt(peak);
			if((transform.position - peak).magnitude <= 0.8f)
			{
				atPeak = true;
				transform.LookAt(dest);
			}
		}
		transform.rigidbody.velocity = transform.forward.normalized * speed;
	}
}
