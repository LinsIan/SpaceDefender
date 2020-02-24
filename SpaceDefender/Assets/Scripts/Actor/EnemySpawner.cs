//*******************************************
// Enemy Spawner
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*******************************************
// Class
//*******************************************
public class EnemySpawner : MonoBehaviour
{
	//------------------------------------------------------
	// Constants
	//------------------------------------------------------
	protected const float MAX_SPAWN_INTERVAL = 7f;
	protected const float MIN_SPAWN_INTERVAL = 5f;


	//------------------------------------------------------
	// Variables
	//------------------------------------------------------
	private bool                       mIsInitialized = false;
	private int                        mEnemyNum;
	private float                      mSpawnTimer;
	private float                      mSpawnInterval;

	//------------------------------------------------------
	// Main Functions
	//------------------------------------------------------
	public void Initialize()
	{
		mSpawnInterval = Random.Range(MIN_SPAWN_INTERVAL,MAX_SPAWN_INTERVAL);
		mSpawnTimer    = 0;
		mEnemyNum      = System.Enum.GetValues(typeof(EColor)).Length;
		mIsInitialized = true;
	}

	private void Update()
	{
		if(!mIsInitialized) { return; }
		Spawn();
	}

	private void Spawn()
	{
		mSpawnTimer += Time.deltaTime;
		if(mSpawnTimer >= mSpawnInterval)
		{
			int       aEnemyID  = Random.Range(0,mEnemyNum);
			EnemyData aNewData  = DataManager.Instance.GetEnemyData(aEnemyID);
			Enemy     aNewEnemy = ObjectPooler.Instance.GetEnemyPool(aEnemyID).Get<Enemy>();

			aNewEnemy.transform.position = transform.position;
			aNewEnemy.Initialize(aNewData);

			mSpawnInterval = Random.Range(MIN_SPAWN_INTERVAL,MAX_SPAWN_INTERVAL);
			mSpawnInterval /= GameSystem.Instance.Difficulty;
			mSpawnTimer    = 0;
		}

	}
}
