using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    float x, y, z; bool k; int cos;
	// Use this for initialization
	void Start () {
        x = 0; y = 0; z = 0; k = false; cos = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //if (k) {x += 0.1f;} else {x -= 0.1f;}
        //transform.Rotate(new Vector3(x, transform.position.y, x));
        //Vector3 katy_obrotu = transform.eulerAngles;
        //transform.Rotate(transform.eulerAngles);
        var angles = transform.rotation.eulerAngles;
        if (angles.x > 90.3 || angles.x < 0) k = !k;
        /*
        if (cos == 500 * 2)
        {
            cos--;
            k = !k;
        }
        if (cos == 0)
        {
            cos++;
            k = !k;
        }

        if (k)
        {
            angles.x += Time.deltaTime * 10;
            cos++;
        }
        else
        {
            angles.x -= Time.deltaTime * 10;
            cos--;
        }
        */
        //angles.x += Time.deltaTime * 10;
        angles.y += Time.deltaTime * 10;
        angles.z += Time.deltaTime * 10;
        //if (angles.x >= 360)
          //  angles.x = 0;
        if (angles.y >= 360)
            angles.y = 0;
        if (angles.z >= 360)
            angles.z = 0;

        Debug.Log(angles.x + "/" + angles.y + "/" + angles.z);
        transform.rotation = Quaternion.Euler(angles);
	}
}
