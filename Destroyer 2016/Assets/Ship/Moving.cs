using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour {

    public float speed;
    public float range;
	public GameObject Missile;

	// Use this for initialization
	void Start () {
        range = 20;
        speed = 2f;
	}

	// Update is called once per frame
	void Update () {

		if (transform.position.x <= -range) {
			transform.position = new Vector2 (-range, transform.position.y);
		} 
		else if (transform.position.x >= range) {
			transform.position = new Vector2 (range, transform.position.y);
		}
		float move = Input.GetAxis ("Horizontal");
        print(move);
		move *= Time.deltaTime;
		move *= speed;
		transform.Translate (move,0,0);

		if (Input.GetButtonDown ("Fire1")) {
            float x = transform.localPosition.x;
         
            float  y  = (float)6.7;
           
            Instantiate (Missile,new Vector2(x, y),Quaternion.identity);
			print ("fire");
		}

	
	}
}
