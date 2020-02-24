//*******************************************
// Singleton
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*******************************************
// Class
//*******************************************
public class Singleton<TClass> : MonoBehaviour
	where TClass : Component
{
	//------------------------------------------------------
	// Variables
	//------------------------------------------------------
	protected static TClass mInstance = null;

	//------------------------------------------------------
	// Accessors
	//------------------------------------------------------
	public static TClass Instance
	{
		get
		{
			if(mInstance == null)
			{
			//	Debug.LogError("Could not found singleton "+ typeof(TClass));
			}
			return mInstance;
		}
	}

	//------------------------------------------------------
	// Virtual Functions
	//------------------------------------------------------
	public virtual void Initialize(){}
	
	//------------------------------------------------------
	// Main Functions
	//------------------------------------------------------
	private void Awake()
	{
		SetInstance();
		Initialize();
	}

	public void SetInstance()
	{
		mInstance = gameObject.GetComponent<TClass>();
	}

}