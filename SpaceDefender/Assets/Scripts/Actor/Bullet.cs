//*******************************************
// Bullet
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	public void Shot()
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