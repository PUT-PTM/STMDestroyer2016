using UnityEngine;
using System.Collections;

public class DestroyTorpedo : MonoBehaviour {

    public float waterSurface;

	// Use this for initialization
	void Start () {
        waterSurface = 7.35f;
	}

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > waterSurface)
        {
            DestroyObject(gameObject);
        }
    }
}
