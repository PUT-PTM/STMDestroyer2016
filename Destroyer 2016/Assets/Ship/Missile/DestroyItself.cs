using UnityEngine;
using System.Collections;

public class DestroyItself : MonoBehaviour
{

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -10) {
            DestroyObject(gameObject);
            Moving.inc_ammo(); //i set method inc_ammo as static because i have problem with inheritance (GetComponent don't work correctly)
        }
	}
}
