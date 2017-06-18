using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicManager : MonoBehaviour {

    public AudioClip startClip, gameClip, loseClip, winClip;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        ChooseClip();
        audioSource.Play();
	}

    private void ChooseClip()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "00Start":
                audioSource.clip = startClip;
                break;
            case "01Level01":
                audioSource.clip = gameClip;
                break;
            case "02EndLose":
                audioSource.clip = loseClip;
                break;
            case "03EndWin":
                audioSource.clip = winClip;
                break;
        }
    }


}
