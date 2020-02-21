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
	protected abstract void Initialize();
	protected abstract void Die();

	

}
