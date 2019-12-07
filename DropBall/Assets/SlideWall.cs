using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideWall : MonoBehaviour
{
	Vector3 startPosition;
	public float speed;
	public float amplitude;

    void Start()
    {
		startPosition = transform.localPosition;	
    }

    void Update()
    {
		//横移動を行う
		startPosition += new Vector3(speed * amplitude, 0, 0);
		transform.localPosition = startPosition;
    }
}
