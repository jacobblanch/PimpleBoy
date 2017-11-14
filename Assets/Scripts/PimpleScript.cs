using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PimpleScript : MonoBehaviour {
    
    float timer;
    public float TimeToDie;
    public float hp;
    public GameObject splat;
    AudioSource audioSource;
    public AudioClip squeezeSound;
    bool audioPlayed;
    float audioTime;
    float audioLimit = 0.5f;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (timer < TimeToDie)
            timer += Time.deltaTime;
        else
            SceneManager.LoadScene("EndMenu");
        if (audioPlayed)
            audioTime += Time.deltaTime;

        Debug.Log(audioTime);
	}

    public void takeDamage(float damage)
    {
        hp -= damage;
        PlayAudio();
        if (hp <= 0)
        {
            Instantiate(splat, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    public void PlayAudio()
    {
        if (!audioPlayed)
        {
            audioSource.PlayOneShot(squeezeSound);
            audioPlayed = true;
        } else if (audioTime > audioLimit )
        {
            audioPlayed = false;
            audioTime = 0f;
        }
    }
}
