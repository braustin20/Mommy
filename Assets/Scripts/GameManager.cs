using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Camera ovrCameraL;
	public Camera ovrCameraR;
	public Camera fpsCamera;
	public GameObject fpsFlashlight;
	public GameObject ovrFlashlight;
	public GameObject ovrCharacter;
	public GameObject fpsCharacter;
	private bool oculus;
	
	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		Screen.showCursor = false;
		oculus = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.O)){
			if(oculus == true){
				ovrCameraL.enabled = false;
				ovrCameraR.enabled = false;
				fpsCamera.enabled = true;
				ovrFlashlight.gameObject.SetActive(false);
				fpsFlashlight.gameObject.SetActive(true);
				oculus = false;
				ovrCameraR.gameObject.GetComponent<PlayerInteract>().enabled = false;
				fpsCamera.gameObject.GetComponent<PlayerInteract>().enabled = true;
			}
			else if(oculus == false){
				ovrCameraL.enabled = true;
				ovrCameraR.enabled = true;
				fpsCamera.enabled = false;
				ovrFlashlight.gameObject.SetActive(true);
				fpsFlashlight.gameObject.SetActive(false);
				oculus = true;
				ovrCameraR.gameObject.GetComponent<PlayerInteract>().enabled = true;
				fpsCamera.gameObject.GetComponent<PlayerInteract>().enabled = false;
			}
		}
		if(oculus == true){
			if(Input.GetKeyDown(KeyCode.C)){
				ovrFlashlight.gameObject.GetComponent<FlashlightControls>().enabled = true;
				ovrCharacter.gameObject.GetComponent<MouseLook>().enabled = false;
			}
			if(Input.GetKeyUp(KeyCode.C)){
				ovrFlashlight.gameObject.GetComponent<FlashlightControls>().enabled = false;
				ovrCharacter.gameObject.GetComponent<MouseLook>().enabled = true;
			}
		}
		else{
			if(Input.GetKeyDown(KeyCode.C)){
				fpsFlashlight.gameObject.GetComponent<FlashlightControls>().enabled = true;
				ovrCharacter.gameObject.GetComponent<MouseLook>().enabled = false;
				fpsCharacter.gameObject.GetComponent<MouseLook>().enabled = false;
			}
			if(Input.GetKeyUp(KeyCode.C)){
				fpsFlashlight.gameObject.GetComponent<FlashlightControls>().enabled = false;
				ovrCharacter.gameObject.GetComponent<MouseLook>().enabled = true;
				fpsCharacter.gameObject.GetComponent<MouseLook>().enabled = true;
			}
		}
		
		/*
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			Application.LoadLevel(0);
		}
		else if(Input.GetKeyDown(KeyCode.Alpha2)){
			Application.LoadLevel(1);
		}
		*/
	}
}
