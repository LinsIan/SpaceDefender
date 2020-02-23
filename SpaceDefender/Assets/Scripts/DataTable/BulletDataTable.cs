//*******************************************
// BulletDataTable
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

//*******************************************
// Class
//*******************************************

[CreateAssetMenu(menuName = "Data/Datable/Create BulletDataTable")]
public class BulletDataTable : SerializedScriptableObject
{
	//------------------------------------------------------
	// Data
	//------------------------------------------------------
	public Dictionary<int,BulletData> DataMap;
}
