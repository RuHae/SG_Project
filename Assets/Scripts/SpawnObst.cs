using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObst : MonoBehaviour {
	void Awake(){
		newObstacle(posi);
	}

	// Use this for initialization
	[SerializeField] GameObject[] hindernisse;
	[SerializeField] Transform player;
	public Queue<GameObject> obstQueue = new Queue<GameObject>();

	List<GameObject> hindernisseZumErscheinen = new List<GameObject>();
	public float posi;
	private int count = 0;
	private float firstSpawn;
	

	// Update is called once per frame
	void Update () {
		posi = player.position.y;
		if(((firstSpawn - 12f) > posi) && count <3){
			if(count == 0){
				firstSpawn = posi;
			}
			newObstacle(posi);
			count += 1;
			if(count >=2){
				count = 0;	
			}
		}
	}

	public void newObstacle(float posi)
	{	
		GameObject obst = Instantiate(hindernisse[Random.Range(0,hindernisse.Length)], this.transform) as GameObject;
		obst.transform.localPosition = new Vector3(Random.Range(7.3f,-7.3f),Random.Range(firstSpawn,firstSpawn-12f),0);
		obstQueue.Enqueue(obst);
		if(obstQueue.Count > 6){
			Destroy(obstQueue.Dequeue());
		}
	}
}