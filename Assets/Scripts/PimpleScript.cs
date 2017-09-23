using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PimpleScript : MonoBehaviour {
    
    float timer;
    public float TimeToDie;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (timer < TimeToDie)
            timer += Time.deltaTime;
        else
            SceneManager.LoadScene("EndMenu");
	}
}
