using UnityEngine;
using System.Collections;

public class TriggerEvent : MonoBehaviour {
	public bool alive;
	public bool shadowScare;
	private Vector3 previousPosition;
	private Vector3 newPosition; 
	private GameObject destroyBunny;
	// Use this for initialization
	void Start () {
		alive = true;
		shadowScare = false;
		destroyBunny = GameObject.Find("bunny_cutout");
	}
	
	// Update is called once per frame
	void Update () {

		//ShadowScare starts false, when activated the shadow begins to pan away.
		if(shadowScare){
					cameraPan();
			
			if((destroyBunny.transform.position.x - GameObject.Find("lerpLoc").transform.position.x) > -1.0f){
					//GameObject.Destroy(GameObject.Find("bunny_cutout"));
					//GameObject.Destroy(GameObject.Find("lerploc"));
					destroyBunny.renderer.enabled = false;
					GameObject.Destroy(destroyBunny);
					shadowScare = false;
				}
			
				}
		
		
		
		
	}
	
	void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player" && alive == true){
			
			if(!shadowScare){
				//GameObject.Find("tempBunny").transform.position += new Vector3(500,0,0);
				shadowScare = true;
				
			}
			
			
			audio.Play();
			Debug.Log("Event Triggered");
			alive = false;
		}
    }
	
	void cameraPan(){
 		previousPosition = destroyBunny.transform.position;
		 //GameObject.Find("Main Camera").transform.position = Vector3.Lerp(GameObject.Find("Main Camera").transform.position, newPosition,  Time.deltaTime);
 		destroyBunny.transform.position = Vector3.Lerp(destroyBunny.transform.position, GameObject.Find("lerpLoc").transform.position, (1.5f * Time.deltaTime));
		
		
		
}
	
}



