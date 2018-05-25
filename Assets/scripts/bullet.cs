using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public float bulletSpeed = 200;
    public GameObject player;
    private float moveX, moveY;
    public int direction;

    // Use this for initialization
    void Start () {
        if(direction == 2)
        {
            gameObject.transform.Rotate(Vector3.forward * -90);
        }
    }
	
	// Update is called once per frame
	void Update () {

        //DETERMINE DIRECTION
        if (direction == 0) {
            moveX = -1;
            moveY = GetComponent<Rigidbody2D>().velocity.y;
        }
        else if(direction == 1){
            moveX = 1;
            moveY = GetComponent<Rigidbody2D>().velocity.y;
        }
        else
        {
            moveX = GetComponent<Rigidbody2D>().velocity.x;
            moveY = 1 * bulletSpeed;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * bulletSpeed, moveY);
	}

    //VERANDER DIT LATER NOG
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
