using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {

	public GUIText fireCount;
	public GUIText iceCount;
	public GUIText lightningCount;
	public GUIText arcaneCount;

	public GUITexture fireTex;
	public GUITexture iceTex;
	public GUITexture lightningTex;
	public GUITexture arcaneTex;

	public GUITexture fireActiveTex;
	public GUITexture iceActiveTex;
	public GUITexture lightningActiveTex;
	public GUITexture arcaneActiveTex;

	public GUITexture meleeTex;

	public GUITexture endScreen;
	public GUIText endText;

	public AudioClip winSound;
	

	public void ChangeFireNum(int num)
	{
		fireCount.text = "" + num;
		if(num > 0)
		{
			fireTex.enabled = true;
		}
		else
		{
			fireTex.enabled = false;
		}
	}
	public void ChangeIceNum(int num)
	{
		iceCount.text = "" + num;
		if(num > 0)
		{
			iceTex.enabled = true;
		}
		else
		{
			iceTex.enabled = false;
		}
	}
	public void ChangeLightningeNum(int num)
	{
		lightningCount.text = "" + num;
		if(num > 0)
		{
			lightningTex.enabled = true;
		}
		else
		{
			lightningTex.enabled = false;
		}
	}
	public void ChangeArcaneNum(int num)
	{
		arcaneCount.text = "" + num;
		if(num > 0)
		{
			arcaneTex.enabled = true;
		}
		else
		{
			arcaneTex.enabled = false;
		}
	}


	public void clearIconState()
	{
		fireActiveTex.enabled = false;
		iceActiveTex.enabled = false;
		lightningActiveTex.enabled = false;
		arcaneActiveTex.enabled = false;
		meleeTex.enabled = false;
	}

	public void isSwordActive()
	{
		clearIconState();
		meleeTex.enabled = true;
	}
	public void isFireActive()
	{
		clearIconState();
		fireActiveTex.enabled = true;
	}
	public void isIceActive()
	{
		clearIconState();
		iceActiveTex.enabled = true;
	}
	public void isLightningActive()
	{
		clearIconState();
		lightningActiveTex.enabled = true;
	}
	public void isArcaneActive()
	{
		clearIconState();
		arcaneActiveTex.enabled = true;
	}
	public void endScreenOn(bool isDead)
	{
		StartCoroutine(endScreenTimer(isDead));;
	}
	private IEnumerator endScreenTimer(bool iSDead)
	{
		endScreen.enabled = true;
		endText.enabled = true;
		if(iSDead)
		{
			endText.text = "You Are Dead!";
		}
		else
		{
			audio.PlayOneShot(winSound);
			endText.text = "A winner is You!";
		}
		yield return new WaitForSeconds(4);
		Application.LoadLevel(0);
	}
}
