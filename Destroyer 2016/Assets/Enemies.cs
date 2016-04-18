using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour {
    public GameObject Submarine;
    private float minY;
    private float maxY;
    private float difY;
    private int spawn_frequency;
    // Use this for initialization
    void Start () {
        spawn_frequency = 5;
        StartCoroutine(i());
        
        maxY = 5;
        minY = -8;
        difY = maxY - minY;

    }

   
     IEnumerator i()
    {
        float a = Random.value * spawn_frequency;
        yield return new WaitForSeconds(a);
        newEnemy();
        
    }
   
    void newEnemy () {



        float y = maxY + Random.value * difY * (-1); 

        float x = Random.value;
        if (x > 0.5) x = 25;
        else x = -25;

            Instantiate(Submarine, new Vector2(x, y), Quaternion.identity);
            print("NewSubmarine");
            StartCoroutine(i());
        
    }
}
