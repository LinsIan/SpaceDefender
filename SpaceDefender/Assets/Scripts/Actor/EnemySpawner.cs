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
	protected const float MAX_SPAWN_INTERVAL = 1.5f;
	protected const float MIN_SPAWN_INTERVAL = 1.0f;


	//------------------------------------------------------
	// Variables
	//------------------------------------------------------
	private int                               mEnemyNum;
	private float                             mSpawnTimer;
	private float                             mSpawnInterval;
	private Dictionary<int,ObjectPool<Enemy>> mEnemyPoolMap;

	//------------------------------------------------------
	// Main Functions
	//------------------------------------------------------
	public void Initialize(Dictionary<int,ObjectPool<Enemy>> iEnemyPoolMap, Transform iPlayer)
	{
		mEnemyPoolMap = iEnemyPoolMap;
		Initialize();
	}

	private void Initialize()
	{
		mSpawnInterval = Random.Range(MIN_SPAWN_INTERVAL,MAX_SPAWN_INTERVAL);
		mSpawnTimer    = 0;
		mEnemyNum      = System.Enum.GetValues(typeof(EColor)).Length;
	}

	private void Update()
	{
		Spawn();
	}

	private void Spawn()
	{
		mSpawnTimer += Time.deltaTime;
		if(mSpawnTimer >= mSpawnInterval)
		{
			int       aEnemyID  = Random.Range(0,mEnemyNum);
			EnemyData aNewData  = DataManager.Instance.GetEnemyData(aEnemyID);
			Enemy     aNewEnemy = mEnemyPoolMap[aEnemyID].Get();

		//	aNewEnemy.transform.rotation = Quaternion.identity;
			aNewEnemy.Initialize(aNewData);

			mSpawnInterval = Random.Range(MIN_SPAWN_INTERVAL,MAX_SPAWN_INTERVAL);
			mSpawnTimer    = 0;
		}

	}
}
