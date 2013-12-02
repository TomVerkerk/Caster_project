using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	private float swordSound = 0;
	public AudioClip sword1;
	public AudioClip sword2;
	public AudioClip sword3;
	public AudioClip sword4;
	public AudioClip fireSound;
	public AudioClip iceSound;
	public AudioClip lightningSound;
	public AudioClip arcaneSound;
	public Connector connector;
	public GameObject meleeArea;
	public float attackTimeSet;
	private float attackTimeLeft;
	
	private PlayerMove moveScript;
	private GUIScript guiScript;
	
	private int fireSpellCount = 0;
	private int iceSpellCount = 0;
	private int lightningSpellCount = 0;
	private int arcaneSpellCount = 0;

	private spellTypes currentSpell = spellTypes.none;
	private bool attacking = false;

	public GameObject stageCamera;
	
	private enum spellTypes{
		none,
		fire,
		ice,
		lightning,
		arcane
	}
	

	void Start () 
	{
		//------Retrive External Scripts------\\
		moveScript = gameObject.GetComponent<PlayerMove>();
		guiScript = GameObject.Find("GUI").gameObject.GetComponent<GUIScript>();
	}



	void Update () 
	{
		stageCamera.transform.position = new Vector3(transform.position.x,stageCamera.transform.position.y,transform.position.z);

		connector.attacking = attacking;
		//-------------Select Spell-------------\\
		if(Input.GetButtonDown("SpellFire") && fireSpellCount > 0)
		{
			connector.sword = false;
			currentSpell = spellTypes.fire;
			guiScript.isFireActive();
		}
		else if(Input.GetButtonDown("SpellIce") && iceSpellCount > 0)
		{
			connector.sword = false;
			currentSpell = spellTypes.ice;
			guiScript.isIceActive();
		}
		else if(Input.GetButtonDown("SpellLightning") && lightningSpellCount > 0)
		{
			connector.sword = false;
			currentSpell = spellTypes.lightning;
			guiScript.isLightningActive();
		}
		else if(Input.GetButtonDown("SpellArcane") && arcaneSpellCount > 0)
		{
			connector.sword = false;
			currentSpell = spellTypes.arcane;
			guiScript.isArcaneActive();
		}

		//-----Count Down Attack Timer-----\\
		if(attacking)
		{
			attackTimeLeft -= Time.deltaTime;
			
			if(attackTimeLeft < 0)
			{
				connector.sword = true;
				attacking = false;
				moveScript.attacking = false;
			}
		}
		
		//-----------When attack Button is Pressed-----------\\
		if (Input.GetButtonDown("Fire1") && !attacking) 
		{
			guiScript.clearIconState();
			guiScript.meleeTex.enabled = true;

			//-----Start Attack Timer-----\\
			attackTimeLeft = attackTimeSet;
			attacking = true;
			moveScript.attacking = true;
			
			//--------------Calculate Direction--------------\\
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			Physics.Raycast(ray, out hit);
			
			
			float xDiff  = hit.point.x - gameObject.transform.position.x;
			float zDiff  = hit.point.z - gameObject.transform.position.z;
			Vector3 attackPos;
			
			if(Mathf.Abs(zDiff) < Mathf.Abs(xDiff))
			{
				attackPos = new Vector3(xDiff / Mathf.Abs(xDiff),0f,0f);
			}
			else
			{
				attackPos = new Vector3(0f,0f,zDiff / Mathf.Abs(zDiff));
			}
			connector.attackDir = attackPos;
			//-----different attacks-----\\

			GameObject spell = null;
			switch(currentSpell)
			{

			case spellTypes.none:

				if(swordSound == 4)
				{
					audio.PlayOneShot(sword4);
				}
				if(swordSound == 2 || swordSound == 5)
				{
					audio.PlayOneShot(sword3);
				}
				if(swordSound == 3 || swordSound == 7)
				{
					audio.PlayOneShot(sword2);
				}
				else
				{
					audio.PlayOneShot(sword1);
				}
				swordSound +=1;
				swordSound = swordSound % 10;
				
				PlaceAtAttackPos(meleeArea,attackPos);

				Collider[] meleeCollision = Physics.OverlapSphere(meleeArea.transform.position, 1);
				foreach(Collider col in meleeCollision)
				{
					if(col.tag == "Enemy")
					{
						col.gameObject.GetComponent<HealthScript>().ChangeHealth(-20);
					}
				}
				break;
				
			case spellTypes.fire:
				audio.PlayOneShot(fireSound);
				spell = Instantiate(Resources.Load("Spells/FireSpell"),attackPos,Quaternion.identity) as GameObject;
				fireSpellCount --;
				guiScript.ChangeFireNum(fireSpellCount);
				currentSpell = spellTypes.none;
				break;

			case spellTypes.ice:
				audio.PlayOneShot(iceSound);
				spell = Instantiate(Resources.Load("Spells/IceSpell"),attackPos,Quaternion.identity) as GameObject;
				iceSpellCount --;
				guiScript.ChangeIceNum(iceSpellCount);
				currentSpell = spellTypes.none;
				break;
			
			case spellTypes.lightning:
				audio.PlayOneShot(lightningSound);
				spell = Instantiate(Resources.Load("Spells/LightningSpell"),attackPos,Quaternion.identity) as GameObject;
				lightningSpellCount --;
				guiScript.ChangeLightningeNum(lightningSpellCount);
				currentSpell = spellTypes.none;
				break;
				
			case spellTypes.arcane:
				audio.PlayOneShot(arcaneSound);
				spell = Instantiate(Resources.Load("Spells/ArcaneSpell"),attackPos,Quaternion.identity) as GameObject;
				arcaneSpellCount --;
				guiScript.ChangeArcaneNum(arcaneSpellCount);
				currentSpell = spellTypes.none;
				break;
			}


			if(spell != null)
			{
				PlaceAtAttackPos(spell,attackPos);


				Vector3 target = new Vector3(hit.point.x,0f,hit.point.z);
				spell.gameObject.transform.LookAt(target);
			}
			
			
            
        }
		
	}


	void PlaceAtAttackPos(GameObject obj, Vector3 attPos)
	{
		obj.transform.parent = transform;
		obj.transform.localPosition = attPos;
		obj.transform.parent = null;
	}
	
	void OnTriggerEnter(Collider col)
	{

		if(col.gameObject.tag == "PickUp")
		{
			switch(col.name)
			{
			case "PickUpFire":
				fireSpellCount += 3;
				guiScript.ChangeFireNum(fireSpellCount);
				break;
				
			case "PickUpIce":
				iceSpellCount += 3;
				guiScript.ChangeIceNum(iceSpellCount);
				break;
				
			case "PickUpLightning":
				lightningSpellCount += 3;
				guiScript.ChangeLightningeNum(lightningSpellCount);
				break;
				
			case "PickUpArcane":
				arcaneSpellCount += 3;
				guiScript.ChangeArcaneNum(arcaneSpellCount);
				break;
			}

			
			Destroy(col.gameObject);
		}
	}

	void OnDestroy()
	{
		guiScript.endScreenOn (true);
	}


}
