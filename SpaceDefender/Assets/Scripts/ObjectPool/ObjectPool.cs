//*******************************************
// Object Pool
//*******************************************
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//*******************************************
// Class
//*******************************************
public class ObjectPool : MonoBehaviour
{
	//------------------------------------------------------
	// Variables
	//------------------------------------------------------
	private GameObject    mPrefab;
	private Queue<GameObject> mClassList ;
	
	//------------------------------------------------------
	// Constructor
	//------------------------------------------------------
	public ObjectPool(GameObject iPrefab)
	{
		mPrefab = iPrefab;
	}

	//------------------------------------------------------
	// Main Functions
	//------------------------------------------------------
	public void Initialize(GameObject iPrefab,int iInitObjectNum)
	{
		mPrefab    = iPrefab;
		mClassList = new Queue<GameObject>();
		for(int i = 0;i< iInitObjectNum; ++i)
		{
			Create();
		}
	}

	public TClass Get<TClass>()
	{
		if(mClassList.Count == 0) { Create(); }

		GameObject aObject = mClassList.Dequeue();
		aObject.transform .SetParent(null);
		aObject.SetActive(true);
		return aObject.GetComponent<TClass>();
	}
	public void BackToPool(GameObject iObject)
	{
		iObject.transform .SetParent(transform);
		iObject.SetActive(false);
		mClassList.Enqueue(iObject);
	}
	private void Create()
	{
		GameObject aNewObject = Instantiate(mPrefab);
		aNewObject.SetActive(false);
		mClassList.Enqueue(aNewObject);
	}
	
}