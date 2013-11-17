using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	bool doorClosed;
	bool rotating;
	bool opened;
	Quaternion initialRot;
	Quaternion targetRot;
	float t;
	float animTime;
	public AudioClip openClip;
	public AudioClip closeClip;
	
	// Use this for initialization
	void Start () {
		doorClosed = true;
		rotating = false;
		opened = false;
		animTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(rotating == true){
			if(t < 1.0f){
				transform.localRotation = Quaternion.Slerp(initialRot, targetRot, t);
		    	t += Time.deltaTime / animTime;
			}
			else{
				rotating = false;
			}
		}
	}
	
	public void RotateDoor(float time){
		animTime = time;
		if(rotating == false){
			if(doorClosed == true){
				audio.clip = openClip;
				audio.Play();
				initialRot = transform.localRotation;
			    targetRot = transform.localRotation * Quaternion.Euler(new Vector3(0, -90, 0));
			    t = 0.0f;
				rotating = true;
				doorClosed = false;
			}
			else if(doorClosed == false){
				audio.clip = closeClip;
				audio.Play();
			    initialRot = transform.localRotation;
			    targetRot = transform.localRotation * Quaternion.Euler(new Vector3(0, 90, 0));
			    t = 0.0f;
				rotating = true;
				doorClosed = true;
			}
		}
	}
	public void startEvent(){
		if(opened == false){
			//audio.Play();
			opened = true;
		}
	}
}
