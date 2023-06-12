using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyObstacleSpawner : MonoBehaviour {

	[SerializeField] GameObject[] hindernisse;
	List<GameObject> hindernisseZumErscheinen = new List<GameObject>();

	// Use this for initialization
	void Start () {
		InitialisiereHindernisse ();
	}

	// Update is called once per frame
	void Update () {

	}

	void InitialisiereHindernisse()
	{
		int index = 0;
		for (int i = 0; i < hindernisse.Length; i++)
		{
			GameObject obj = Instantiate (hindernisse [index], transform.position, Quaternion.identity);
			hindernisseZumErscheinen.Add (obj);
			index++;
			if (index == hindernisse.Length)
			{
				index = 0;
			}
		}
	}
}