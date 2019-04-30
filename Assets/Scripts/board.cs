using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour 
{
	public GameObject mCellPref;
	private Cell[] mcells = new Cell[9];
	
	public void Build(Main main)
	{
		for(int i=0;i<=8;i++)
		{
			GameObject newcell = Instantiate(mCellPref,transform);
			mcells[i] = newcell.GetComponent<Cell>();
			mcells[i].mMain = main;
		}
	}

	public void Reset()
	{
		foreach (Cell cell in mcells)
		{
			cell.mButton.interactable = true;
			cell.mtext.text = "";
		}
	}

	public bool CheckForWinner()
	{
		int i =0;
		//for horisontal
		for(i = 0;i<=6;i+=3)
		{
			if(!CheckValues(i,i+1))
				continue;
			
			if(!CheckValues(i,i+2))
				continue;
			
			return true;
		}
		//for vertial
		for(i = 0;i<=2;i++)
		{
			if(!CheckValues(i,i+3))
				continue;
			
			if(!CheckValues(i,i+6))
				continue;
			
			return true;
		}
		//for diagonalmoo
		//for left diagonal
		if((CheckValues(0,4))&&(CheckValues(0,8))){return true;}

		//for right diagonal
		if((CheckValues(2,4))&&(CheckValues(2,6))){return true;}

		return false;
	}
	private bool CheckValues(int firstIndex,int secondIndex)
	{
		string firstValue = mcells[firstIndex].mtext.text;
		string secondValue = mcells[secondIndex].mtext.text;

		if((firstValue=="")||(secondValue==""))
			return false;
		
		if(firstValue==secondValue)
			return true;
		
		else
			return false;
	}
	
	
}
