using UnityEngine;
using System.Collections;

public class AoESlow : AoEBase {

	public override void doToTarget(Collider col)
	{
		col.gameObject.GetComponent<EnemyAI>().xSpeed = (col.gameObject.GetComponent<EnemyAI>().xSpeed)/3;
		col.gameObject.GetComponent<EnemyAI>().zSpeed = (col.gameObject.GetComponent<EnemyAI>().zSpeed)/3;
	}
}
