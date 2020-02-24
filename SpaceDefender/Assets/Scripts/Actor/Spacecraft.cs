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
	protected const float  ROATION_SPEED = 3f;

	//------------------------------------------------------
	// Variables
	//-----------------------------------------------------
	[SerializeField] protected float mAttackInterval;
	[SerializeField] protected float mMaxHP;
	protected Transform    mLauncher;
	protected float        mAttackTimer;
	protected ObjectPool   mBulletPool;
	protected int          mBulletID;
	protected int          mBulletNum;
	protected GamePlayMenu mGamePlayMenu;

	//------------------------------------------------------
	// Accessors
	//------------------------------------------------------
	public GamePlayMenu GamePlayMenu
	{
		set 
		{
			mGamePlayMenu = value;
			mGamePlayMenu.SetHP(mMaxHP);
		}
	}

	public float HP
	{
		get { return mHP; }
	}

	//------------------------------------------------------
	// Override Functions
	//------------------------------------------------------
	public override void Initialize() 
	{
		FindLauncher();
		mBulletID         = 0;
		mAttackTimer      = 0;
		mHP               = mMaxHP;
		mBulletPool       = ObjectPooler.Instance.GetBulletPool(mBulletID);
		mBulletNum        = System.Enum.GetValues(typeof(EColor)).Length;
		mIsInitialized    = true;
	}

	public override void OnHurt(float iDamage)
	{
		base.OnHurt(iDamage);
		mGamePlayMenu.SetHP(mHP);
	}

	protected override void Die()
	{}

	//------------------------------------------------------
	// Main Functions
	//------------------------------------------------------
	public void ChangeBullet(bool iIsLeft)
	{
		int aAddAmount = iIsLeft ? mBulletID-- : mBulletID++;
		if(mBulletID < 0) { mBulletID = mBulletNum-1; }
		else              { mBulletID %= mBulletNum;  }
		mBulletPool       = ObjectPooler.Instance.GetBulletPool(mBulletID);
		mGamePlayMenu.SetWeapon((EColor)mBulletID);
	}

	public void RotateLauncher(bool iIsUp)
	{
		if(iIsUp)
		{
			mLauncher.Rotate(new Vector3(0,-ROATION_SPEED,0));
		}
		else
		{
			mLauncher.Rotate(new Vector3(0,ROATION_SPEED,0));
		}
	}

	protected void FindLauncher()
	{
		mLauncher = transform.Find(LAUNCHER_NAME);
	}

	protected void Attack()
	{
		mAttackTimer += Time.deltaTime;
		if(mAttackTimer >= mAttackInterval)
		{
			Bullet     aNewBullet         = mBulletPool.Get<Bullet>();
			BulletData aNewBulletData     = DataManager.Instance.GetBulletData(mBulletID);
			aNewBullet.transform.position = mLauncher.position;
			aNewBullet.transform.LookAt(mLauncher.transform.position + mLauncher.transform.forward);
			aNewBullet.Initialize(aNewBulletData);
			aNewBullet.Shot();
			mAttackTimer = 0;
		}

	}

	private void Update()
	{
		if(!mIsInitialized) { return; }
		Attack();
	}
}