using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public AudioClip enemySound;
	private bool played = false;
	public EnemyConnector enemy;

	private GameObject player;
	private Vector3 movement;
	private float actionTimer;
	private bool attackNext;

	private float xDiff;
	private float zDiff;

	public float xSpeed;
	public float zSpeed;

	public float attackTime;
	public float attackTelegrathTime;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(player)
		{
			rigidbody.velocity = Vector3.zero;
			actionTimer -= Time.deltaTime;

			if(!attackNext)
			{
				xDiff = player.transform.position.x - transform.position.x;
				zDiff = player.transform.position.z - transform.position.z;
			}

			if(actionTimer < 0)
			{
				enemy.attacking = true;

				if(attackNext)
				{
					if(played == false)
					{
						audio.PlayOneShot(enemySound);
						played = true;
					}
					Vector3 attackPos;

					if(Mathf.Abs(xDiff) < Mathf.Abs(zDiff))
					{
						attackPos = new Vector3(transform.position.x ,0f,transform.position.z + (zDiff/Mathf.Abs(zDiff)));
					}
					else
					{
						attackPos = new Vector3(transform.position.x + (xDiff/Mathf.Abs(xDiff)),0f,transform.position.z);
					}
					enemy.attackDir = attackPos - new Vector3(transform.position.x,transform.position.y,transform.position.z);

					Instantiate(Resources.Load("Spells/SpellExplosion/EnemyAttack"),attackPos,Quaternion.identity);
					actionTimer = attackTime;
					attackNext = false;


				}
				else if(Mathf.Abs(xDiff) < 2 && Mathf.Abs(zDiff) < 2)
				{
					enemy.attacking = false;
					movement = Vector3.zero;
					attackNext = true;
					actionTimer = attackTelegrathTime;
				}
				else
				{
					enemy.attacking = false;
					movement = new Vector3((xDiff/Mathf.Abs(xDiff))*xSpeed,0f,(zDiff/Mathf.Abs(zDiff))*zSpeed);
					actionTimer = 0.5f;
					enemy.walkDir = new Vector3(xDiff,0,zDiff);
				}


			}
			rigidbody.AddRelativeForce(movement);
		}
	}
}
