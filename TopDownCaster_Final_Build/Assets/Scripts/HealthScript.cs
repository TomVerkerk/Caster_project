using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public float health;
	public string deathEffect;

	public void ChangeHealth(float change)
	{
		Debug.Log("healthDown");
		health += change;

		if(health <= 0)
		{
			//Instantiate(Resources.Load("DeathEffects/" + deathEffect),transform.position,Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
