using UnityEngine;
using System.Collections;

public class TriggerEvent : MonoBehaviour {
	public bool alive;

	// Use this for initialization
	void Start () {
		alive = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player" && alive == true){
			
			audio.Play();
			Debug.Log("Event Triggered");
			alive = false;
		}
    }
}
