using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GrowthGauge : MonoBehaviour
{
	IEnumerator AdjustGage(float a_value)
	{
		float tmp = a_value;

		a_value *= Mathf.Abs(a_value) / a_value;

		a_value /= 100;
		a_value *= 180;

		posNeg = 1;

		if(a_value < transform.localEulerAngles.z)
		{
			a_value *= -1;
			posNeg = -1;
		}
		while(transform.localEulerAngles.z != a_value)
		{
			transform.localEulerAngles += new Vector3
				(0, 0, posNeg * Time.deltaTime * 25f);

			temp.text = 
				((int)(transform.localEulerAngles.z / 180 * 100)).ToString();

			if(Mathf.Abs(Mathf.Abs(a_value) - Mathf.Abs (transform.localEulerAngles.z)) < 1f)
			{
				transform.localEulerAngles = 
					new Vector3 (transform.localEulerAngles.x,
					             transform.localEulerAngles.y,
					             Mathf.Abs (a_value));

				temp.text = ((int)tmp).ToString();

				break;
			}

			yield return null;
		}
	}

	private float posNeg;

	[SerializeField] private float m_energy;

	public Text temp;

	public float energy
	{
		get
		{
			return m_energy;
		}

		set
		{
			print ("set");

			if(m_energy == value)
				return;

			m_energy = value;
			StopAllCoroutines();
			StartCoroutine(AdjustGage(m_energy));
		}
	}
}
