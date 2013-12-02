using UnityEngine;
using System.Collections;

public class RailAttack : MonoBehaviour {


	public float lifeTime;
	// Use this for initialization
	void Start () {
		Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
		RaycastHit[] hits;
		hits = Physics.RaycastAll(ray,20f);
		Debug.DrawRay(ray.origin, ray.direction * 200);
		foreach(RaycastHit hit in hits)
		{

			if(hit.collider.gameObject.tag == "Enemy")
			{
				
				Debug.Log("HITRAYENEMY");
				hit.collider.gameObject.GetComponent<HealthScript>().ChangeHealth(-50);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		lifeTime -= Time.deltaTime;

		if(lifeTime < 0)
		{
			Destroy(gameObject);
		}
	}
}
