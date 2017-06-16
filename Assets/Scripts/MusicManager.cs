using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicManager : MonoBehaviour {

    public AudioClip startClip, gameClip, endClip;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        ChooseClip();
        audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void ChooseClip()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "00Start":
                audioSource.clip = startClip;
                print("playing start clip");
                break;
            case "01Level01":
                audioSource.clip = gameClip;
                print("playing gameClip");
                break;
            case "02End":
                audioSource.clip = endClip;
                print("playing endClip");
                break;
        }
    }


}
