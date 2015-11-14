using UnityEngine;
using System.Collections;

public class Progression : MonoBehaviour 
{
	enum STAGES
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

	public int stage = 0;
	public float GameTime;

	// Use this for initialization
	void Start () 
	{

	}

	void TimeProgression()
	{
		GameTime -= Time.deltaTime;

		if(GameTime <= 0)
		{
			stage++;
			GameTime = 5;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		TimeProgression();
	}
}
