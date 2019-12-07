using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideWallGenerator : MonoBehaviour
{
	public GameObject slideWall;
	float timeSpan = 0.85f;
	float delta = 0;

	void Update()
    {
		this.delta += Time.deltaTime;
		if(this.delta > this.timeSpan) {
			this.delta = 0;
			Instantiate(slideWall);
		}
    }
}
