using UnityEngine;
using System.Collections;

public class DestroyBonus : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < 8.1)
        {
            DestroyObject(gameObject);
        }
	}
}
