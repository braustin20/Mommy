﻿using UnityEngine;
using System.Collections;

public class clockTriggerScritp : MonoBehaviour {
	public GameObject clock;
	public GameObject gameManager;
	public bool alive;
	public AudioClip dingDong;
	public bool tripped;
	// Use this for initialization
	void Start () {
		alive = true;
		tripped = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player" && alive == true){			
	
			if(gameObject.name == "clockTrigger" && tripped == false){
				
				clock.gameObject.GetComponent<clockSoundChangeScript>().change = true;
				Debug.Log("WE HAVE ARRIVED");
				tripped = true;
				gameManager.gameObject.GetComponent<GameManager>().thirdTrigger = true;
				
				
			}
			
			
			//audio.Play();
			Debug.Log("Event Triggered");
			alive = false;
		}
		
		
    }
}
