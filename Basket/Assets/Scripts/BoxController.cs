using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController: MonoBehaviour
{

	Vector3 startPosition;

	public float amplitude;
	public float speed; 

    void Start()
    {
		startPosition = transform.localPosition;
    }

    void Update()
    {
		float x = amplitude * Mathf.Sin(Time.time * speed);

		transform.localPosition = startPosition + new Vector3(x, 0, 0);
    }
}
