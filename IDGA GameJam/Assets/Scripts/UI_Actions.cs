using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Actions : MonoBehaviour
{
	public void EnableDisable(GameObject other)
	{
		other.SetActive(!other.activeSelf);
	}

	public void SetTimeScale(float a_scale)
	{
		Time.timeScale = a_scale;
	}

	public void ToggleTime()
	{
		if(Time.timeScale == 0)
		{
			Time.timeScale = 1;
		}
		else
		{
			Time.timeScale = 0;
		}
	}

	public void ChangeScene(string a_scene)
	{
		Application.LoadLevel(a_scene);
	}

	public void ExitApplication()
	{
		Application.Quit();
	}
}