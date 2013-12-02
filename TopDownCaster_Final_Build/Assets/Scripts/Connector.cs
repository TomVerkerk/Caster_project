using UnityEngine;
using System.Collections;

public class Connector : MonoBehaviour {

	public Vector3 attackDir;
	public bool attacking = false;
	public bool sword = true;
	private bool right = true;
	private bool up = false;
	private bool left = false;
	private bool down = false;
	private float x;
	private float y;
	private AnimationL animLeft;
	private AnimationR animRight;

	// Use this for initialization
	void Start () {
		animLeft = GetComponent<AnimationL>();
		animRight = GetComponent<AnimationR>();
	}
	
	// Update is called once per frame
	void Update () {
		x = Input.GetAxis("Horizontal");
		y = Input.GetAxis("Vertical");

		if(attacking == true)
		{
			if(sword == true)
			{
				if(attackDir == new Vector3(0,0,1))
				{
					animRight.Tex = "Spritesheets/Attack_up_zwaard";
					transform.localScale = new Vector3((float)4.6,1,(float)4.6);
					animRight.Columns = 6;
					animRight.Rows = 3;
					animRight.Fps = 36;
					animRight.extraOffsetX = 30;
					animRight.extraOffsetY = 35;
					animRight.Animate();
				}
				if(attackDir == new Vector3(0,0,-1))
				{
					animRight.Tex = "Spritesheets/Attack_down_zwaard";
					transform.localScale = new Vector3((float)3.3,1,(float)4.1);
					animRight.Columns = 4;
					animRight.Rows = 4;
					animRight.Fps = 32;
					animRight.extraOffsetX = 5;
					animRight.extraOffsetY = 0;
					animRight.Animate();
				}
				if(attackDir == new Vector3(1,0,0))
				{
					animRight.Tex = "Spritesheets/Attack rechts_zwaard";
					transform.localScale = new Vector3((float)5,1,(float)4);
					animRight.Columns = 4;
					animRight.Rows = 4;
					animRight.Fps = 32;
					animRight.extraOffsetX = 0;
					animRight.extraOffsetY = 0;
					animRight.Animate();
				}
				if(attackDir == new Vector3(-1,0,0))
				{
					animLeft.Tex = "Spritesheets/Attack rechts_zwaard";
					transform.localScale = new Vector3((float)5,1,(float)4);
					animLeft.Columns = 4;
					animLeft.Rows = 4;
					animLeft.Fps = 32;
					animLeft.extraOffsetX = 0;
					animLeft.extraOffsetY = 0;
					animLeft.Animate();
				}
			}
			if(sword == false)
			{
				if(attackDir == new Vector3(0,0,1))
				{
					animRight.Tex = "Spritesheets/Attack_up_staff";
					transform.localScale = new Vector3((float)4.6,1,(float)4.6);
					animRight.Columns = 3;
					animRight.Rows = 6;
					animRight.Fps = 36;
					animRight.extraOffsetX = 70;
					animRight.extraOffsetY = 25;
					animRight.Animate();
				}
				if(attackDir == new Vector3(0,0,-1))
				{
					animRight.Tex = "Spritesheets/Attack_down_staff";
					transform.localScale = new Vector3((float)3.3,1,(float)3.8);
					animRight.Columns = 4;
					animRight.Rows = 4;
					animRight.Fps = 32;
					animRight.extraOffsetX = 30;
					animRight.extraOffsetY = 0;
					animRight.Animate();
				}
				if(attackDir == new Vector3(1,0,0))
				{
					animRight.Tex = "Spritesheets/Attack rechts_staff";
					transform.localScale = new Vector3((float)3.9,1,(float)3.1);
					animRight.Columns = 4;
					animRight.Rows = 4;
					animRight.Fps = 32;
					animRight.extraOffsetX = 10;
					animRight.extraOffsetY = 0;
					animRight.Animate();
				}
				if(attackDir == new Vector3(-1,0,0))
				{
					animLeft.Tex = "Spritesheets/Attack rechts_staff";
					transform.localScale = new Vector3((float)3.9,1,(float)3.1);
					animLeft.Columns = 4;
					animLeft.Rows = 4;
					animLeft.Fps = 32;
					animLeft.extraOffsetX = 10;
					animLeft.extraOffsetY = 0;
					animLeft.Animate();
				}
			}
		}
		if(x > 0 && attacking == false)
		{
			right = true;
			left = false;
			down = false;
			up = false;
			animRight.Columns = 3;
			animRight.Rows = 6;
			animRight.Fps = 16;
			animRight.extraOffsetX = 0;
			animRight.extraOffsetY = 0;
			if(sword == true)
			{
				animRight.Tex = "Spritesheets/Walk_rechts_zwaard";
				transform.localScale = new Vector3((float)3.4,1,(float)3.1);
				animRight.Animate();
			}
			if(sword == false)
			{
				animRight.Tex = "Spritesheets/Walk_rechts_staf";
				transform.localScale = new Vector3((float)3.3,1,(float)2.8);
				animRight.Animate();
			}
		}
		if(x < 0 && attacking == false)
		{
			right = false;
			left = true;
			down = false;
			up = false;
			animLeft.Columns = 3;
			animLeft.Rows = 6;
			animLeft.Fps = 16;
			animLeft.extraOffsetX = 0;
			animLeft.extraOffsetY = 0;
			if(sword == true)
			{
				animLeft.Tex = "Spritesheets/Walk_rechts_zwaard";
				transform.localScale = new Vector3((float)3.4,1,(float)3.1);
				animLeft.Animate();
			}
			if(sword == false)
			{
				animLeft.Tex = "Spritesheets/Walk_rechts_staf";
				transform.localScale = new Vector3((float)3.3,1,3);
				animLeft.Animate();
			}
		}
		if(y > 0 && x < 1 && x > -1 && attacking == false)
		{
			right = false;
			left = false;
			down = false;
			up = true;
			transform.localScale = new Vector3((float)3.7,1,(float)3.5);
			animRight.Columns = 3;
			animRight.Rows = 6;
			animRight.Fps = 16;
			animRight.extraOffsetX = 70;
			animRight.extraOffsetY = 27;
			if(sword == true)
			{
				animRight.Tex = "Spritesheets/Walk_up_zwaard";
				animRight.Animate();
			}
			if(sword == false)
			{
				animRight.Tex = "Spritesheets/Walk_up_staff";
				animRight.Animate();
			}
		}
		if(y < 0 && x < 1 && x > -1 && attacking == false)
		{
			down = true;
			up = false;
			left = false;
			right = false;
			animRight.Columns = 3;
			animRight.Rows = 6;
			animRight.Fps = 16;
			if(sword == true)
			{
				animRight.Tex = "Spritesheets/Walk_down_zwaard_fixed";
				transform.localScale = new Vector3((float)2.7,1,(float)3.2);
				animRight.extraOffsetX = -10;
				animRight.extraOffsetY = 0;
				animRight.Animate();
			}
			if(sword == false)
			{
				animRight.Tex = "Spritesheets/Walk_down_staff";
				transform.localScale = new Vector3((float)3.1,1,(float)2.7);
				animRight.extraOffsetX = 40;
				animRight.extraOffsetY = -15;
				animRight.Animate();
			}
		}
		if(x == 0 && y == 0 && attacking == false)
		{
			if(up == true)
			{
				animRight.Columns = 3;
				animRight.Rows = 9;
				animRight.Fps = 16;
				if(sword == true)
				{
					transform.localScale = new Vector3((float)3.6,1,(float)3);
					animRight.Tex = "Spritesheets/Idle_up_zwaard";
					animRight.extraOffsetX = 80;
					animRight.extraOffsetY = 17;
					animRight.Animate();
				}
				if(sword == false)
				{
					transform.localScale = new Vector3((float)3.8,1,(float)3.2);
					animRight.Tex = "Spritesheets/Idle_up_Staff";
					animRight.extraOffsetX = 63;
					animRight.extraOffsetY = 7;
					animRight.Animate();
				}
			}
			if(right == true)
			{
				animRight.Columns = 5;
				animRight.Rows = 6;
				animRight.Fps = 16;
				if(sword == true)
				{
					transform.localScale = new Vector3(3,1,(float)2.1);
					animRight.Tex = "Spritesheets/Idle_zwaard_rechts";
					animRight.extraOffsetX = -10;
					animRight.extraOffsetY = 0;
					animRight.Animate();
				}
				if(sword == false)
				{
					transform.localScale = new Vector3((float)2.8,1,(float)2.8);
					animRight.Tex = "Spritesheets/Idle_rechts_Staff_fixed";
					animRight.extraOffsetX = 20;
					animRight.extraOffsetY = -15;
					animRight.Animate();
				}
			}
			if(down == true)
			{
				animRight.Columns = 5;
				animRight.Rows = 6;
				animRight.Fps = 16;
				if(sword == true)
				{
					transform.localScale = new Vector3((float)2.5,1,(float)2);
					animRight.Tex = "Spritesheets/Idle_zwaard_down";
					animRight.extraOffsetX = 4;
					animRight.extraOffsetY = 0;
					animRight.Animate();
				}
				if(sword == false)
				{
					transform.localScale = new Vector3((float)3.1,1,(float)2.3);
					animRight.Tex = "Spritesheets/Idle_Staff";
					animRight.extraOffsetX = 29;
					animRight.extraOffsetY = -11;
					animRight.Animate();
				}
			}
			if(left == true)
			{
				animLeft.Columns = 5;
				animLeft.Rows = 6;
				animLeft.Fps = 16;
				if(sword == true)
				{
					transform.localScale = new Vector3(3,1,(float)2.1);
					animLeft.Tex = "Spritesheets/Idle_zwaard_rechts";
					animLeft.extraOffsetX = -10;
					animLeft.extraOffsetY = 0;
					animLeft.Animate();
				}
				if(sword == false)
				{
					transform.localScale = new Vector3((float)2.8,1,(float)2.8);
					animLeft.Tex = "Spritesheets/Idle_rechts_Staff_fixed";
					animLeft.extraOffsetX = 20;
					animLeft.extraOffsetY = 15;
					animLeft.Animate();
				}
			}
		}
	}
}