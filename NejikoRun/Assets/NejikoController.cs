﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NejikoController : MonoBehaviour {

	const int MinLane = -2;
	const int MaxLane = 2;
	const float LaneWidth = 1.0f;

	CharacterController controller;
	Animator animator;

	Vector3 moveDirection = Vector3.zero;
	int targetLane;

	public float gravity;
	public float speedZ;
	public float speedX;
	public float speedJump;
	public float accelerationZ;

	void Start() {
		//必要なコンポーネントを自動取得
		controller = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
	}

	void Update() {
		//デバッグ用
		if (Input.GetKeyDown("left")) {
			MoveToLeft();
			Debug.Log("left");
		}
		if (Input.GetKeyDown("right")) {
			MoveToRight();
			Debug.Log("right");
		}
		if (Input.GetKeyDown("space")) {
			Jump();
			Debug.Log("right");
		}

		//徐々に加速しZ方向に常に前進させる
		float acceleratedZ = moveDirection.z + (accelerationZ * Time.deltaTime);
		moveDirection.z = Mathf.Clamp(acceleratedZ, 0, speedZ);

		//X方向は目標のポジションまでの差分の割合で速度を計算
		float ratioX = (targetLane * LaneWidth - transform.position.x) / LaneWidth;
		moveDirection.x = ratioX * speedX;

		/*
		//地上にいる場合のみ操作をおこなう
		if (controller.isGrounded) {
			//Inputを検知して前にすすめる
			if (Input.GetAxis("Vertical") > 0.0f) {
				moveDirection.z = Input.GetAxis("Vertical") * speedZ;
			} else {
				moveDirection.z = 0;
			}

			//方向転換
			transform.Rotate(0, Input.GetAxis("Horizontal") * 3, 0);

			//ジャンプ
			if (Input.GetButton("Jump")) {
				moveDirection.y = speedJump;
				animator.SetTrigger("jump");
			}
		}
		*/

		//重力分の力を毎フレーム追加
		moveDirection.y -= gravity * Time.deltaTime;
		//移動実行
		Vector3 globalDirection = transform.TransformDirection(moveDirection);
		//移動後接地してたらY方向の速度はリセットする
		if (controller.isGrounded) moveDirection.y = 0;
		//速度が０以上なら走っているフラグをtrueにする
		animator.SetBool("run", moveDirection.z > 0.0f);
	}

	//左のレーンに移動を開始
	public void MoveToLeft() {
		if (controller.isGrounded && targetLane > MinLane) targetLane--;
		Debug.Log("leftLane");
	}
	//右のレーンに移動を開始
	public void MoveToRight() {
		if (controller.isGrounded && targetLane < MaxLane) targetLane++;
		Debug.Log("RkgjhtLane");
	}

	public void Jump() {
		if (controller.isGrounded) {
			moveDirection.y = speedJump;

			//ジャンプトリガーを設定
			animator.SetTrigger("jump");
			Debug.Log("jump");

		}
	}

}
