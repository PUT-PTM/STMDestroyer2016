using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ExplosionShip : MonoBehaviour {
    public ParticleSystem p;
    public int health = 100;
    public Text Htext;
    void Start()
    {
        Htext = GetComponent<Text>();
        Htext.text= "health:" + health.ToString();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("torpedo") == true)
        {
            health -= 20;


            if (health <= 0)
            {
                p.Play();
                StartCoroutine(i());

            }
        }
        else
        {
            health += 20;
            Destroy(other.gameObject);
            Htext.text = "health:" + health.ToString();
        }
            

        
        
    }
    IEnumerator i()
    {

        yield return new WaitForSeconds(2f);
        DestroyObject(gameObject);
    }
}
