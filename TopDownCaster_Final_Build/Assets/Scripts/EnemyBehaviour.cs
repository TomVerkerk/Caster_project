using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	private float time;
	public float enemyspeed;
	private float diffX;
	private float diffZ;
	public float attackDistanceX;
	public float attackDistanceZ;
	public GameObject player;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		diffX = player.transform.position.x - transform.position.x;
		diffZ = player.transform.position.z - transform.position.z;
		if(diffX >= -attackDistanceX && diffX	 <=	 attackDistanceX &&
			diffZ >= -attackDistanceZ && diffZ <= attackDistanceZ)
		{
			Debug.Log(enemyspeed);
			Attack();
		}
		else {
		}
	}

	void Attack (){
		float playerx = player.transform.position.x;
		float playerz = player.transform.position.z;
		Vector3 target = new Vector3(playerx,0,playerz);
		time = time + 1;
		Debug.Log(time);
		if(time >=80)
		{
			transform.LookAt(target);
		}
		if(time>=100)
		{
			transform.Translate(Vector3.forward * enemyspeed * Time.deltaTime);
		}
	}
}
