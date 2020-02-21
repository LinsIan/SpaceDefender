//*******************************************
// Enemy
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*******************************************
// Class
//*******************************************
public class Enemy : CombatUnit
{
	//------------------------------------------------------
	// Variables
	//------------------------------------------------------
	protected EnemyData       mData;

	//------------------------------------------------------
	// Accessors
	//------------------------------------------------------
	public EnemyData EnemyData
	{
		set { mData = value; }
	}

	public EColor Color
	{
		get { return mData.Color; }
	}

	//------------------------------------------------------
	// Override Functions
	//------------------------------------------------------
	protected override void Initialize()
	{
		mHP          = mData.MaxHP;
	}

	protected override void Die()
	{
		//play explosion effect & SE
		ObjectPooler.Instance.GetEnemyPool(mData.ID).BackToPool(this);
	}

	//------------------------------------------------------
	// Virtual Functions
	//------------------------------------------------------
	protected virtual void Move()
	{
		transform.position = transform.position - Vector3.left * mData.MoveSpeed * Time.deltaTime;	
	}

	//------------------------------------------------------
	// Main Functions
	//------------------------------------------------------
	public void Initialize(EnemyData iEnemyData)
	{
		mData         = iEnemyData;
		Initialize();
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == GameTags.TAG_SPACECRAFT)
		{
			other.gameObject.GetComponent<Spacecraft>().OnHurt(mData.Damage);
		}
	}

}