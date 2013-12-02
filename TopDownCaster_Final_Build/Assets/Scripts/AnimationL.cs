	using UnityEngine;
using System.Collections;

public class AnimationL : MonoBehaviour {

	public string Tex;
	public int Columns;
	public int Rows;
	private int Cells;
	public int Fps;
	float offsetX;
	float offsetY;
	public float extraOffsetX;
	public float extraOffsetY;
	private Texture2D myTexture;

	public void Animate()
	{
		Cells = Rows * Columns;

		int index = (int)(Fps * Time.time);
		index = index % Cells + 1;

		float rightX = 0 - (1f /Columns);
		float rightY = 1f /Rows;
		Vector2 size = new Vector2(rightX, rightY);
		
		myTexture = new Texture2D((int)rightX, (int)rightY);
		myTexture = Resources.Load(Tex, typeof(Texture2D)) as Texture2D;
		
		float uIndex = index % Columns;
		float vIndex = index/Columns;
		
		offsetX = (uIndex * rightX) + (extraOffsetX/1000);
		offsetY = 0 - (extraOffsetY/1000) +(vIndex * rightY);
		
		Vector2 offset = new Vector2(offsetX, offsetY);
		
		renderer.material.mainTexture = myTexture;
		renderer.material.SetTextureScale("_MainTex", size);
		renderer.material.SetTextureOffset("_MainTex", offset);
	}
}