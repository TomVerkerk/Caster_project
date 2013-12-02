using UnityEngine;
using System.Collections;

public class SpellMissile : MonoBehaviour {


	public float missileSpeed;
	public float flyTime;
	public string explosionName;

	void Start () {
	
	}


	void FixedUpdate () {

		rigidbody.velocity = Vector3.zero;
		rigidbody.AddRelativeForce(new Vector3(0f,0f,missileSpeed));

		flyTime -= Time.deltaTime;

		if(flyTime < 0)
		{
			explodeSpell();
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Terrain" || col.tag == "Enemy")
		{
			explodeSpell();
		}
	}

	private void explodeSpell()
	{
		Instantiate(Resources.Load("Spells/SpellExplosion/" + explosionName),transform.position,Quaternion.identity);
		Destroy(gameObject);
	}
}
