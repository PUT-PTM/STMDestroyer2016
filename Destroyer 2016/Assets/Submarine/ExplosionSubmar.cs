using UnityEngine;
using System.Collections;

public class ExplosionSubmar : MonoBehaviour {
    public ParticleSystem p;
   
    void OnCollisionEnter2D(Collision2D other)
    {
        p.Play();
        print("play");

        StartCoroutine(i());

      
    }
    IEnumerator i()
    {
      
        yield return new WaitForSeconds(0.5f);
        DestroyObject(gameObject);
    }
}
