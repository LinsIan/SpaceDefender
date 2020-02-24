using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
