using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeKeeper
{
	void Awakes ()
	{
		SetTimeScale(0);
	}

	static public void SetTimeScale(float a_value)
	{
		Time.timeScale = a_value;
		globalScale = a_value;
	}

	static public float globalScale;
}