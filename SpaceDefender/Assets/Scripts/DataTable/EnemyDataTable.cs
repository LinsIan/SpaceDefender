//*******************************************
// EnemyDataTable
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

//*******************************************
// Class
//*******************************************
[CreateAssetMenu(menuName = "Data/Datable/Create EnemyDataTable")]
public class EnemyDataTable : SerializedScriptableObject
{
	//------------------------------------------------------
	// Data
	//------------------------------------------------------
	public Dictionary<int,EnemyData> DataMap;
}
