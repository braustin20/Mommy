#pragma strict
var distance = 1;
var WASDTut : boolean; 
var touchTut : boolean;
var interactTut : boolean;
var flashTut : boolean;
var time : float;
var color : Color;

function Start () {
	color = Color.magenta;
	WASDTut = false; 
	touchTut = false;
	flashTut = false;
	
}

function Update () {

			//
			time = time + Time.deltaTime;
			
			if(!WASDTut){
					fade();
					transform.position = (GameObject.FindGameObjectWithTag("Player").transform.position + (GameObject.FindGameObjectWithTag("Player").transform.forward * 2.0f)) + new Vector3(0, 2.0f, 0);
	        		transform.rotation = GameObject.FindGameObjectWithTag("Player").transform.rotation; 

	        	//	transform.position = (GameObject.Find("FPS Character").transform.position + (GameObject.Find("FPS Character").transform.forward * 2.0f)) + new Vector3(0, 0.25f, 0);
				//	transform.rotation = GameObject.Find("FPS Character").transform.rotation; 
					if(time > 10){
					
					WASDTut = true;
					
					}
			}
			
			if((WASDTut) && (!touchTut)){
//				Debug.Log(time);
				if((time > 11) && (time < 12)){
					GetComponent(TextMesh).text = "Press 'E' to interact with objects";
					renderer.material.color.a = 1.15;
					
				}
				fade();
				transform.position = (GameObject.FindGameObjectWithTag("Player").transform.position + (GameObject.FindGameObjectWithTag("Player").transform.forward * 2.0f)) + new Vector3(0, 2.0f, 0);
				transform.rotation = GameObject.FindGameObjectWithTag("Player").transform.rotation; 
			
			//	transform.position = (GameObject.Find("FPS Character").transform.position + (GameObject.Find("FPS Character").transform.forward * 2.0f)) + new Vector3(0, 0.5f, 0);
			//	transform.rotation = GameObject.Find("FPS Character").transform.rotation; 
				if(time > 25){
					touchTut = true;
					WASDTut = true;
				}
				
//				Debug.Log(renderer.material.color.a);
				
			}
			
			if((WASDTut) && (touchTut) && (!flashTut)){
//				Debug.Log(time);
				if((time > 28) && (time < 29)){
					GetComponent(TextMesh).text = "Right click and drag to use flashlight";
					renderer.material.color.a = 1.15;
					
				}
				fade();
				transform.position = (GameObject.FindGameObjectWithTag("Player").transform.position + (GameObject.FindGameObjectWithTag("Player").transform.forward * 2.0f)) + new Vector3(0, 2.0f, 0);
				transform.rotation = GameObject.FindGameObjectWithTag("Player").transform.rotation; 
			
			//	transform.position = (GameObject.Find("FPS Character").transform.position + (GameObject.Find("FPS Character").transform.forward * 2.0f)) + new Vector3(0, 0.5f, 0);
			//	transform.rotation = GameObject.Find("FPS Character").transform.rotation; 
				if(time > 38){
					touchTut = true;
					WASDTut = true;
					flashTut = true;
				}
				
//				Debug.Log(renderer.material.color.a);
				
			}
			
			
			}	
			
				
function fade(){
	while (renderer.material.color.a > 0){
		renderer.material.color.a -= 0.001 * Time.deltaTime;
		yield;
	}
}		