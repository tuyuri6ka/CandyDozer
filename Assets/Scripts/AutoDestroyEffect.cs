using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyEffect : MonoBehaviour
{
	ParticleSystem Particle;
	
	void Start() {
		Particle = GetComponent<ParticleSystem>();
	}

	void Update(){
		//パーティクルの再生が終了したらGameObjectを削除
		if (Particle.isPlaying == false) Destroy(gameObject);
    }
}
