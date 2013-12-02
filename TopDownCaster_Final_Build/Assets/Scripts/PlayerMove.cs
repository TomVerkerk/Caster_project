using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	
	public float moveXSpeed;
	public float moveZSpeed;
	private float x;
	private float z;
	public bool attacking = false;

	
	// Update is called once per frame
	void FixedUpdate () {

		rigidbody.velocity = Vector3.zero;

		if(!attacking)
		{
			x = Input.GetAxis("Horizontal");
			z = Input.GetAxis("Vertical");
			
			Vector3 movement = new Vector3(x * moveXSpeed, 0f, z * moveZSpeed);
		
			rigidbody.AddRelativeForce(movement);
		}
	}
}
