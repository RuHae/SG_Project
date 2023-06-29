using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErdschichteSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] erdschicht;
	[SerializeField] Transform player;
	List<GameObject> erdschichtenZumErscheinen = new List<GameObject>();
	public float posi;
	public float firstSpawn;

	// Use this for initialization
	void Start () {
			newSchicht(0f);
			firstSpawn = 0f;
	}

	// Update is called once per frame
	void Update () {
		posi = player.position.y;
		if((firstSpawn - 12f) >= posi){
			firstSpawn = posi;
			newSchicht(posi);
		}
	}

	public void newSchicht(float posit)
	{ // obst in eine queque wenn ein paar drin sind die alten Löschen
	
		GameObject obst = Instantiate(erdschicht[Random.Range(0,erdschicht.Length)], this.transform) as GameObject;
		obst.transform.localPosition = new Vector3(0,posit+1f,0);
	}	
}
