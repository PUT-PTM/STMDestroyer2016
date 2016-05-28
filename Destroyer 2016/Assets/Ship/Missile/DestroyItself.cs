using UnityEngine;
using System.Collections;

public class DestroyItself : MonoBehaviour
{

    public float seabed; //bottom of sea

	// Use this for initialization
	void Start () {
        seabed = -11;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < seabed) {
            DestroyObject(gameObject);
            Moving.inc_ammo(); //i set method inc_ammo as static because i have problem with inheritance (GetComponent don't work correctly)
        }
	}
}
