using UnityEngine;
using System.Collections;

public class clockSoundChangeScript : MonoBehaviour {
	public bool change;
	public AudioClip dingDong;
	// Use this for initialization
	void Start () {
		change = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(change == true){
			Debug.Log("POOP OOPSDPFJSOJDF");
			audio.clip = dingDong;
			audio.Play();
			change = false;
		}
		
	}
}
