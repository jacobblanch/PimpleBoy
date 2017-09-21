using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PimpleScript : MonoBehaviour {

    public GameObject splat;
    float timer;
    public float TimeToDie;
    public GameObject pimpleSpawner;
    public PimpleSpawner pimpleSpawnerScript;
    public int pointValue;

	// Use this for initialization
	void Start () {
        pimpleSpawner = GameObject.FindGameObjectWithTag("MainCamera");
        pimpleSpawnerScript = pimpleSpawner.GetComponent<PimpleSpawner>();
	}
	
	// Update is called once per frame
	void Update () {
        /*if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray))
            {
                Instantiate(splatSound, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }*/
        if (timer < TimeToDie)
            timer += Time.deltaTime;
        else
            SceneManager.LoadScene("EndMenu");
	}

    public void OnMouseDown()
    {
        Instantiate(splat, transform.position, transform.rotation);
        pimpleSpawnerScript.poppedScore += pointValue;
        Destroy(this.gameObject);
    }
}
