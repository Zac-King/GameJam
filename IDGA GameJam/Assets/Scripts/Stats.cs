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

	[SerializeField]
	float minEnergy;
	[SerializeField]
	float currentEnergy;
	public float maxEnergy;

	public float mass;

	void Awake()
	{
		_fsm = new FSM<CSTATES>();
		AddStates();
		Instance = this;
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
		StartCoroutine(Shrinking());
	}

	IEnumerator Growing(float mass)
	{
		while(currentEnergy != currentEnergy + mass)
		{
			currentEnergy += mass + Time.deltaTime;
			yield return null;
		}
		_fsm.Transition(_fsm.state, CSTATES.e_Shrinking);
		StartCoroutine(Shrinking());
		StopCoroutine(Growing(mass));
	}

	IEnumerator Shrinking()
	{
		while(_fsm.state == CSTATES.e_Shrinking)
		{
			currentEnergy -= 2 * Time.deltaTime; 
			if(currentEnergy <= minEnergy)
			{
				_fsm.Transition(_fsm.state, CSTATES.e_Dead);
			}
			yield return null;
		}
		StopCoroutine(Shrinking());
	}

	void OnTriggerEnter(Collider a)
	{
		StopCoroutine(Shrinking());
		_fsm.Transition(_fsm.state, CSTATES.e_Growing);
		StartCoroutine(Growing(a.GetComponent<Stats>().mass));
	}

	// Update is called once per frame
	void Update () 
	{
		
	}

	private Stats Instance;
	public  Stats _Instance
	{
		get
		{
			return Instance;
		}
	}
}
