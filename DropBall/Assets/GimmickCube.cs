using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickCube : MonoBehaviour
{
	public float rotateSpeed;

    // Update is called once per frame
    void Update()
    {
		//GimmickCubeを回転
		transform.Rotate(new Vector3(0,0,rotateSpeed));
    }
}
