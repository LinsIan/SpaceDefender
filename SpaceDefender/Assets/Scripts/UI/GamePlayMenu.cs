//*******************************************
// Game Play Menu
//*******************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//*******************************************
// Class
//*******************************************
public class GamePlayMenu : MonoBehaviour
{
	//------------------------------------------------------
	// Variables
	//------------------------------------------------------
	[SerializeField] private Text  HP_Value_Text;
	[SerializeField] private Image Weapon_Image;

	//------------------------------------------------------
	// Main Functions
	//------------------------------------------------------
	public void SetHP(float iHP)
	{
		HP_Value_Text.text = iHP.ToString();
	}

	public void SetWeapon(EColor iColor)
	{
		switch(iColor)
		{
			case EColor.BLUE:
				Weapon_Image.color = Color.blue;
				break;
			case EColor.YELLOW:
				Weapon_Image.color = Color.yellow;
				break;
			case EColor.GREEN:
				Weapon_Image.color = Color.green;
				break;
		}
	}
}
