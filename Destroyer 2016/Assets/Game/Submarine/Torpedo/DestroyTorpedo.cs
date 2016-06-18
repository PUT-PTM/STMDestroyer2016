using UnityEngine;
using System.Collections;

public class DestroyTorpedo : MonoBehaviour {

    public float waterSurface;
    private ParticleSystem p;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
  
    private AudioSource source;
    void Start () {
        p = GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();
        waterSurface = 7.35f;
	}

    IEnumerator i()
    {
        yield return new WaitForSeconds(5f);
        DestroyObject(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        source.Play();
        
            rb.isKinematic = true;
            sr.enabled = false;
      
        Vector3 v = new Vector3(0, 0, 0);
        p.transform.position = p.transform.localPosition+v;
        p.Play();
        StartCoroutine(i());
      
    }

    void Update()
    {
        if (transform.position.y > waterSurface)
        {
            DestroyObject(gameObject);
        }
    }
}
