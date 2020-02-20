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
		Money           = aData.Money;
		ExplosionSound  = aData.ExplosionSound;
		ExplosionEffect = aData.ExplosionEffect;
	}

	//------------------------------------------------------
	// Data Members
	//------------------------------------------------------
	public int ID;
	public float MaxHP;
	public float MoveSpeed;
	public int Money;
	public AudioSource ExplosionSound;
	public GameObject ExplosionEffect;
}
