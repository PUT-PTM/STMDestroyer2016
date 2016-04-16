using UnityEngine;
using System.Collections;

public class ExplosionShip : MonoBehaviour {
    public ParticleSystem p;
    public int health = 100;

    void OnCollisionEnter2D(Collision2D other)
    {
        health -= 20;
        Destroy(other.gameObject);
   
        if (health <= 0) {
            p.Play();
            StartCoroutine(i());

        }
        
    }
    IEnumerator i()
    {

        yield return new WaitForSeconds(2f);
        DestroyObject(gameObject);
    }
}
