using UnityEngine;
using System.Collections;

public class ReturnButton : MonoBehaviour {
	
	// Use this for initialization
	void Update () {
		if(Input.GetKey(KeyCode.Escape))
		{
			Application.LoadLevel("Menu");
		}
	}
}