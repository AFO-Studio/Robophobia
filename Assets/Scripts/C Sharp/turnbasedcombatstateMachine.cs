using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnbasedcombatstateMachine : MonoBehaviour
{


	public enum BattleStates
	{
		START,
		PLAYERCHOICE,
		ENEMYCHOICE,
		LOSE,
		WIN
	}

	private BattleStates currentState;

	// Use this for initialization
	void Start()
	{
		currentState = BattleStates.START;
	}

	// Update is called once per frame
	void Update()
	{
		Debug.Log(currentState);
		switch (currentState)
		{
			case (BattleStates.START):
				break;
			case (BattleStates.PLAYERCHOICE):
				break;
			case (BattleStates.ENEMYCHOICE):
				break;
			case (BattleStates.LOSE):
				break;
			case (BattleStates.WIN):
				break;

		}
	}
	public void EndTurn()
	{

		if (currentState == BattleStates.START)
		{
			currentState = BattleStates.PLAYERCHOICE;
		}

	}
}
