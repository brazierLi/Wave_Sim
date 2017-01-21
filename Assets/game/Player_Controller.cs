using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour
{

    public float SpeedLimit = 4, SpeedJumpLimit;
    public float x = 0, y = 0, Mult = 0.4f, JumpHeight1 = 5, JumpHeight2 = 7, XConstent = 20;
    public bool HitGround = false, jump2 = false, canJump = false;
    public string CurrentHitTag = "";

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //keeps Gravity working
        y = GetComponent<Rigidbody2D>().velocity.y;

        //double jump
        if (jump2 && Input.GetButtonDown("Jump") && canJump)
        {
            y += Input.GetAxis("Jump") * JumpHeight2;
            jump2 = false;
        }
        //jump 1
        if (HitGround && Input.GetButtonDown("Jump"))
        {
            y += Input.GetAxis("Jump") * JumpHeight1;
            HitGround = false;
            jump2 = true;
        }
        //jump -> jump2
        if (!HitGround && Input.GetButtonUp("Jump"))
        {
            canJump = true;
        }

        //walking
        if (HitGround)
        {
            x = Input.GetAxis("Horizontal") * SpeedLimit;
        }
        //jump With no AD/<> input
        else if (!HitGround && y < 0 && !Input.GetButton("Horizontal"))
        {
            x *= 0.90f;
        }
        //Jump with AD/<> input
        else
        {
            x += Input.GetAxis("Horizontal") * SpeedJumpLimit;
        }
        //Limit xspeed
        x = x > SpeedLimit ? SpeedLimit : x < -SpeedLimit ? -SpeedLimit : x;
        //Sets Velocity
        GetComponent<Rigidbody2D>().velocity = new Vector2(x + XConstent, y);
        if (transform.position.x < GameObject.Find("Wave").transform.position.x) {
            Debug.Log("lose");
        }



    }

    public Collision2D CurrentHit;
    void OnCollisionStay2D(Collision2D col)
    {
        CurrentHit = col;
        HitGround = true;
        canJump = false;
        CurrentHitTag = col.gameObject.tag;
            Debug.Log("3");
    }
    void OnCollisionExit2D(Collision2D col)
    {
        CurrentHit = new Collision2D();
        CurrentHitTag = "";
    }
}
