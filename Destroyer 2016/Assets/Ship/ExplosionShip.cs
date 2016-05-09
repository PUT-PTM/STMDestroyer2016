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

    void OnGUI() //don't change name of function
    {
        GUI.Label(new Rect(10, 10, 200, 90), "Live:" + health); //show "live" of ship on screen
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