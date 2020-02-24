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
	// Constants
	//------------------------------------------------------
	private const string PrefabMapsData_PATH  = "Datas/PrefabMapsData";
	private const string BulletDataTable_PATH = "Datas/BulletDataTable";
	private const string EnemyDataTable_PATH  = "Datas/EnemyDataTable";

	//------------------------------------------------------
	// Variables
	//------------------------------------------------------
	[SerializeField] private PrefabMapsData      mPrefabMapsData;
	[SerializeField] private BulletDataTable     mBulletDataTable;
	[SerializeField] private EnemyDataTable      mEnemyDataTable;

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
		mPrefabMapsData  = Resources.Load<PrefabMapsData> (PrefabMapsData_PATH);
		mBulletDataTable = Resources.Load<BulletDataTable>(BulletDataTable_PATH);
		mEnemyDataTable  = Resources.Load<EnemyDataTable> (EnemyDataTable_PATH);
	}

	//------------------------------------------------------
	// Main Functions
	//------------------------------------------------------
	public Dictionary<int,EnemyData> GetEnemyDataMap()
	{
		return new Dictionary<int,EnemyData>(mEnemyDataTable.DataMap);
	}

	public EnemyData GetEnemyData(int iID)
	{
		return new EnemyData(mEnemyDataTable.DataMap[iID]);
	}

	public Dictionary<int,BulletData> GetBulletDataMap()
	{
		return new Dictionary<int,BulletData>(mBulletDataTable.DataMap);
	}

	public BulletData GetBulletData(int iID)
	{
		return new BulletData(mBulletDataTable.DataMap[iID]);
	}
}
