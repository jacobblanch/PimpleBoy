using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundEffectPrefabScript : MonoBehaviour {

    float timer;
    float lifeTime;
    public AudioClip soundEffect;

	// Use this for initialization
	void Start () {
        lifeTime = soundEffect.length;
	}
	
	// Update is called once per frame
	void Update () {
        if (timer < lifeTime)
            timer += Time.deltaTime;
        else
            Destroy(this.gameObject);
	}
}
