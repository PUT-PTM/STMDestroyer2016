using UnityEngine;
using System.Collections;

public class SubmarMoving : MonoBehaviour {

	public float speed = 2f;
	public float range = 5;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
		float move = 	speed * Time.deltaTime;

		if (transform.position.x <= -range) {
			if (speed < 0) {
				speed *=-1;
			}
		} else if (transform.position.x >= range) {
			if (speed > 0) {
				speed *=-1;
			}

		
		} 
	
			transform.Translate (move, 0,0);


	}
}
