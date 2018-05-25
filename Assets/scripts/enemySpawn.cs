using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour {

    public GameObject enemy;
    public GameObject camera;
    int timer = 60;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer -= 1;
        if(timer <= 0)
        {
            var projectile = (GameObject)Instantiate(enemy, new Vector2(Random.Range(26, 32), Random.Range(5, -10)), transform.rotation);
            timer = 60;
        }
    }
}
