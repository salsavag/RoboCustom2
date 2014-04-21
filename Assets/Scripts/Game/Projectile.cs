using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	protected float speed;
	protected float damage;
	protected float explosionRadius;
	public Transform target;
	protected Robo robo;

	protected bool init = false;

	public void Init(float _speed, float _damage, Robo _robo, Transform _target)
	{
		speed = _speed;
		damage = _damage;
		robo = _robo;
		target = _target;
		gameObject.rigidbody.velocity = gameObject.transform.forward * speed;
		init = true;
	}

	void Start () {

	}

	void Update () {

	}

	protected virtual void Explode()
	{

	}

	protected virtual void OnTriggerEnter(Collider collision)
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
			Destroy(gameObject);
		}
	}
}
