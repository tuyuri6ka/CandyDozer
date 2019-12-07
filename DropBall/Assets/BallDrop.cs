using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDrop : MonoBehaviour
{
	public GameObject[] ballPrefabs;
	public GameObject ballHolder;
	public float baseWidth;

    void Update()
    {
		if (Input.GetButtonDown("Fire1")) Drop();
    }

	public void Drop() {
		//prefabからBallオブジェクトを生成
		GameObject ball = (GameObject)Instantiate(
			RandomBall(),
			InstantiatePosition(),
			Quaternion.identity
		);

		//生成したballオブジェクトはBallHolderに格納する
		ball.transform.parent = ballHolder.transform;

		Debug.Log("OK");
	}

	//ballのprefabからランダムに１つ選ぶ
	GameObject RandomBall(){
		GameObject prefab = null;

		//ランダムにボールの色を変更する
		int index = Random.Range(0, ballPrefabs.Length);
		prefab = ballPrefabs[index];

		return prefab;
	}

	Vector3 InstantiatePosition() {
		//画面のサイズとInputの割合からball生成のpositionを計算
		float x = baseWidth *
			(Input.mousePosition.x / Screen.width) - (baseWidth / 2);
		if (x < -(baseWidth / 2)) {
			x = -(baseWidth / 2);
		}else if(x > (baseWidth / 2)) {
			x = (baseWidth / 2);
		} else {
			
		}
		return transform.position + new Vector3(x, 10, 0);
	}


}
