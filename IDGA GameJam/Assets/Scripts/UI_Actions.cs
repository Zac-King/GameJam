using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Actions : MonoBehaviour
{
	public void Pause()
	{
		Time.timeScale = 0;
	}

	public void Resume()
	{
		Time.timeScale = 1;
	}

	public void ExitApplication()
	{
		Application.Quit();
	}
}
