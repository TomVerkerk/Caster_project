using UnityEngine;
using System.Collections;

public class AoEBase : MonoBehaviour {

	public float lifeTime;
	public bool isFromPlayer;

	protected void Start () {


		Collider[] meleeCollision = Physics.OverlapSphere(gameObject.transform.position, gameObject.transform.localScale.x);
		foreach(Collider col in meleeCollision)
		{
			if(col.tag == "Enemy" && isFromPlayer || col.tag == "Player" && !isFromPlayer)
			{
				doToTarget(col);
			}
		}
	}

	public virtual void doToTarget(Collider col)
	{

	}


	protected void FixedUpdate () {

		lifeTime -= Time.deltaTime;

		if(lifeTime < 0)
		{
			Destroy(gameObject);
		}
	}
}
