using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour {

    private int enemyJumpPower = 600;
    private float moveX, enemySpeed = 6;
    private bool isGrounded, hasJumped;
    GameObject player;

    private void Start()
    {
        GameObject[] playerList = GameObject.FindGameObjectsWithTag("Player");
        player = playerList[0];
    }

    // Update is called once per frame
    void Update () {
        enemyMovement();
	}

    void enemyMovement()
    {
        isGrounded = gameObject.GetComponentInChildren<enemyChild>().isGrounded;

        if (isGrounded)
        {
            hasJumped = false;
        }

        //print("GROUNDED: " + isGrounded + " HASJUMPED: " + hasJumped);

        if (player.gameObject.transform.position.x < gameObject.transform.position.x)
        {
            moveX = -1;
        }
        else { moveX = 1; }

        if ((!isGrounded)&&(!hasJumped)) {
            jump();
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * enemySpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void jump()
    {
        //JUMPING CODE
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * enemyJumpPower);
        hasJumped = true;
    }
    /*
    void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.tag == ("ground"))|| (other.gameObject.tag == ("platform")))
        {
            isGrounded = true;
            hasJumped = false;
        }else if ((other.gameObject.tag == ("platform"))&&(gameObject.GetComponent<Rigidbody2D>().velocity.x == 0))
        {
            print("DETECTS STUCK");
            jump();
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if ((other.gameObject.tag == ("ground")) || (other.gameObject.tag == ("platform")))
        {
            isGrounded = false;
        }
    }
    */
}
