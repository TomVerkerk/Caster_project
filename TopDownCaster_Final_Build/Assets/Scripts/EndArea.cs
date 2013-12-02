using UnityEngine;
using System.Collections;

public class EndArea : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player")
		{
			GUIScript guiScript = GameObject.Find("GUI").gameObject.GetComponent<GUIScript>();
			guiScript.endScreenOn(false);
		}
	}
}
