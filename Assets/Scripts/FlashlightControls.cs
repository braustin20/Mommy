/*Script which manages flashlight controls based on mouse or gamepad input
 *Requires toggle on/off within a game manager script
 */

using UnityEngine;
using System.Collections;

public class FlashlightControls : MonoBehaviour {	
	//Speed of flashlight movement
	public float sensitivityX = 15.0f;
	public float sensitivityY = 15.0f;
	
	//Limits how far the flashlight can rotate
	private float minimumX = -45.0f;
	private float maximumX = 45.0f;
	private float minimumY = -45.0f;
	private float maximumY = 45.0f;
	
	//The actual rotation value before the limits are applied
	float rotationY = 0.0f;
	float rotationX = 0.0f;

	void Update (){
		//Calculate rotation using sensitivity plus mouse as well as joy axis
		//**May allow for strange behavior if gamepad and mouse is used simultaneously**
		rotationX += (Input.GetAxis("RHoriz") + Input.GetAxis("Mouse X")) * sensitivityX;
		rotationY += (Input.GetAxis("RVert")  + Input.GetAxis("Mouse Y")) * sensitivityY;
		
		//Limit the movement based on values set above
		rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
		rotationX = Mathf.Clamp (rotationX, minimumX, maximumX);
		
		//Perform the change of the rotation
		transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0.0f);
	}
	
	void Start ()
	{
		// Make the rigid body not change rotation
		if (rigidbody)
			rigidbody.freezeRotation = true;
	}
}