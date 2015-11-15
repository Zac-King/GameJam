using UnityEngine;
using System.Collections;

public class Progression : MonoBehaviour 
{
	public enum eSTAGES
	{
		Star,
		Sun,
		Planet1,
		Planet2,
		Moon,
		Life,
		BlackHole,
		BurnOut,
		Count
	}

	public int stage;
	public float RoundTimer;
	public float GameTime;
	GameObject player;
	public float timeMod;
	public eSTAGES cStage;
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
			cStage = (eSTAGES)stage;
			StageTracker();
		}
	}

	void ProgressState(eSTAGES j)
	{
		cStage = j;
		StageTracker();

	}

	void StageTracker()
	{
		switch(cStage)
		{
		case eSTAGES.Star:
			RoundTimer = 60 * 5;
			GameTime = RoundTimer;
			player.GetComponent<RadialSpawner>().SelectUnit(0);
			break;
		case eSTAGES.Sun:
			RoundTimer = 60 * 5;
			GameTime = RoundTimer;
			player.GetComponent<RadialSpawner>().SelectUnit(1);
			break;
		case eSTAGES.Planet1:
			RoundTimer = 60 * 5;
			GameTime = RoundTimer;
			player.GetComponent<RadialSpawner>().SelectUnit(2);
			break;
		case eSTAGES.Planet2:
			RoundTimer = 60 * 5;
			GameTime = RoundTimer;
			break;
		case eSTAGES.Moon:
			RoundTimer = 60 * 5;
			GameTime = RoundTimer;
			player.GetComponent<RadialSpawner>().SelectUnit(3);
			break;
		case eSTAGES.Life:
			RoundTimer = 60 * 3;
			GameTime = RoundTimer;
			player.GetComponent<RadialSpawner>().SelectUnit(4);
			break;
		case eSTAGES.BlackHole:
			Lose ("blackhole");
			break;
		default:
			break;
		}
	}

	void Lose(string msg)
	{
		if(msg == "blackhole")//For when blowing up
		{
			///Dylan Put stuff here
		}
		else //For when burning out
		{
			///Dylan put stuff here
		}
	}

	// Update is called once per frame
	void Update () 
	{
		TimeProgression();
		if(player.GetComponent<Stats>().currentEnergy <= 0)
			ProgressState(eSTAGES.BlackHole);
		else if(player.GetComponent<Stats>().currentEnergy >= 100)
			ProgressState(eSTAGES.BurnOut);
	}
}
