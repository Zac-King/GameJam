using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIHowTo : MonoBehaviour
{
	public void EnableDisableInstructions()
	{
		instructions.SetActive(!instructions.activeSelf);
	}

	Toggle t;

	public GameObject instructions;
}
