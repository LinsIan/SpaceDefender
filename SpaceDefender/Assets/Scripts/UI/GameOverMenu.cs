using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
	//------------------------------------------------------
	// Main Functions
	//------------------------------------------------------
	public void RestartGame()
	{
		GameSystem.Instance.Restart();
	}

	public void ExitGame()
	{
		GameSystem.Instance.Exit();
	}
}
