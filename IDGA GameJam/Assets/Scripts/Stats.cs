using UnityEngine;
using System.Collections;
using System;

public class Stats : MonoBehaviour 
{
	FSM<CSTATES> _fsm;

	enum CSTATES
	{
		e_Init,
		e_Idle,
		e_Growing,
		e_Shrinking,
		e_Dead,
		e_Count
	}

	float minEnergy;
	float currentEnergy;
	public float maxEnergy;

	void Awake()
	{
		_fsm = new FSM<CSTATES>();
		AddStates();
	}

	void AddStates()
	{
		foreach(int i in Enum.GetValues(typeof(CSTATES)))
		{
			if((CSTATES)i != CSTATES.e_Count)
			{
				_fsm.AddState((CSTATES)i);
			}
		}
	}

	void AddTransitions()
	{
		_fsm.AddTransition(CSTATES.e_Init, CSTATES.e_Idle);
		_fsm.AddTransition(CSTATES.e_Idle, CSTATES.e_Shrinking);
		_fsm.AddTransition(CSTATES.e_Shrinking, CSTATES.e_Growing);
		_fsm.AddTransition(CSTATES.e_Shrinking, CSTATES.e_Dead);
		_fsm.AddTransition(CSTATES.e_Growing, CSTATES.e_Dead);
	}

	// Use this for initialization
	void Start () 
	{
		minEnergy = 0;
		currentEnergy = maxEnergy / 2;
	}


	// Update is called once per frame
	void Update () {
	
	}
}
