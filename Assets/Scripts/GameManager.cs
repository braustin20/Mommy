using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject fpsFlashlight;
	public GameObject ovrFlashlight;
	public GameObject ovrCameraController;
	public GameObject fpsCharacter;
	private GameObject ovrCharacter;
	private bool oculus;
	
	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		Screen.showCursor = false;
		oculus = false;
		ovrCharacter = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.O)){
			if(oculus == true){
				fpsFlashlight.gameObject.SetActive(true);
				oculus = false;
				
				ovrCameraController.gameObject.SetActive(false);
				fpsCharacter.gameObject.SetActive(true);
			}
			else if(oculus == false){
				fpsFlashlight.gameObject.SetActive(false);
				oculus = true;
				
				ovrCameraController.gameObject.SetActive(true);
				fpsCharacter.gameObject.SetActive(false);
			}
		}
		if(oculus == true){
			if(Input.GetKeyDown(KeyCode.Mouse1)){
				ovrFlashlight.gameObject.GetComponent<FlashlightControls>().enabled = true;
				ovrCharacter.gameObject.GetComponent<MouseLook>().enabled = false;
			}
			if(Input.GetKeyUp(KeyCode.Mouse1)){
				ovrFlashlight.gameObject.GetComponent<FlashlightControls>().enabled = false;
				ovrCharacter.gameObject.GetComponent<MouseLook>().enabled = true;
			}
		}
		else{
			if(Input.GetKeyDown(KeyCode.Mouse1)){
				fpsFlashlight.gameObject.GetComponent<FlashlightControls>().enabled = true;
				ovrCharacter.gameObject.GetComponent<MouseLook>().enabled = false;
				fpsCharacter.gameObject.GetComponent<MouseLook>().enabled = false;
			}
			if(Input.GetKeyUp(KeyCode.Mouse1)){
				fpsFlashlight.gameObject.GetComponent<FlashlightControls>().enabled = false;
				ovrCharacter.gameObject.GetComponent<MouseLook>().enabled = true;
				fpsCharacter.gameObject.GetComponent<MouseLook>().enabled = true;
			}
		}
	}
}
