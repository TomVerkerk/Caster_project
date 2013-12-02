using UnityEngine;
using System.Collections;

public class SpellAnimation : MonoBehaviour {

	public string Tex;
	public int Columns;
	public int Rows;
	public int Fps;
	public float extraOffsetX;
	public float extraOffsetY;
	private AnimationR animRight;
	
	// Use this for initialization
	void Start () {
		animRight = GetComponent<AnimationR>();
		animRight.index = 0;
	}
	
	// Update is called once per frame
	void Update () {
		animRight.Tex = Tex;
		animRight.Columns = Columns;
		animRight.Rows = Rows;
		animRight.Fps = Fps;
		animRight.extraOffsetX = extraOffsetX;
		animRight.extraOffsetY = extraOffsetY;
		animRight.Animate();
	}
}
