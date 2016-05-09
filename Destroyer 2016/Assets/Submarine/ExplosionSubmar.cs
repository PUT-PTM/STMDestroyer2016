using UnityEngine;
using System.Collections;

public class ExplosionSubmar : MonoBehaviour
{
    private ParticleSystem p;
    public bool damaged;
    void Start()
    {
        p = GetComponent<ParticleSystem>();
        damaged = false;

    }

    void OnCollisionEnter2D(Collision2D other)
    {
     
        p.Play();
        print("collision");
        damaged = true;
        StartCoroutine(i());


    }
    IEnumerator i()
    {

        yield return new WaitForSeconds(2f);
        DestroyObject(gameObject);
    }
}
