using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour {
    public GameObject Submarine;
    // Use this for initialization
    void Start () {
        StartCoroutine(i());
    }

   
     IEnumerator i()
    {
        float a = Random.value * 10;
        yield return new WaitForSeconds(a);
        newEnemy();
        
    }
   
    void newEnemy () {



        float y = Random.value * -5;
        if (y > -2.5) y = -3;

        float x = Random.value;
        if (x > 0.5) x = 15;
        else x = -15;

            Instantiate(Submarine, new Vector2(x, y), Quaternion.identity);
            print("NewSubmarine");
            StartCoroutine(i());
        
    }
}
