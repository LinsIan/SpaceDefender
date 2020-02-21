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
	// Variables
	//------------------------------------------------------
	[SerializeField] private Collider  mSpawnZone;
	[SerializeField] private Transform mSpawnPoint;
	private float                             mSpawnTimer;
	private bool                              mCanSpawn;
	private Transform                         mPlayer;
	private Dictionary<int,ObjectPool<Enemy>> mEnemyPoolMap;
	private List<int>                         mEnemyCumulativeWeight;

	//------------------------------------------------------
	// Accessors
	//------------------------------------------------------
	public bool CanSpawn
	{
		set{ mCanSpawn = value; }
	}

	//------------------------------------------------------
	// Main Functions
	//------------------------------------------------------
	public void SpawnByID(int iEnemyID)
	{
		Bounds    aBounds      = mSpawnZone.bounds;
		EnemyData aNewData     = DataManager.Instance.GetEnemyData(iEnemyID);
		Vector3   aDestination = new Vector3(
			Random.Range(aBounds.min.x,aBounds.max.x),
			Random.Range(aBounds.min.y,aBounds.max.y),
			Random.Range(aBounds.min.z,aBounds.max.z));

		Enemy aNewEnemy = mEnemyPoolMap[iEnemyID].Get();
		aNewEnemy.transform.position = mSpawnPoint.position;
		aNewEnemy.transform.rotation = Quaternion.identity;
		aNewEnemy.Initialize(aNewData);
	}

	public void Initialize(Dictionary<int,ObjectPool<Enemy>> iEnemyPoolMap, Transform iPlayer)
	{
		mEnemyPoolMap = iEnemyPoolMap;
		mPlayer       = iPlayer;
		Initialize();
	}

	private void Initialize()
	{
		mSpawnTimer            = 0;
		mCanSpawn              = false;
		mEnemyCumulativeWeight = new List<int>();
	}

	private void Update()
	{
		if(mCanSpawn)
		{
			Spawn();
		}
	}

	private void Spawn()
	{
		mSpawnTimer += Time.deltaTime;

		int aRandomNum = Random.Range(1,mEnemyCumulativeWeight[mEnemyCumulativeWeight.Count-1]);
		int aSelectedEnemyID = 0;


		Bounds    aBounds      = mSpawnZone.bounds;
		EnemyData aNewData     = DataManager.Instance.GetEnemyData(aSelectedEnemyID);
		Vector3   aDestination = new Vector3(
			Random.Range(aBounds.min.x,aBounds.max.x),
			Random.Range(aBounds.min.y,aBounds.max.y),
			Random.Range(aBounds.min.z,aBounds.max.z));

		Enemy aNewEnemy = mEnemyPoolMap[aSelectedEnemyID].Get();
		aNewEnemy.transform.position = mSpawnPoint.position;
		aNewEnemy.transform.rotation = Quaternion.identity;
		aNewEnemy.Initialize(aNewData);
		mSpawnTimer = 0;
	}

	private float GetRate(float iEnd,float iStart,float iCompetition)
	{
		return iStart + (iEnd - iStart)*iCompetition;
	}

}
