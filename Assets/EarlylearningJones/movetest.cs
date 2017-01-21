using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movetest : MonoBehaviour {



    public float speed = 100;
    [System.NonSerialized]
    public float altspeed = 0;
    public Vector3 vel = new Vector3(0, 0);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        /*
        if (Input.GetKey(KeyCode.W))
        {
            vel.y = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            vel.x = -1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vel.y = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            vel.x = 1;
        }
        else
        {
            vel = new Vector3(0, 0);
        }
        */
        vel.x = Input.GetAxis("Mouse X");
        vel.y = Input.GetAxis("Mouse Y");
        Cursor.visible = false;
       GetComponent<Rigidbody>().velocity = vel*(speed+altspeed)*Time.fixedDeltaTime;
	}
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Hey");


    }
}
