//*******************************************
// Spacecraft
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*******************************************
// Class
//*******************************************
public class Spacecraft : CombatUnit
{
	//------------------------------------------------------
	// Constants
	//------------------------------------------------------
	protected const string LAUNCHER_NAME = "Launcher";

	//------------------------------------------------------
	// Variables
	//-----------------------------------------------------
	protected Transform          mLauncher;
	protected float              mAttackTimer;
	protected ObjectPool<Bullet> mBulletPool;
	protected int                mBulletID;
	protected int                mBulletNum;

	//------------------------------------------------------
	// Override Functions
	//------------------------------------------------------
	protected override void Initialize() 
	{
		//create explosion gameobject
		FindLauncher();
		mBulletID         = 0;
		mAttackTimer      = 0;
		mBulletPool       = ObjectPooler.Instance.GetBulletPool(mBulletID);
		mBulletNum        = System.Enum.GetValues(typeof(EColor)).Length;
	}

	public override void OnHurt(float iDamage)
	{
		base.OnHurt(iDamage);
	}

	protected override void Die()
	{
		//play explosion effect & SE
		
	}

	//------------------------------------------------------
	// Main Functions
	//------------------------------------------------------
	public void ChangeBullet(bool iIsLeft)
	{
		int aAddAmount = iIsLeft ? mBulletID-- : mBulletID++;
		if(mBulletID < 0) { mBulletID = mBulletNum-1; }
		else              { mBulletID %= mBulletNum;  }
		mBulletPool       = ObjectPooler.Instance.GetBulletPool(mBulletID);
	}

	public void SetLauncherLookAt(Vector3 iPosition)
	{
		mLauncher.LookAt(iPosition);
	}

	protected void FindLauncher()
	{
		mLauncher = transform.Find(LAUNCHER_NAME);
	}

	protected void Attack()
	{
		mAttackTimer += Time.deltaTime;
		
		Bullet           aNewBullet           = mBulletPool.Get();
		BulletData       aNewBulletData       = DataManager.Instance.GetBulletData(mBulletID);
		aNewBullet.transform.position = mLauncher.position;
		aNewBullet.transform.LookAt(transform.position + transform.forward);
		aNewBullet.Initialize(aNewBulletData);
		aNewBullet.Shot(EBulletCamp.Player);
		
		mAttackTimer = 0;
	}

	private void Update()
	{
		Attack();
	}
}