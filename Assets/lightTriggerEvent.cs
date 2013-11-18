using UnityEngine;
using System.Collections;

public class lightTriggerEvent : MonoBehaviour {
	public float time;
	private float limit; 
	public bool triggered;
	// Use this for initialization
	void Start () {
		
		time = 0;
		limit  =  Random.Range(0.05f, 0.5f);
		triggered = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		
		
		if(time >= limit && triggered == false){
			
			if(light.enabled == true){
				light.enabled = false;
				
			}else{
				light.enabled = true;
				
			}
			time = 0;
			limit = Random.Range(0.05f, 0.5f);
			
			
		}else if(triggered == true && light.enabled == true){
			Debug.Log("TURN OFF THE LIGHT, BOBBY");
			light.enabled = false;
		}
		
		
		
	}
}
