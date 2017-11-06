using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PimpleSpawner : MonoBehaviour {

    public Transform[] pimpleSpawns;
    public GameObject pimple;
    int spawnPos;
    //GameObject spawnObjPos;
    float timer;
    public float spawnFreq = 1;
    public AudioSource spawnSound;
    public float spawnFreqDecay;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (spawnFreq > 0.2)
            spawnFreq -= spawnFreqDecay * Time.deltaTime;

        spawnPos = Random.Range(0, 12);

        if (timer < spawnFreq)
            timer += Time.deltaTime;
        else
        {
            timer = 0;
            SpawnPimple();
        }
	}

    public void SpawnPimple()
    {
        if (Physics.CheckSphere(pimpleSpawns[spawnPos].position, 0.1f))  
        {
            if (spawnPos > 11)
                spawnPos = 0;
        } else
        {
            GameObject newPimple = (GameObject)Instantiate(pimple, pimpleSpawns[spawnPos].position, pimpleSpawns[spawnPos].rotation);
            newPimple.name = "Pimple " + (spawnPos + 1);
            spawnSound.Play();
        }
    }
}
