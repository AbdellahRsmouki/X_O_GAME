using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour 
{
	public Text mtext;
	public Button mButton;
	public Main mMain;

	public void Fill()
	{
		mButton.interactable = false;
		mtext.text = mMain.GetTurnCharacter();
		mMain.Switch();

		
	}
}
