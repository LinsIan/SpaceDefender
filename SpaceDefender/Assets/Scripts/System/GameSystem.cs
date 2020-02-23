//*******************************************
// Game System
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*******************************************
// Game State Enum
//*******************************************
public enum EGameState
{
	StartMenu,
	GamePlay,
	GameOver
}

//*******************************************
// Class
//*******************************************
public class GameSystem : Singleton<GameSystem>
{
	//------------------------------------------------------
	// Delegate
	//------------------------------------------------------
	public delegate void UpdateEvent();

	//------------------------------------------------------
	// Constants
	//------------------------------------------------------

	//------------------------------------------------------
	// Variables
	//------------------------------------------------------
	private EGameState  mGameState;
	private UpdateEvent mUpdateEvent;
	
	//------------------------------------------------------
	// Main Functions
	//------------------------------------------------------
	public void ChangeState(EGameState iNewState)
	{
		switch(iNewState)
		{
			case EGameState.StartMenu:
				StartMenu_StartEvent();
				mUpdateEvent = null;
				break;
			case EGameState.GamePlay:
				GamePlay_StartEvent();
				mUpdateEvent = this.GamePlay_UpdateEvent;
				break;
			case EGameState.GameOver:
				GameOver_StartEvent();
				mUpdateEvent = null;
				break;
		}
	}

	private void Awake()
	{
		CreateSigleton<AudioSystem> ();
		CreateSigleton<ObjectPooler>();
		CreateSigleton<UIManager>   ();
		CreateSigleton<DataManager> ();
		ChangeState(EGameState.StartMenu);
	}

	private void Update() 
	{
		if(mUpdateEvent != null)
		{
			mUpdateEvent();
		}
	}

	private void CreateSigleton<TClass>()
		where TClass : Component
	{
		gameObject.AddComponent<TClass>();
	}

	private void StartMenu_StartEvent(){}
	private void GamePlay_StartEvent(){}
	private void GameOver_StartEvent(){}

	private void GamePlay_UpdateEvent(){}


}
