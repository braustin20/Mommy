using UnityEngine;
using System.Collections;

public class PickupTrigger : MonoBehaviour {
	bool pickedUp;
	public bool phoneOff;
	public AudioClip loopingSound;
	public AudioClip phoneHangUp;
	
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
			pickedUp = true;
		}
	}
}
