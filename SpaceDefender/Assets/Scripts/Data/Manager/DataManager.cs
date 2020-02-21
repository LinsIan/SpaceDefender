//*******************************************
// Data Manager
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*******************************************
// Class
//*******************************************
public class DataManager : Singleton<DataManager>
{
	//------------------------------------------------------
	// Variables
	//------------------------------------------------------
	private PrefabMapsData      mPrefabMapsData;
	private BulletDataTable     mBulletDataTable;
	private EnemyDataTable      mEnemyDataTable;


	//------------------------------------------------------
	// Accessors
	//------------------------------------------------------
	public PrefabMapsData PrefabMapsData
	{
		get{ return mPrefabMapsData;  }
		set{ mPrefabMapsData = value; }
	}

	public EnemyDataTable EnemyDataTable
	{
		set{ mEnemyDataTable = value; }
	}

	public BulletDataTable BulletDataTable
	{
		set{ mBulletDataTable = value; }
	}

	//------------------------------------------------------
	// Override Functions
	//------------------------------------------------------	
	public override void Initialize()
	{
	}

	//------------------------------------------------------
	// Main Functions
	//------------------------------------------------------
	public List<EnemyData> GetEnemyDataMap()
	{
		return new List<EnemyData>(mEnemyDataTable.DataMap);
	}

	public EnemyData GetEnemyData(int iID)
	{
		return new EnemyData(mEnemyDataTable.DataMap[iID]);
	}

	public List<BulletData> GetBulletDataMap()
	{
		return new List<BulletData>(mBulletDataTable.DataMap);
	}

	public BulletData GetBulletData(int iID)
	{
		return new BulletData(mBulletDataTable.DataMap[iID]);
	}
}
