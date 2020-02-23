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
	private EGameState            mGameState;
	private UpdateEvent           mUpdateEvent;
	private Spacecraft            mPlayer;
	private PlayerInputController mPlayerInputController;
	private List<EnemySpawner>    mEnemySpawnerList;
	
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
		SetInstance();
		CreateSigleton<AudioSystem> ();
		CreateSigleton<ObjectPooler>();
		CreateSigleton<UIManager>   ();
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

	private void StartMenu_StartEvent()
	{
		UIManager.Instance.CreateMenu<StartMenu>();
		mEnemySpawnerList = new List<EnemySpawner>();
	}
	private void GamePlay_StartEvent()
	{
		mPlayer                = FindObjectOfType(typeof(Spacecraft)) as Spacecraft;
		mPlayerInputController = FindObjectOfType(typeof(PlayerInputController)) as PlayerInputController;
		Object [] aSpawnerList = Resources.FindObjectsOfTypeAll(typeof(EnemySpawner));
		for(int i=0; i<aSpawnerList.Length; ++i)
		{
			mEnemySpawnerList.Add(aSpawnerList[i] as EnemySpawner);
		}
		mPlayerInputController.Initialize(mPlayer);
		mPlayer.Initialize();
		for(int i=0; i<mEnemySpawnerList.Count; ++i)
		{
			mEnemySpawnerList[i].Initialize();
		}

	//	UIManager.Instance.CreateMenu<GamePlayMenu>();
	}
	private void GameOver_StartEvent(){}

	private void GamePlay_UpdateEvent()
	{

	}


}
