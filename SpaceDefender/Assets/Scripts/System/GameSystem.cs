//*******************************************
// Game System
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
	// Variables
	//------------------------------------------------------
	private float                 mGameDifficulty;
	private EGameState            mGameState;
	private UpdateEvent           mUpdateEvent;
	private Spacecraft            mPlayer;
	private PlayerInputController mPlayerInputController;
	private List<EnemySpawner>    mEnemySpawnerList;

	//------------------------------------------------------
	// Accessors
	//------------------------------------------------------
	public float GameDifficulty
	{
		get { return mGameDifficulty; }
	}
	
	//------------------------------------------------------
	// Main Functions
	//------------------------------------------------------
	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Exit()
	{
		Application.Quit();
	}

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
		GameObject aNewObj = new GameObject(typeof(TClass).Name);
		aNewObj.AddComponent<TClass>();
	}

	private void StartMenu_StartEvent()
	{
		Time.timeScale = 1;
		UIManager.Instance.CreateMenu<StartMenu>();
		mEnemySpawnerList = new List<EnemySpawner>();
	}
	private void GamePlay_StartEvent()
	{
		UIManager.Instance.DeleteMenu<StartMenu>();
		UIManager.Instance.DeleteMenu<GameOverMenu>();
		GamePlayMenu aGamePlayMenu = UIManager.Instance.CreateMenu<GamePlayMenu>();
		
		mPlayer                    = FindObjectOfType(typeof(Spacecraft)) as Spacecraft;
		mPlayerInputController     = FindObjectOfType(typeof(PlayerInputController)) as PlayerInputController;
		Object [] aSpawnerList     = Resources.FindObjectsOfTypeAll(typeof(EnemySpawner));
		
		for(int i=0; i<aSpawnerList.Length; ++i)
		{
			mEnemySpawnerList.Add(aSpawnerList[i] as EnemySpawner);
		}
		mPlayer.GamePlayMenu = aGamePlayMenu;
		mPlayerInputController.Initialize(mPlayer);
		mPlayer.Initialize();

		for(int i=0; i<mEnemySpawnerList.Count; ++i)
		{
			mEnemySpawnerList[i].Initialize();
		}

	}
	private void GameOver_StartEvent()
	{
		UIManager.Instance.DeleteMenu<GamePlayMenu>();
		UIManager.Instance.CreateMenu<GameOverMenu>();
		Time.timeScale = 0;
	}

	private void GamePlay_UpdateEvent()
	{
		if(mPlayer.HP <= 0)
		{
			ChangeState(EGameState.GameOver);
		}
	}


}
