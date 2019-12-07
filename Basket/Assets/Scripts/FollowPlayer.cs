using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	public Transform target;    //targetへの参照
	private Vector3 offset;     //相対座標

	private void Start() {
		//自分自身とtargetとの相対距離を求める
		offset = GetComponent<Transform>().position - target.position;
	}

	void Update() {
		GetComponent<Transform>().position = target.position + offset;
	}
}
