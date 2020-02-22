//*******************************************
// Player Input Controller
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*******************************************
// Class
//*******************************************
public class PlayerInputController : MonoBehaviour
{
	//------------------------------------------------------
	// Constants
	//------------------------------------------------------
	protected const string INPUT_CHANGE_WEAPON_R = "ChangeWeaponR";
	protected const string INPUT_CHANGE_WEAPON_L = "ChangeWeaponL";

	//------------------------------------------------------
	// Variables
	//------------------------------------------------------
	private Spacecraft mPlayer;

	//------------------------------------------------------
	// Accessors
	//------------------------------------------------------
	public Spacecraft Player
	{
		set { mPlayer = value; }
	}
	
	//------------------------------------------------------
	// Main Functions
	//------------------------------------------------------
	private void Update()
	{
		GetPlayerInput();
	}

	private void GetPlayerInput()
	{
		if(Input.GetButtonDown(INPUT_CHANGE_WEAPON_L))
		{
			mPlayer.ChangeBullet(false);
		}

		if(Input.GetButtonDown(INPUT_CHANGE_WEAPON_R))
		{
			mPlayer.ChangeBullet(true);
		}

		Vector3 aMousePos = Camera.current.ScreenToWorldPoint(Input.mousePosition);
		aMousePos.z = mPlayer.transform.position.z;
		mPlayer.SetLauncherLookAt(aMousePos);
	}


}