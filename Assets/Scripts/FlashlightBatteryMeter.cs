using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	public Light myLight;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		myLight.intensity = 0;
	}
}
