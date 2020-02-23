//*******************************************
// Combat Unit
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*******************************************
// Class
//*******************************************
public abstract class CombatUnit : MonoBehaviour
{

	//------------------------------------------------------
	// Variables
	//------------------------------------------------------
	protected bool  mIsInitialized = false;
	protected float mHP;

	//------------------------------------------------------
	// Virtual Functions
	//------------------------------------------------------
	public virtual void OnHurt(float iDamage)
	{
		mHP -= iDamage;
		if(mHP <= 0)
		{
			Die();
		}
	}

	//------------------------------------------------------
	// Abstract Functions
	//------------------------------------------------------
	public    abstract void Initialize();
	protected abstract void Die();

	

}
