using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {


	public List<GameObject> spawnPoints;

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			for(int i = 0; i < spawnPoints.Count; i++)
			{
				Instantiate(Resources.Load("Enemy"),spawnPoints[i].transform.position,Quaternion.identity);
				Destroy(gameObject);
			}
		}
	}
}
