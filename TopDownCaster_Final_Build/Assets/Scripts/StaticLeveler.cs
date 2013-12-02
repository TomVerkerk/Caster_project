using UnityEngine;
using System.Collections;

public class StaticLeveler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float posZ = transform.position.z;
		float posX = transform.position.x;
		transform.position = new Vector3(posX,-(posZ/4),posZ);
	}
}
