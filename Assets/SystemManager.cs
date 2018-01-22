using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        StartCoroutine("WaitForInit");
	}
	IEnumerator  WaitForInit()
    {
        yield return new WaitForSeconds(1);

        DetectSystemInfo.Singleton.Init();
        ParticleSystemController.Singleton.Init();
    }

}
