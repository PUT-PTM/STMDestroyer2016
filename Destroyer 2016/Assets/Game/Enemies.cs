using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
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

    GUIStyle style = new GUIStyle();
    public GUIText WinText;

    private int word_height, word_width;

    // Use this for initialization
    void Start()
    {
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

        if (subs_to_produce == 0 && subs_on_map == 0)
        {
            style.fontSize = 30;
            if (SceneManager.GetActiveScene().name != "Level 3")
            {
                //GUI.Label(new Rect(500, 350, 100, 30), "Good! Next level...", style);
                word_width = 100; word_height = 30;
                GUI.Label(new Rect(Screen.width / 2 - word_width / 2, Screen.height / 2 - word_height / 2, word_width, word_height), "Next level...", style);
            }
            else
            {
                //GUI.Label(new Rect(575, 350, 100, 30), "Winner!", style);
                word_width = 100; word_height = 30;
                GUI.Label(new Rect(Screen.width / 2 - word_width / 2, Screen.height / 2 - word_height / 2, word_width, word_height), "Winner!", style);
            }
        }
        
    }

    void Update()
    {
        subs_on_map = current_subs_quantity();
        if (subs_on_map == 0 && subs_to_produce == 0)
        {
            DeleteMovingObjects();
            Triumph();
        }
    }

    //dg
    IEnumerator DeleteMovingObjects()
    {

        yield return new WaitForSeconds(60f);
        
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            if (o.name != "Camera" && o.name != "background")
                Destroy(o);
        }
    }

    //dg
    public void Triumph()
    {
        

        if(SceneManager.GetActiveScene().name=="Level 1")
        {
            //info że następny poziom
            SceneManager.LoadScene("Level 2");
        }
        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            //info że następny poziom
            SceneManager.LoadScene("Level 3");
        }
        if (SceneManager.GetActiveScene().name == "Level 3")
        {

            //need monit that player wins


            /*WinText.text = "Winner";
            WinText.enabled = true;*/
        }

    }
}
