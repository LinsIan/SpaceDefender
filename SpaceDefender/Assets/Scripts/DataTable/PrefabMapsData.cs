//*******************************************
// Prefab Maps Data
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;

//*******************************************
// Class
//*******************************************
[CreateAssetMenu(menuName = "Data/Datable/Create PrefabMapsData")]
public class PrefabMapsData : SerializedScriptableObject
{
	//------------------------------------------------------
	// Data Members
	//------------------------------------------------------
	public Dictionary<int,GameObject> EnemyPrefabMap;
	public Dictionary<int,GameObject> BulletPrefabMap;
	public Dictionary<Type,GameObject> UIPrefabMap;
}
