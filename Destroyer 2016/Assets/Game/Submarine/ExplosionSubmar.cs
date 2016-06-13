using UnityEngine;
using System.Collections;

public class ExplosionSubmar : MonoBehaviour
{
    private ParticleSystem p;
    public AudioClip bomb_explosion;
    private AudioSource source;
    public bool damaged;

    void Start()
    {
        source = GetComponent<AudioSource>();
        p = GetComponent<ParticleSystem>();
        source = GetComponent<AudioSource>();
        damaged = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {

    
  
            source.Play();
            p.Play();
            print("collision");
            damaged = true;
            StartCoroutine(i());
        
    }

    IEnumerator i()
    {
        yield return new WaitForSeconds(5f); //3.5f
        DestroyObject(gameObject); 
    }
}
