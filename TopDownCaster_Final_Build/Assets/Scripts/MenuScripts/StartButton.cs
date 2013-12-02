using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

	public string levelName;

	void OnMouseDown()
	{
		Application.LoadLevel(levelName);
	}
}
