using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour {

    public float speed;
    private float range;
	public GameObject Missile;
    private bool push_missile; //permission to dropping ammo
    public int fire_pause; //interval between dropping both missiles
    private int drop_new_missile; //variable which has information when ship can drop next missile
    public int limit_ammo;
    private static int current_ammo; //static because method inc_ammo is also static
    private static int points; //static because method inc_ammo is also static
    public float bottomOfShip;
    public static bool switchSides = false;

	// Use this for initialization
	void Start () {
        range = 17.66f;
        speed = 3f;
        
        push_missile = false;
        drop_new_missile = fire_pause;
        current_ammo = limit_ammo;
        points = 0;
        
      //  float adjustShipForResolution_X = transform.localScale.x * Screen.width / 1200;
        //float adjustShipForResolution_Y = transform.localScale.y * Screen.height / 800;
        //float adjustShipForResolution_Z = adjustShipForResolution_X * 1.7f;

      //  transform.localScale = new Vector3(adjustShipForResolution_X, adjustShipForResolution_Y, adjustShipForResolution_Z);
      //  Debug.Log("Resolution:" + Screen.width + "x" + Screen.height);
	}

    public static void inc_ammo() { current_ammo++; } //why static? see: DestroyItself.cs
    public static void more_points(int how_many) { points += how_many; }
    public static void less_points(int how_many) { points -= how_many; }

    void OnGUI() //don't change name of function
    {
        GUI.Label(new Rect(100, 10, 200, 90), "Ammo:" + current_ammo); //show "ammo" of ship on screen
        GUI.Label(new Rect(200, 10, 200, 90), "Points:" + points); //show points for player (ship) on screen
    }

	// Update is called once per frame
	void Update () {

		if (transform.position.x <= -range) 
        {
			transform.position = new Vector2 (-range, transform.position.y);
		} 
		else 
            if (transform.position.x >= range) 
            {
			    transform.position = new Vector2 (range, transform.position.y);
            }

		float move = Input.GetAxis ("Horizontal");

		move *= Time.deltaTime;
		move *= speed;
        if (switchSides)
        {
            move *= -1;
        }
		transform.Translate (move,0,0);

        if (push_missile)
        {
            drop_new_missile--;
            if (drop_new_missile <= 0)
            {
                drop_new_missile = fire_pause;
                push_missile = false;
            }
        }

		if (Input.GetButtonDown ("Fire1")) {
            if (push_missile == false && current_ammo > 0)
            {
                float x = transform.localPosition.x;

                float y = (float)bottomOfShip; //6.8

                Instantiate(Missile, new Vector2(x, y), Quaternion.identity);
                print("fire");

                push_missile = true;
                current_ammo--;
            }
		}

	
	}
}
