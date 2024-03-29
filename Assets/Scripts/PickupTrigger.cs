﻿using UnityEngine;
using System.Collections;

public class PickupTrigger : MonoBehaviour {
	public bool pickedUp;
	public bool phoneOff;
	public AudioClip loopingSound;
	public AudioClip phoneHangUp;
	public AudioClip doorSlam;
	public GameObject gameManager;
	
	public GameObject slamDoor;
	// Use this for initialization
	void Start () {
		pickedUp = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void startEvent(){
		//For phone event scare
		if(pickedUp == false && phoneOff == true){
			audio.clip = phoneHangUp;
			audio.Play();
			pickedUp = true;
			
			Debug.Log("GETTING CALLED");
			slamDoor.gameObject.GetComponent<Door>().slam = true;
			slamDoor.gameObject.GetComponent<Door>().RotateDoor(1.2f);
			
			gameManager.gameObject.GetComponent<GameManager>().firstTrigger = true;
			
			//slamDoor.RotateDoor(10);
		}
	}
}
