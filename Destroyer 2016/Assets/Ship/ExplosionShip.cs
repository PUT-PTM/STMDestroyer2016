using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ExplosionShip : MonoBehaviour {
    public ParticleSystem p;
    public AudioClip bomb_explosion;
    private AudioSource source;
    public int health = 100;
    public Text Htext;
    void Start()
    {
        source = GetComponent<AudioSource>();
        Htext = GetComponent<Text>();
        Htext.text = "health:" + health.ToString(); //it sometimes generates error
        
    }

    void OnGUI() //don't change name of function
    {
        GUI.Label(new Rect(10, 10, 200, 90), "Live:" + health); //show "live" of ship on screen
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Torpedo") == true)
        {
            source.Play();
            health -= 20;
            
            if (health <= 0)
            {
               
                p.Play();            
                StartCoroutine(i());

            }
        }
        else if(other.gameObject.tag.Equals("HealthBonus")==true)
        {
            
            health += 20;
            if (health > 100) health = 100;
            Destroy(other.gameObject);
            Htext.text = "health:" + health.ToString(); //it sometimes generates error
        }
            

        
        
    }
    IEnumerator i()
    {

        yield return new WaitForSeconds(2f);
        DestroyObject(gameObject);
    }
}