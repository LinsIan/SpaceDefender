//*******************************************
// Object Pooler
//*******************************************
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//*******************************************
// Class
//*******************************************
public class ObjectPool<TClass> : MonoBehaviour
	where TClass : MonoBehaviour
{
	//------------------------------------------------------
	// Variables
	//------------------------------------------------------
	private GameObject    mPrefab;
	private Queue<TClass> mClassList;
	
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
		mPrefab = iPrefab;
		for(int i = 0;i< iInitObjectNum; ++i)
		{
			Create();
		}
	}

	public TClass Get()
	{
		if(mClassList.Count == 0) { Create(); }

		TClass        aClass     = mClassList.Dequeue();
		MonoBehaviour aComponent = (MonoBehaviour)aClass;
		aComponent.transform .SetParent(null);
		aComponent.gameObject.SetActive(true);
		return aClass;
	}
	public void BackToPool(TClass iClass)
	{
		MonoBehaviour aComponent = (MonoBehaviour)iClass;
		aComponent.transform .SetParent(transform);
		aComponent.gameObject.SetActive(false);
		mClassList.Enqueue(iClass);
	}
	private void Create()
	{
		GameObject aNewObject = Instantiate(mPrefab,transform);
		TClass     aNewClass  = aNewObject.GetComponent<TClass>();
		aNewObject.SetActive(false);
		mClassList.Enqueue(aNewClass);
	}
	
}