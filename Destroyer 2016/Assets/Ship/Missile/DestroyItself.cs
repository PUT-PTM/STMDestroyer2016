﻿using UnityEngine;
using System.Collections;

public class DestroyItself : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -10) {
            DestroyObject(gameObject);
        }
	}
}
