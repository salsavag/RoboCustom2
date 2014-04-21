using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour
{
	public float rotateSpeed = 10.0f;
	public float manualSpeed = 40.0f;
	public Vector3 rotatePoint;

	void Start () {
		rotatePoint.y = -6;
		rotatePoint.x = 0;
		rotatePoint.z = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Rotate(rotateSpeed);
	}

	public void Rotate(float speed, bool ccw = false)
	{
		if(ccw)
			speed = -(speed + 2 * rotateSpeed);
		transform.LookAt(rotatePoint);
		transform.RotateAround(rotatePoint, Vector3.up, Time.deltaTime * speed);
	}
}
