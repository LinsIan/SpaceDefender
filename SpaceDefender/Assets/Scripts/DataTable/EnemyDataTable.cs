//*******************************************
// EnemyDataTable
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*******************************************
// Class
//*******************************************
[CreateAssetMenu(menuName = "Data/Datable/Create EnemyDataTable")]
public class EnemyDataTable : ScriptableObject
{
	//------------------------------------------------------
	// Data
	//------------------------------------------------------
	public List<EnemyData> DataMap;
}
