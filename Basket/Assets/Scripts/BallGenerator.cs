using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
	public GameObject ballPrefab;
	public GameObject ballHolder;

	public float shotSpeed;
	public float shotTorque;
	public float basewidth;
	public float x_position;
	public float y_position;
	public float z_position;

	private Vector3 clickPosition; 


    void Update()
    {
		if (Input.GetMouseButtonDown(0)) {

			clickPosition = Input.mousePosition;
			clickPosition.z = 1.0f;

			GameObject ball = Instantiate(
				ballPrefab,
				Camera.main.ScreenToWorldPoint(clickPosition),
				ballPrefab.transform.rotation
				);

			Rigidbody ballRigidBody = ball.GetComponent<Rigidbody>();
			ballRigidBody.AddForce(new Vector3(x_position,y_position,z_position));
			ballRigidBody.AddTorque(new Vector3(0, shotTorque, 0));

			ball.transform.parent = ballHolder.transform;
			}
	}



	/*Vector3 GetInstantiatePosition() {
		float x = basewidth *
			(Input.mousePosition.x / Screen.width) - (basewidth / 2);
		return transform.position + new Vector3(x, 0, 0);

	}*/

}
