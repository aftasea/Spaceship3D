using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
	[SerializeField]
	private float speed;
	[SerializeField]
	private float rotationAngle;

	private Rigidbody rigidBody;
	private Transform myTransform;

	private Vector3 dir = Vector3.zero;
	private float destAngle = 0f;

	private void Awake()
	{
		rigidBody = GetComponent<Rigidbody>();
		myTransform = transform;
	}

	private void Update()
	{
		dir = Vector3.zero;
		destAngle = 0;

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			dir.x += -1;
			destAngle = rotationAngle;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			dir.x = 1;
			destAngle = -rotationAngle;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			dir.y = -1;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			dir.y = 1;
		}

		if (dir != Vector3.zero)
			Move();

		Rotate(rotationAngle);
	}

	private void Move()
	{
		Vector3 velocity = dir * speed * Time.deltaTime;
		rigidBody.MovePosition(myTransform.position + velocity);
	}

	private void Rotate(float angle)
	{
		Vector3 currentRotation = rigidBody.rotation.eulerAngles;
		if (currentRotation.z > -rotationAngle && currentRotation.z < rotationAngle)
		{
			//Quaternion rotation = Quaternion.Euler(0, 0, angle * Time.deltaTime);
			//rigidBody.MoveRotation(rotation);

		}


		//float evalTimeX = (dir.x + 1) / 2f;
		//float rotationZ = Mathf.Lerp(rotationAngle, -rotationAngle, evalTimeX);

		//float evalTimeY = (dir.y + 1) / 2f;
		//float rotationX = Mathf.Lerp(rotationAngle, -rotationAngle, evalTimeY);

		//Quaternion rotation = Quaternion.Euler(rotationX, 0, rotationZ);
		//rigidBody.MoveRotation(rotation);
	}
}
