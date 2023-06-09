using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour {

	private GameObject Player = null;
	private float offset;

	// Use this for initialization
	void Start () {
		if (Player == null)
				Player = GameObject.FindGameObjectWithTag("Player");
		offset = transform.position.y - Player.transform.position.y;
	}
	// Update is called once per frame
	void Update () {
		var Pos = new Vector2(transform.position.x, Player.transform.position.y);
		transform.position = Pos;
		Debug.Log(Pos);

	}
}
