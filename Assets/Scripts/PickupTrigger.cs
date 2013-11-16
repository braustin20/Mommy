using UnityEngine;
using System.Collections;

public class PickupTrigger : MonoBehaviour {
	bool pickedUp;
	
	// Use this for initialization
	void Start () {
		pickedUp = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void startEvent(){
		if(pickedUp == false){
			audio.Play();
			pickedUp = true;
		}
	}
}
