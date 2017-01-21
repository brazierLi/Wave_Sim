using UnityEngine;
using System.Collections;

public class Camer_Controller : MonoBehaviour {

    public float yOffset = 5, zOffset = -10;
    GameObject Player;
    void Start() {
        Player = GameObject.Find("Player");
    }


	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Player.transform.position.x, yOffset, zOffset); ;
    }
}
