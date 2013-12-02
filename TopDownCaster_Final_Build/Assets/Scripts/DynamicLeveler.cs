using UnityEngine;
using System.Collections;

public class DynamicLeveler : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		float posZ = transform.position.z;
		float posX = transform.position.x;
		transform.position = new Vector3(posX,-(posZ/4),posZ);
	}
}
