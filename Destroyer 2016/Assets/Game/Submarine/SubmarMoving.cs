using UnityEngine;
using System.Collections;

public class SubmarMoving : MonoBehaviour
{
    public GameObject Missile;
    public float speed;
    public float range;
    private int fire_frequency;
    public bool damaged;
    private ExplosionSubmar exS;
    public float upwardEveryFrame;

    // variable to hold a reference to our SpriteRenderer component
    private SpriteRenderer mySpriteRenderer;

    private void Awake()
    {
        // get a reference to the SpriteRenderer component on this gameObject
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start()
    {
        exS = GetComponent<ExplosionSubmar>();
        StartCoroutine(i());
        fire_frequency = 10;
        range = 20;
        speed = 2f;
        damaged = false;
        upwardEveryFrame = 1.5f;
    }

    IEnumerator i()
    {
        float a = Random.value * fire_frequency;
        if (a < 2) a = 2;
        yield return new WaitForSeconds(a);
        if (!exS.damaged)
        {
           fire();
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        float move = speed * Time.deltaTime;

        // if the variable isn't empty (we have a reference to our SpriteRenderer)
        if (mySpriteRenderer != null)
        {
            if (transform.position.x <= -range)
            {
                if (speed < 0)
                {
                    speed *= -1;
                    mySpriteRenderer.flipX = false;
                }
            }
            else if (transform.position.x >= range)
            {
                if (speed > 0)
                {
                    speed *= -1;
                    mySpriteRenderer.flipX = true;
                }
            }
        }

        transform.Translate(move, 0, 0);
    }

    void fire()
    {

        float x = transform.localPosition.x;

        float y = transform.localPosition.y;
        y += (float)upwardEveryFrame;

        Instantiate(Missile, new Vector2(x, y), Quaternion.identity);
        StartCoroutine(i());
    }


}
