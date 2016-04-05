using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D other)
    {
        DestroyObject(gameObject);
        print("explosion");
    }

}
