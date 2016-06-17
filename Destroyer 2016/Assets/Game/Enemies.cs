using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Enemies : MonoBehaviour
{
    public GameObject Submarine;
    private float minY;
    private float maxY;
    private float difY;
    private int spawn_frequency;
    public int subs_to_produce;
    private int max_subs;
    private int subs_on_map;
    private bool pause;
    public Text NextLevel;
    public Text Winner;

    private int word_height, word_width;

    // Use this for initialization
    void Start()
    {
        NextLevel.enabled = false;
        Winner.enabled = false;
        //subs_to_produce = 3;
        max_subs = subs_to_produce;
        subs_on_map = 0;

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

    IEnumerator newScene()
    {


        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            NextLevel.enabled = true;
            yield return new WaitForSeconds(4);
            SceneManager.LoadScene("Level 2");
        }
        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            NextLevel.enabled = true;
            yield return new WaitForSeconds(4);
            SceneManager.LoadScene("Level 3");
        }
        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            Winner.enabled = true;
            yield return new WaitForSeconds(4);
            SceneManager.LoadScene("Menu");

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

    void Update()
    {

        subs_on_map = current_subs_quantity();
        if (subs_to_produce == 0 && subs_on_map == 0)
        {
            StartCoroutine(newScene());
        }
    }

}
