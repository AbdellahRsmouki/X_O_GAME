using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {

	public board mbroad;
	private int mTurnCount = 0 ;
	private bool mXTurn = true;
	public GameObject mWinner;

	void Awake()
	{
		mbroad.Build(this);
	}

	public void Switch()
	{
		mTurnCount++;
		bool hasWinner = mbroad.CheckForWinner();
		if(hasWinner||mTurnCount==9)
		{
			// end game
			StartCoroutine(ENDGame(hasWinner));
		}
		mXTurn = !mXTurn;
	}
	public string GetTurnCharacter()
	{
		if(mXTurn)
			return "X";
		
		else
			return "O";
	}

	private IEnumerator ENDGame(bool hasWinner)
	{
		Text winnerLabel = mWinner.GetComponentInChildren<Text>();
		
		if(hasWinner)
		{
			winnerLabel.text = GetTurnCharacter()+" "+"win !!  :)";
		}
		else
		{
			winnerLabel.text = "Draw ! :(";
		}

		mWinner.SetActive(true);
		WaitForSeconds wait = new WaitForSeconds(5.0f);
		yield return wait;

		mbroad.Reset();
		mTurnCount = 0;
		mWinner.SetActive(false);
	}
}