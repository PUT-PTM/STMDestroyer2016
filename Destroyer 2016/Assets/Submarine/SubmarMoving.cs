using UnityEngine;
using System.Collections;

public class SubmarMoving : MonoBehaviour {
    public GameObject Missile;
    public float speed = 2f;
	public float range = 5;
	// Use this for initialization
	void Start () {
        StartCoroutine(i());
    }

    IEnumerator i()
    {
        float a = Random.value * 3;
        yield return new WaitForSeconds(a);
       fire();

    }
    // Update is called once per frame
    void Update () {
		
		float move = 	speed * Time.deltaTime;

		if (transform.position.x <= -range) {
			if (speed < 0) {
				speed *=-1;
			}
		}
        else if (transform.position.x >= range) {
			if (speed > 0) {
				speed *=-1;
			}
		
		}

     
     
          
      
           
        

        transform.Translate (move, 0,0);
	}

    void fire() {
        float x = transform.localPosition.x;

        float y = transform.localPosition.y;
        y += (float)0.5;

        Instantiate(Missile, new Vector2(x, y), Quaternion.identity);
        StartCoroutine(i());
    }


}
