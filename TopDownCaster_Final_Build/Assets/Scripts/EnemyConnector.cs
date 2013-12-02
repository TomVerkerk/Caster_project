using UnityEngine;
using System.Collections;

public class EnemyConnector : MonoBehaviour {
	
	public float animationTime;
	public Vector3 walkDir;
	public bool attacking;
	public Vector3 attackDir;
	private AnimationR animRight;
	private AnimationL animLeft;
	
	// Use this for initialization
	void Start () {
		animLeft = GetComponent<AnimationL>();
		animRight = GetComponent<AnimationR>();
	}
	
	// Update is called once per frame
	void Update () {
		if(attacking == false)
		{
			if(walkDir.x > 3)
			{
				animRight.Tex = "EnemySpritesheets/Walk_rechts2_monster";
				transform.localScale = new Vector3((float)3,1,(float)3);
				animRight.Columns = 6;
				animRight.Rows = 3;
				animRight.Fps = 16;
				animRight.extraOffsetX = 0;
				animRight.extraOffsetY = 0;
				animRight.Animate();
			}
			if(walkDir.x < -3)
			{
				animLeft.Tex = "EnemySpritesheets/Walk_rechts2_monster";
				transform.localScale = new Vector3((float)3,1,(float)3);
				animLeft.Columns = 6;
				animLeft.Rows = 3;
				animLeft.Fps = 16;
				animLeft.extraOffsetX = 0;
				animLeft.extraOffsetY = 0;
				animLeft.Animate();
			}
			if(walkDir.z > 3 && walkDir.x >-3 && walkDir.x < 3)
			{
				animRight.Tex = "EnemySpritesheets/Walk_up2_monster";
				transform.localScale = new Vector3((float)3,1,(float)3);
				animRight.Columns = 6;
				animRight.Rows = 3;
				animRight.Fps = 16;
				animRight.extraOffsetX = 0;
				animRight.extraOffsetY = 0;
				animRight.Animate();
			}
			if(walkDir.z < -3 && walkDir.x >-3 && walkDir.x < 3)
			{
				animRight.Tex = "EnemySpritesheets/Walk_down2_monster";
				transform.localScale = new Vector3((float)3,1,(float)3);
				animRight.Columns = 6;
				animRight.Rows = 3;
				animRight.Fps = 16;
				animRight.extraOffsetX = 0;
				animRight.extraOffsetY = 0;
				animRight.Animate();
			}
		}
		if(attacking == true)
		{
			if(attackDir == new Vector3(0,0,1))
			{
				animRight.Tex = "EnemySpritesheets/Attack_up1_monster";
				transform.localScale = new Vector3((float)5.5,1,(float)4.5);
				animRight.Columns = 6;
				animRight.Rows = 3;
				animRight.Fps = (int)(animRight.Columns*animRight.Rows/animationTime);
				animRight.extraOffsetX = 25;
				animRight.extraOffsetY = 20;
				animRight.Animate();
			}
			if(attackDir == new Vector3(0,0,-1))
			{
				animRight.Tex = "EnemySpritesheets/Attack_down_monster2";
				transform.localScale = new Vector3((float)4,1,(float)4);
				animRight.Columns = 8;
				animRight.Rows = 2;
				animRight.Fps = (int)(animRight.Columns*animRight.Rows/animationTime);
				animRight.extraOffsetX = 0;
				animRight.extraOffsetY = 0;
				animRight.Animate();
			}
			if(attackDir == new Vector3(1,0,0))
			{
				animRight.Tex = "EnemySpritesheets/Attack_rechts_monster_bijl";
				transform.localScale = new Vector3((float)4.7,1,(float)3.5);
				animRight.Columns = 8;
				animRight.Rows = 2;
				animRight.Fps = (int)(animRight.Columns*animRight.Rows/animationTime);
				animRight.extraOffsetX = 0;
				animRight.extraOffsetY = 0;
				animRight.Animate();
			}
			if(attackDir == new Vector3(-1,0,0))
			{
				animLeft.Tex = "EnemySpritesheets/Attack_rechts_monster_bijl";
				transform.localScale = new Vector3((float)4.7,1,(float)3.5);
				animLeft.Columns = 8;
				animLeft.Rows = 2;
				animRight.Fps = (int)(animRight.Columns*animRight.Rows/animationTime);
				animLeft.extraOffsetX = 0;
				animLeft.extraOffsetY = 0;
				animLeft.Animate();
			}
		}
	}
}
