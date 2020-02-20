//*******************************************
// Bullet Data
//*******************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*******************************************
// Class
//*******************************************
public class BulletData
{
	//------------------------------------------------------
	// Constructors
	//------------------------------------------------------
	public BulletData(BulletData aData)
	{
		ID              = aData.ID;
		Damage          = aData.Damage;
		LifeTime        = aData.LifeTime;
		MoveSpeed       = aData.MoveSpeed;
		ShotSE          = aData.ShotSE;
		ExplosionEffect = aData.ExplosionEffect;
	}

	//------------------------------------------------------
	// Data Members
	//------------------------------------------------------
	public int ID;
	public float Damage;
	public float LifeTime;
	public float MoveSpeed;
	public GameObject ExplosionEffect;
	public AudioSource ShotSE;
}
