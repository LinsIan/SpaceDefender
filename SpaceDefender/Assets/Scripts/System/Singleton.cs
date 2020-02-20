//*******************************************
// Singleton
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*******************************************
// Class
//*******************************************
abstract public class Singleton<TClass> : MonoBehaviour
	where TClass : class
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
				Debug.LogError("Could not found singleton "+ typeof(TClass));
			}
			return mInstance;
		}
	}

	//------------------------------------------------------
	// Abstract Functions
	//------------------------------------------------------
	public abstract void Initialize();
	
	//------------------------------------------------------
	// Main Functions
	//------------------------------------------------------
	public void SetInstance()
	{
		Object.DontDestroyOnLoad(this.gameObject);
		mInstance = gameObject.GetComponent<TClass>();
	}

}