//*******************************************
// Bullet Data
//*******************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*******************************************
// Color Enum
//*******************************************
public enum EColor
{
	BLUE,
	YELLO,
	GREEN
}


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
		Color           = aData.Color;
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
	public EColor Color;
	public GameObject ExplosionEffect;
	public AudioSource ShotSE;
}
