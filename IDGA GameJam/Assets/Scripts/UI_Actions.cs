using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Actions : MonoBehaviour
{
	
	virtual protected void SetTimeScale(float a_scale)
	{
		Time.timeScale = a_scale;
	}

	virtual protected void ChangeScene(string a_scene)
	{
		Application.LoadLevel(a_scene);
	}

	virtual protected void ExitApplication()
	{
		Application.Quit();
	}

	protected bool pressed;
}