//*******************************************
// Object Pooler
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*******************************************
// Class
//*******************************************
public class ObjectPooler : Singleton<ObjectPooler>
{
	//------------------------------------------------------
	// Constants
	//------------------------------------------------------
	private const int INIT_BULLET_NUM = 10;
	private const int INIT_ENEMY_NUM  = 5;

	//------------------------------------------------------
	// Variables
	//------------------------------------------------------
	private Dictionary<int,ObjectPool> mBulletPoolMap;
	private Dictionary<int,ObjectPool> mEnemyPoolMap;

	//------------------------------------------------------
	// Accessors
	//------------------------------------------------------
	public Dictionary<int,ObjectPool> EnemyPoolMap
	{
		get { return mEnemyPoolMap; }
	}

	//------------------------------------------------------
	// Override Functions
	//------------------------------------------------------
	public override void Initialize()
	{
		mBulletPoolMap = new Dictionary<int, ObjectPool>();
		mEnemyPoolMap  = new Dictionary<int, ObjectPool>();
	}


	//------------------------------------------------------
	// Main Functions
	//------------------------------------------------------
	public void Clear(){}

	public ObjectPool GetBulletPool(int iBulletID)
	{
		if(mBulletPoolMap.ContainsKey(iBulletID))
		{
			return mBulletPoolMap[iBulletID];
		}
		else
		{
			return CreateBulletPool(iBulletID);
		}
	}

	public ObjectPool GetEnemyPool(int iEnemyID)
	{
		if(mEnemyPoolMap.ContainsKey(iEnemyID))
		{
			return mEnemyPoolMap[iEnemyID];
		}
		else
		{
			return CreateEnemyPool(iEnemyID);
		}
	}

	private ObjectPool CreateBulletPool(int iID)
	{
		GameObject aBulletPrefab = DataManager.Instance.PrefabMapsData.BulletPrefabMap[iID];
		GameObject aNewObject    = new GameObject();
		ObjectPool aNewPool      = aNewObject.AddComponent<ObjectPool>();
		aNewObject.transform.SetParent(transform);
		aNewPool.Initialize(aBulletPrefab,INIT_BULLET_NUM);
		mBulletPoolMap.Add(iID,aNewPool);
		return aNewPool;
	}

	private ObjectPool CreateEnemyPool(int iID)
	{
		GameObject aEnemyPrefab = DataManager.Instance.PrefabMapsData.EnemyPrefabMap[iID];
		GameObject aNewObject   = new GameObject();
		ObjectPool aNewPool     = aNewObject.AddComponent<ObjectPool>();
		aNewObject.transform.SetParent(transform);
		aNewPool.Initialize(aEnemyPrefab,INIT_ENEMY_NUM);
		mEnemyPoolMap.Add(iID,aNewPool);
		return aNewPool;
	}

}
