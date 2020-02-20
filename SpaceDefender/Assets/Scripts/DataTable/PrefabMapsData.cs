//*******************************************
// Level Data
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//*******************************************
// Class
//*******************************************
[CreateAssetMenu(menuName = "Data/Datable/Create PrefabMapsData")]
public class PrefabMapsData : ScriptableObject
{
	//------------------------------------------------------
	// Data Members
	//------------------------------------------------------
	public Dictionary<int,GameObject> EnemyPrefabMap;
	public Dictionary<int,GameObject> BulletPrefabMap;
	public Dictionary<Type,GameObject> UIPrefabMap;
}
