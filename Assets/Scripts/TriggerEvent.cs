using UnityEngine;
using System.Collections;

public class TriggerEvent : MonoBehaviour {
	public bool alive;
	public bool shadowScare;
	private Vector3 previousPosition;
	private Vector3 newPosition; 
	private GameObject bunnyCutout;
	private GameObject targetLoc;
	
	// Use this for initialization
	void Start () {
		alive = true;
		shadowScare = false;
		bunnyCutout = GameObject.Find("bunny_cutout");
		targetLoc = GameObject.Find("lerpLoc");
	}
	
	// Update is called once per frame
	void Update () {

		//ShadowScare starts false, when activated the shadow begins to pan away.
		if(shadowScare){
			cutoutPan();
			
			if((bunnyCutout.transform.position.x - targetLoc.transform.position.x) > -1.0f){
				bunnyCutout.renderer.enabled = false;
				GameObject.Destroy(bunnyCutout);
				shadowScare = false;
			}	
		}	
	}
	
	void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player" && alive == true){			
			if(!shadowScare){
				shadowScare = true;				
			}
			
			audio.Play();
			Debug.Log("Event Triggered");
			alive = false;
		}
    }
	
	void cutoutPan(){
 		bunnyCutout.transform.position = Vector3.Lerp(bunnyCutout.transform.position, targetLoc.transform.position, (2.5f * Time.deltaTime));		
	}	
}



