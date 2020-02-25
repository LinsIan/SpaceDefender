//*******************************************
// Tutorial Menu
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*******************************************
// Class
//*******************************************
public class TutorialMenu : MonoBehaviour
{
	//------------------------------------------------------
	// Main Functions
	//------------------------------------------------------
	public void CloseMenu()
	{
		UIManager.Instance.DeleteMenu<TutorialMenu>();
	}
}
