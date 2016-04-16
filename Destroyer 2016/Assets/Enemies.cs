using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour {
    public GameObject Submarine;
    public float minY;
    public float maxY;
    public float difY;
    // Use this for initialization
    void Start () {
        StartCoroutine(i());
        maxY = -1;
        minY = -5;
        difY = maxY - minY;

    }

   
     IEnumerator i()
    {
        float a = Random.value * 5;
        yield return new WaitForSeconds(a);
        newEnemy();
        
    }
   
    void newEnemy () {



        float y = maxY + Random.value * difY * (-1); 

        float x = Random.value;
        if (x > 0.5) x = 15;
        else x = -15;

            Instantiate(Submarine, new Vector2(x, y), Quaternion.identity);
            print("NewSubmarine");
            StartCoroutine(i());
        
    }
}
