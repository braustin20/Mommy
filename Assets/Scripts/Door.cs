using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	bool doorClosed;
	bool rotating;
	Quaternion initialRot;
	Quaternion targetRot;
	float t;
	float animTime;

	// Use this for initialization
	void Start () {
		doorClosed = true;
		rotating = false;
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
				initialRot = transform.localRotation;
			    targetRot = transform.localRotation * Quaternion.Euler(new Vector3(0, -90, 0));
			    t = 0.0f;
				rotating = true;
				doorClosed = false;
			}
			else if(doorClosed == false){
			    initialRot = transform.localRotation;
			    targetRot = transform.localRotation * Quaternion.Euler(new Vector3(0, 90, 0));
			    t = 0.0f;
				rotating = true;
				doorClosed = true;
			}
		}
	}
}
