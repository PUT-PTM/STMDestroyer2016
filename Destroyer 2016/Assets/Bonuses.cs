using UnityEngine;
using System.Collections;

public class Bonuses : MonoBehaviour {
    public GameObject health_bonus;
    public int addHealth;
    public int bonusFrequency;

    // Use this for initialization
    void Start () {
     
        StartCoroutine(i());
      
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void createBonus() {
        float y = 13;

        float x = Random.value;
        x *= 20;
        float temp = Random.value;
        if (temp < 0.5) x *= -1;


        Instantiate(health_bonus, new Vector2(x, y), Quaternion.identity);
        print("NewBonus");
        StartCoroutine(i());
    }

    IEnumerator i()
    {
        float a = Random.value * bonusFrequency;
        yield return new WaitForSeconds(a);
        createBonus();



        
    }




}
