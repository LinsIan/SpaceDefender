﻿//*******************************************
// Start Menu
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*******************************************
// Class
//*******************************************
public class StartMenu : MonoBehaviour
{
	//------------------------------------------------------
	// Main Functions
	//------------------------------------------------------
	public void GameStart()
	{
		GameSystem.Instance.ChangeState(EGameState.GamePlay);
	}

	public void ShowTutorial()
	{
		UIManager.Instance.CreateMenu<TutorialMenu>();
	}

}