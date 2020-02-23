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
	public List<GameObject> EnemyPrefabMap;
	public List<GameObject> BulletPrefabMap;
	public List<GameObject> UIPrefabMap;
}
