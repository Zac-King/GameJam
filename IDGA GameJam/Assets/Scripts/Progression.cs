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

	float GameTime;

	// Use this for initialization
	void Start () 
	{
		GameTime = 0;
	}

	void TimeProgression()
	{
		GameTime += Time.deltaTime * 1;
	}

	// Update is called once per frame
	void Update () 
	{
		TimeProgression();
	}
}
