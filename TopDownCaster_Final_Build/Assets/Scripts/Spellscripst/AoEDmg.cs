using UnityEngine;
using System.Collections;

public class AoEDmg : AoEBase {

	public int damage;

	public override void doToTarget(Collider col)
	{
		col.gameObject.GetComponent<HealthScript>().ChangeHealth(-damage);
	}
}
