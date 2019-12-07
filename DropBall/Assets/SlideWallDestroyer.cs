using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideWallDestroyer : MonoBehaviour
{
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "SlideWall") {
			//SlideWallを破壊
			Destroy(other.gameObject);
		}
	}
}
