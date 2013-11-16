using UnityEngine;
using System.Collections;

public class HeadBobber : MonoBehaviour {
	private float timer = 0.0f;
	public float bobbingSpeed = 0.18f;
	public float bobbingAmount = 0.2f;
	public float midpoint = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float waveslice = 0.0f;
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0.0f){
			timer = 0.0f;
		}
		else {
			waveslice = Mathf.Sin(timer);
			timer = timer + bobbingSpeed;
			if (timer > Mathf.PI * 2.0f){
				timer = timer - (Mathf.PI * 2.0f);
			}
		}
		if (waveslice != 0){
			float translateChange = waveslice * bobbingAmount;
			float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical); 
       		totalAxes = Mathf.Clamp (totalAxes, 0.0f, 1.0f); 
       		translateChange = totalAxes * translateChange;
			Vector3 tempPosition = this.transform.localPosition;
			tempPosition.y = midpoint + translateChange;
       		this.transform.localPosition = tempPosition;
		}
		else {
			Vector3 tempPosition = this.transform.localPosition;
			tempPosition.y = midpoint;
			this.transform.localPosition = tempPosition ;
		}
	}
}
