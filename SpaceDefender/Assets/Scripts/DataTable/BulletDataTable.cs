//*******************************************
// BulletDataTable
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*******************************************
// Class
//*******************************************

[CreateAssetMenu(menuName = "Data/Datable/Create BulletDataTable")]
public class BulletDataTable : ScriptableObject
{
	//------------------------------------------------------
	// Data
	//------------------------------------------------------
	public List<BulletData> DataMap;
}
