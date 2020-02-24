//*******************************************
// Enemy Data
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*******************************************
// Class
//*******************************************
public class EnemyData
{
	//------------------------------------------------------
	// Constructors
	//------------------------------------------------------
	public EnemyData(EnemyData aData)
	{
		ID              = aData.ID;
		MaxHP           = aData.MaxHP;
		MoveSpeed       = aData.MoveSpeed;
		Damage          = aData.Damage;
		Color           = aData.Color;
	}

	//------------------------------------------------------
	// Data Members
	//------------------------------------------------------
	public int ID;
	public float MaxHP;
	public float MoveSpeed;
	public float Damage;
	public EColor Color;
}
