﻿using UnityEngine;
using System.Collections;

public class DestroyBonus : MonoBehaviour {

    public float waterSurface;

	// Use this for initialization
	void Start () {
        waterSurface = 8.1f;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < waterSurface)
        {
            DestroyObject(gameObject);
        }
	}
}
