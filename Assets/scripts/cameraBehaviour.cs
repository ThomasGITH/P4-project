using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBehaviour : MonoBehaviour {

    public GameObject player;
    public GameObject background;
    public float cameraSpeed = 2;
    private float moveX, moveY;

    // Update is called once per frame
    void Update () {
        cameraMovement();
    }

    void cameraMovement()
    {
        //HORIZONTAL MOVEMENT (Y)
        if ((player.gameObject.transform.position.x > 19.5) || (player.gameObject.transform.position.x < -20.5))
        {
            if ((gameObject.transform.position.x > 19.5) || (gameObject.transform.position.x < -20.5))
            {
                moveX = 0.0f;
            }
        }
        else
        {
            float distanceX = player.gameObject.transform.position.x - gameObject.transform.position.x;
            moveX = distanceX * cameraSpeed;
        }

        //VERTICAL MOVEMENT (Y)
        if ((player.gameObject.transform.position.y > 10.57165) || (player.gameObject.transform.position.y < -10.57165))
        {
            if ((gameObject.transform.position.y > 10.57165) || (gameObject.transform.position.y < -10.57165))
            {
                moveY = 0.0f;
            }
        }
        else
        {
            float distanceY = player.gameObject.transform.position.y - gameObject.transform.position.y;
            moveY = distanceY * cameraSpeed;
        }
        
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX, moveY);
        
    }
}
