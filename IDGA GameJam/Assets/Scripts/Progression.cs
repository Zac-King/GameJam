using UnityEngine;
using System.Collections;

public class Progression : MonoBehaviour 
{
	public enum STAGES
	{
		e_Star,
		e_Sun,
		e_Planet1,
		e_Planet2,
		e_Moon,
		e_Life,
		e_BlackHole,
		e_Count
	}

	public int stage;
	public float RoundTimer;
	public float GameTime;
	GameObject player;
	public float timeMod;
	public STAGES cStage;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag("Player");
		StageTracker();
	}

	void TimeProgression()
	{
		GameTime -= Time.deltaTime * 1;

		if(GameTime <= 0)
		{
			stage++;
			cStage = (STAGES)stage;
			StageTracker();
		}
	}
	
	void StageTracker()
	{
		switch(cStage)
		{
		case STAGES.e_Star:
			RoundTimer = 60 * 5;
			GameTime = RoundTimer;
			break;
		case STAGES.e_Sun:
			RoundTimer = 60 * 5;
			GameTime = RoundTimer;
			break;
		case STAGES.e_Planet1:
			RoundTimer = 60 * 5;
			GameTime = RoundTimer;
			break;
		case STAGES.e_Planet2:
			RoundTimer = 60 * 5;
			GameTime = RoundTimer;
			break;
		case STAGES.e_Moon:
			RoundTimer = 60 * 5;
			GameTime = RoundTimer;
			break;
		case STAGES.e_Life:
			RoundTimer = 60 * 3;
			GameTime = RoundTimer;
			break;
		case STAGES.e_BlackHole:
			break;
		default:
			break;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		TimeProgression();
	}
}
