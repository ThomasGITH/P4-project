using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour {

    public int playerSpeed = 10, playerJumpPower = 1250;
    private int flipTimer, jumpsLeft = 2; //MAKES SURE ANIMATIONS DON'T FLIP DON'T FLIP TOO OFTEN
    public GameObject bulletPrefab, ground, platform;
    public new GameObject camera;
    private bool facingLeft = true, isGrounded = false;
    private float moveX, fallSpeed;
    Animator animator;

    int direction;

    // Update is called once per frame
    void Update () {
        playerMove();
        playerShoot();
        aliveCheck();
	}

    //GENERAL MOVEMENT
    void playerMove()
    {
        //CONTROLS
        moveX = Input.GetAxis("Horizontal");
        
        flipTimer -= 1;
        //PLAYER DIRECTION
        if(moveX < 0.0f && facingLeft == false)
        {
            if(flipTimer <= 0)
            {
                FlipPlayer();
            }
        }
        else if(moveX > 0.0f && facingLeft == true)
        {
            if (flipTimer <= 0)
            {
                FlipPlayer();
            }
        }

        //JUMP && GROUNDED-CHECK
        if (Input.GetButtonDown("Jump"))
        {
            if ((isGrounded)||(jumpsLeft > 0))
            {
                animator.SetTrigger("jump");
                isGrounded = false;
            }
        }
        
        //ANIMATION
        animator = gameObject.GetComponent<Animator>();
        if (((gameObject.GetComponent<Rigidbody2D>().velocity.x > 0.0075) || (gameObject.GetComponent<Rigidbody2D>().velocity.x < -0.0075)) && (isGrounded))
        {
            animator.SetInteger("mov", 1);
        }
        else if ((gameObject.GetComponent<Rigidbody2D>().velocity.y < 0) && (!isGrounded))
        { animator.SetInteger("mov", 3); }
        else { animator.SetInteger("mov", 0); }

        //PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    
        //FALLING DAMAGE
        if (!isGrounded) {
            fallSpeed = gameObject.GetComponent<Rigidbody2D>().velocity.y;
        }else if ((isGrounded) && (fallSpeed <= -20))
        {
            Death();
        }
    }

    //SHOOTING MECHANICS
    void playerShoot()
    {
        //MOUSE TRACKING, CONVERTS SCREEN TO WORLDPOINT
        Vector2 mousePos = Input.mousePosition;
        mousePos = camera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);

        //FIRE BULLETS
        if (Input.GetButtonDown("Fire1"))
        {
            if ((mousePos.x > transform.position.x) && (mousePos.y < transform.position.y + 3))
            {
                if (gameObject.transform.localScale.x > 0) { FlipPlayer(); flipTimer = 35; }
                direction = 1;
            }
            else if ((mousePos.x < transform.position.x) && (mousePos.y < transform.position.y + 3))
            {
                if (gameObject.transform.localScale.x < 0) {  FlipPlayer(); flipTimer = 35; }
                direction = 0;
            }
            else if (mousePos.y > transform.position.y + 3)
            {
                direction = 2;
            }
            animator.SetInteger("mov", 2);
        }
    }

    void shoot()
    {
        int startPoint;
        if(direction == 0)
        {
            startPoint = -2;
        }
        else { startPoint = 2; }
        var projectile = (GameObject)Instantiate(bulletPrefab, new Vector2(transform.position.x + startPoint, transform.position.y + 1), transform.rotation);
        projectile.GetComponent<bullet>().direction = direction;
    }

    void aliveCheck()
    {
        if (gameObject.transform.position.y < -25)
        {
            Death();
        }
    }

    void jump()
    {
        //JUMPING CODE
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        jumpsLeft -= 1;
    }

    void FlipPlayer()
    {
        facingLeft = !facingLeft;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void Death()
    {
        SceneManager.LoadScene("base");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.tag == "ground")|| (collision.gameObject.tag == "platform"))
        {
            jumpsLeft = 2;
            isGrounded = true;
        }
    }
}
