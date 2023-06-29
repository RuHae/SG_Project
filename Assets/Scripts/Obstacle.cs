using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	float speed = -1.2f;
	Rigidbody2D myBody;

	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		if(transform.position.x >= 7.3){
			speed = -speed;
		} else if(transform.position.x <= -7.4){
			speed = -speed;
		}
		myBody.velocity = new Vector2 (speed, 0);

	}
}