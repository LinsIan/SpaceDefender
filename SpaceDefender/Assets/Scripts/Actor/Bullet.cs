//*******************************************
// Bullet
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*******************************************
// Bullet Growth Rate Struct
//*******************************************
public struct BulletGrowthRate
{
	public float DamageRate;
	public float SpeedRate;
	public float SizeRate;
	public float DamageIntervalRate;

	public BulletGrowthRate(float iDamageRate = 1, float iSpeedRate = 1, float iSizeRate = 1, float iDamageIntervalRate = 1)
	{
		DamageRate         = iDamageRate;
		SpeedRate          = iSpeedRate;
		SizeRate           = iSizeRate;
		DamageIntervalRate = iDamageIntervalRate;
	}
}

//*******************************************
// Bullet Camp Enum
//*******************************************
public enum EBulletCamp
{
	Player,
	Enemy
}



//*******************************************
// Class
//*******************************************
public class Bullet:MonoBehaviour
{
	//------------------------------------------------------
	// Delegate
	//------------------------------------------------------
	public delegate void HealthRengenEvent(float iDamage);

	//------------------------------------------------------
	// Variables
	//------------------------------------------------------
	protected BulletData        mData;
	protected float             mLifeTimer;
	protected bool              mIsShot;

	//------------------------------------------------------
	// Accessors
	//------------------------------------------------------
	public BulletData Data
	{
		set { mData = value; }
	}

	//------------------------------------------------------
	// Main Functions
	//------------------------------------------------------
	public void Initialize(BulletData iData)
	{
		mData             = iData;
		Initialize();
	}

	public void Shot(EBulletCamp iCamp)
	{
		mIsShot    = true;
		mLifeTimer = 0;
	}

	protected void Initialize()
	{
		mIsShot    = false;
		mLifeTimer = 0;
	}

	protected void Move()
	{
		transform.position += transform.forward * mData.MoveSpeed * Time.deltaTime;
	}

	protected void CheckLifeTime()
	{
		mLifeTimer += Time.deltaTime;
		if(mLifeTimer >= mData.LifeTime)
		{
			ObjectPooler.Instance.GetBulletPool(mData.ID).BackToPool(this);
		}
	}

	private void Update()
	{
		if(mIsShot)
		{
			Move();
			CheckLifeTime();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == GameTags.TAG_ENEMY)
		{
			Enemy aEnemy = other.gameObject.GetComponent<Enemy>();
			if(mData.Color == aEnemy.Color)
			{
				aEnemy.OnHurt(mData.Damage);
			}
			ObjectPooler.Instance.GetBulletPool(mData.ID).BackToPool(this);
		}
	}

}