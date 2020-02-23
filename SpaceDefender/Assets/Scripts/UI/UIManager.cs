//*******************************************
// Class Sample
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

//*******************************************
// Class
//*******************************************
public class UIManager : Singleton<UIManager>
{
	//------------------------------------------------------
	// Constants
	//------------------------------------------------------
	private const string CANVAS_NAME = "Canvas";

	//------------------------------------------------------
	// Variables
	//------------------------------------------------------
	private Dictionary<Type,GameObject> mUIPrefabMap;
	private Dictionary<Type,Menu>       mCreatedMenuMap;
	private Canvas                      mCanvas;



	//------------------------------------------------------
	// Override Functions
	//------------------------------------------------------
	public override void Initialize()
	{
		mUIPrefabMap    = new Dictionary<Type, GameObject>();
		mCreatedMenuMap = new Dictionary<Type, Menu>();
		mCanvas         = null;
	}

	//------------------------------------------------------
	// Main Functions
	//------------------------------------------------------
	public TMenu CreateMenu<TMenu>()
	where TMenu : Menu
	{
		if(mUIPrefabMap.Count == 0) { GetUIPrefabData(); }

		if(!mUIPrefabMap.ContainsKey(typeof(TMenu)))
		{
			Debug.LogError("Can't find prefab in data.");
			return null;
		}

		if(mCanvas == null && !FindCanvas()) 
		{
			Debug.LogError("Can't find canvas in scene.");
			return null;
		}

		GameObject aMenuPrefab    = mUIPrefabMap[typeof(TMenu)];
		GameObject aNewMenuObject = Instantiate(aMenuPrefab,mCanvas.transform);
		TMenu      aNewMenu       = aNewMenuObject.GetComponent<TMenu>();
		mCreatedMenuMap.Add(typeof(TMenu),aNewMenu);
		return aNewMenu;
	}

	private bool FindCanvas()
	{
		mCanvas = GameObject.FindObjectOfType<Canvas>();
		if(mCanvas == null)
		{
			return false;
		}
		else
		{
			return true;
		}
		
	}
	
	private void GetUIPrefabData()
	{
		List<GameObject> aUIList = DataManager.Instance.PrefabMapsData.UIPrefabMap;
		
		
	}

}