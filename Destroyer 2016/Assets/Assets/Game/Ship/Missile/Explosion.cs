using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {



    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Missile" && other.gameObject.tag != "Torpedo") 
        {
            DestroyObject(gameObject);
            print("explosion");

            Moving.inc_ammo(); //see more: destroyitself.cs
            Moving.more_points(10); //if player attacks submarine by 3 misiles, he got 30 points, not 10.

        }
        else
        {
            DestroyObject(gameObject); 
            //dg
            Moving.inc_ammo(); //i set method inc_ammo as static because i have problem with inheritance (GetComponent don't work correctly)
        }

    }
        
}
