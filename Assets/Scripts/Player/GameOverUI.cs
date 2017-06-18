using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour {
    public Text waveText; 

	// Use this for initialization
	void Start () {
        waveText.text = WaveSpawner.GetWaveText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
