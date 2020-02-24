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
	protected const string INPUT_UP              = "Up";
	protected const string INPUT_DOWN            = "Down";

	//------------------------------------------------------
	// Variables
	//------------------------------------------------------
	private bool       mIsInitialized = false;
	private Spacecraft mPlayer;
	
	//------------------------------------------------------
	// Main Functions
	//------------------------------------------------------
	public void Initialize(Spacecraft iPlayer)
	{
		mPlayer        = iPlayer;
		mIsInitialized = true;
	}

	private void Update()
	{
		if(!mIsInitialized) { return; }
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

		if(Input.GetButton(INPUT_UP))
		{
			mPlayer.RotateLauncher(true);
		}

		if(Input.GetButton(INPUT_DOWN))
		{
			mPlayer.RotateLauncher(false);
		}

	}


}