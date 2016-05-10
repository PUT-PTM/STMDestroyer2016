using UnityEngine;
using System.Collections;

public class DestroyTorpedo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 15)
        {
            DestroyObject(gameObject);
        }
    }
}
