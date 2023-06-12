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

	}

	// Update is called once per frame
	void Update () {
			posi = player.position.y;
			if((firstSpawn - 15f) > posi){
				firstSpawn = posi;
				newSchicht(posi);
			}
	}

	public void newSchicht(float posi)
	{
		GameObject obst = Instantiate(erdschicht[Random.Range(0,erdschicht.Length-1)], this.transform) as GameObject;
		obst.transform.localPosition = new Vector3(Random.Range(7.3f,-7.3f),Random.Range(0,posi-15f),0);
	}	
}
