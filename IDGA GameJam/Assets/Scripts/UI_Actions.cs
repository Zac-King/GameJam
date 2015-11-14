using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Actions : MonoBehaviour
{
	virtual public void EnableDisable(GameObject other)
	{
		other.SetActive(!other.activeSelf);
	}

	virtual public void SetTimeScale(float a_scale)
	{
		Time.timeScale = a_scale;
	}

	virtual public void ChangeScene(string a_scene)
	{
		Application.LoadLevel(a_scene);
	}

	virtual public void ExitApplication()
	{
		Application.Quit();
	}

	public void testgauge(float a_number)
	{
		print("test");

		GameObject gauge = FindObjectOfType<GrowthGauge>().gameObject;

		gauge.GetComponent<GrowthGauge>().energy = a_number;
	}

	protected bool pressed;
}