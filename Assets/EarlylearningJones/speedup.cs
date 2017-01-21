using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedup : MonoBehaviour {
    public KeyCode [] speedincreaser;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float Add = 0;
        for (int i = 0; i < speedincreaser.Length; i++) {
            if (Input.GetKey(speedincreaser[i])) {
                Add += 500;
            }
        }
        GameObject.Find("Player Dot").GetComponent<movetest>().altspeed = Add;
	}
}
