using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PimpleSpawner : MonoBehaviour {

    public Transform[] pimpleSpawns;
    public GameObject pimple;
    int spawnPos;
    GameObject spawnObjPos;
    float timer;
    public float spawnFreq = 1;
    public int poppedScore;
    public Text poppedText;
    public AudioSource spawnSound;
    public float spawnFreqDecay;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        poppedText.text = poppedScore.ToString();

        if (spawnFreq > 0.2)
            spawnFreq -= spawnFreqDecay * Time.deltaTime;

        spawnPos = Random.Range(0, 12);

        if (timer < spawnFreq)
            timer += Time.deltaTime;
        else
        {
            timer = 0;
            if (!Physics.CheckSphere(pimpleSpawns[spawnPos].position, 0.1f))
            {
                Instantiate(pimple, pimpleSpawns[spawnPos].position, pimpleSpawns[spawnPos].rotation);
                spawnSound.Play();
            }
                
        }
	}
}
