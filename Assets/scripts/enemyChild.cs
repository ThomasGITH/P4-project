using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyChild : MonoBehaviour {

    public bool isGrounded;
	
	// Update is called once per frame
	void Update () {

	}
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.tag == ("ground")) || (other.gameObject.tag == ("platform")))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if ((other.gameObject.tag == ("ground")) || (other.gameObject.tag == ("platform")))
        {
            isGrounded = false;
        }
    }
}
