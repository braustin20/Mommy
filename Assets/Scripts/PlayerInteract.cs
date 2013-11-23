using UnityEngine;
using System.Collections;

//Class which allows the player to grab and move objects in the environment
//!!!Must be attached to the Main Camera in First Person
public class PlayerInteract: MonoBehaviour {
	public Transform hitObject;
	public bool isHolding;
	RaycastHit hit;
	

	// Use this for initialization
	void Start () {
		//Reset our variables when the game starts
		hitObject = null;
		isHolding = false;
	}
	
	// Update is called once per frame
	void Update () {
		//We don't want the raycast to hit the player, so we convert the player layer (8)
		//into a bitmask and pass that into the raycast later
		int layerMask = 1 << 8;
		//Reverses the bitmask so that we're hitting everything EXCEPT layer 8
		layerMask = ~layerMask;
		
		if(Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("JoyInteract")){
			//If the player presses the grab key and is not holding an object, raycast to see if one is in range
			if(isHolding == false){
				if(Physics.Raycast(transform.position, transform.forward, out hit, 5.0f, layerMask)){
					//If we hit a grabbable object, store a reference to that object if it has been tagged as Grabbable
					if(hit.collider.gameObject.tag == "GrabbableObject"){
				    	isHolding = true;
						hitObject = hit.collider.gameObject.transform;
					}
					else if(hit.collider.gameObject.tag == "TriggerObject"){
						isHolding = true;
						hitObject = hit.collider.gameObject.transform;
						hitObject.gameObject.GetComponent<PickupTrigger>().startEvent();	
					}
					else if(hit.collider.gameObject.tag == "UseableDoor"){
						hit.collider.gameObject.GetComponent<Door>().RotateDoor(1.0f);
						Debug.Log("Hit door");
					}
					else if(hit.collider.gameObject.tag == "TriggerDoor"){
						hit.collider.gameObject.GetComponent<Door>().RotateDoor(1.0f);
						hit.collider.gameObject.GetComponent<Door>().startEvent();
						Debug.Log("Hit door");
					}
				}
			}
			//If the grab key is pressed and an object is held, drop it
			else if (isHolding == true){
				isHolding = false;
			}
		}
		if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetButtonDown("JoyThrow")){
			if(isHolding == true){
				isHolding = false;
				hitObject.parent = null;
            	hitObject.rigidbody.useGravity = true;
				hitObject.rigidbody.AddForce ((this.transform.forward * 1000));	
					
				hitObject = null;
			}
	    }
		//If the object should be held, update it's position
	    if(isHolding == true){
	        hitObject.rigidbody.useGravity = false; 
			 	
			//Attach the object as a child to the camera
	        hitObject.parent = this.transform;
	 		
			//Change the final int to change distance from camera
	        hitObject.transform.position = (this.transform.position + (this.transform.forward * 2.25f)) - new Vector3(0, 0.5f, 0); 
	 
	        hitObject.transform.rotation = this.transform.rotation; 
	    }
		//If the object should not be held, detach from the camera and turn on gravity
	    else if(hitObject != null && isHolding == false){ 
            hitObject.parent = null;
            hitObject.rigidbody.useGravity = true;
			hitObject = null;
	    }
	}
}
