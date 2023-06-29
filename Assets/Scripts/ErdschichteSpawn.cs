using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErdschichteSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] erdschicht;
	[SerializeField] Transform player;
	List<GameObject> erdschichtenZumErscheinen = new List<GameObject>();
	GameObject schicht1;
	GameObject schicht2;
	GameObject schicht3;
	public float posi;
	public float firstSpawn;
	int counter = 0;

	// Use this for initialization
	void Start () {
			newSchicht(0f);
			firstSpawn = 0f;
	}

	// Update is called once per frame
	void Update () {
		posi = player.position.y;
		if((firstSpawn - 23f) >= posi){
			firstSpawn = posi;
			newSchicht(posi);
		}
	}

	public void newSchicht(float posit)
	{ 
		if(counter == 0 ){
			schicht1 = Instantiate(erdschicht[Random.Range(0,erdschicht.Length)], this.transform) as GameObject;
			schicht1.transform.localPosition = new Vector3(0,posit+1f,0);
			counter = 1;
			Destroy(schicht2);
		}else if (counter == 1){
			schicht2 = Instantiate(erdschicht[Random.Range(0,erdschicht.Length)], this.transform) as GameObject;
			schicht2.transform.localPosition = new Vector3(0,posit+1f,0);
			counter = 2;
			Destroy(schicht3);
		}else if (counter == 2){
			schicht3 = Instantiate(erdschicht[Random.Range(0,erdschicht.Length)], this.transform) as GameObject;
			schicht3.transform.localPosition = new Vector3(0,posit+1f,0);
			counter = 0;
			Destroy(schicht1);
		}
	}
}
