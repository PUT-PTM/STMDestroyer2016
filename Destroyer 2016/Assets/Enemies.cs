using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour
{
    public GameObject Submarine;
    private float minY;
    private float maxY;
    private float difY;
    private int spawn_frequency;
    private int subs_to_produce;
    private int max_subs;

    public GUIText WinText;

    // Use this for initialization
    void Start()
    {
        subs_to_produce = 3;
        max_subs = subs_to_produce;

        spawn_frequency = 5;
        StartCoroutine(i());

        maxY = 5;
        minY = -8;
        difY = maxY - minY;

        //GameObject mynewcard = (GameObject)Instantiate(card);
        //RectTransform rt = Submarine.GetComponent<RectTransform>();
        //float width = rt.rect.width; float height = rt.rect.height;
        //Debug.Log("wymiary okretu: " + width + "x" + height);
    }


    IEnumerator i()
    {
        float a = Random.value * spawn_frequency;
        yield return new WaitForSeconds(a);
        if (subs_to_produce > 0)
        {
            newEnemy();
            subs_to_produce--;
        }
    }

    void newEnemy()
    {

        float offScreenLeftSide = -25;
        float offScreenRightSide = 25;
        
        float y = maxY + Random.value * difY * (-1);

        float x = Random.value;
        if (x > 0.5) 
            x = offScreenRightSide;
        else 
            x = offScreenLeftSide;

        Instantiate(Submarine, new Vector2(x, y), Quaternion.identity);
        print("NewSubmarine");
        StartCoroutine(i());

    }
    

    int current_subs_quantity()
    {
        int counter = 0;

        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            //Debug.Log("name: " + o.name);
            if (o.name == "Submarine(Clone)")
                counter++;
        }
        
        return counter;
    }

    void OnGUI() //don't change name of function
    {

        int subs_on_map = current_subs_quantity();

        GUI.Label(new Rect(600, 10, 200, 90), "Submarines:" + subs_on_map + "/" + max_subs);

        if (subs_on_map == 0 && subs_to_produce == 0)
            {
                DeleteMovingObjects();
                Triumph();
            }
    }

    //dg
    public void DeleteMovingObjects()
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            if (o.name != "Camera" && o.name != "background")
                Destroy(o);
        }
    }

    //dg
    public void Triumph()
    {
        //need monit that player wins
        
        
        /*WinText.text = "Winner";
        WinText.enabled = true;*/
    }
}
