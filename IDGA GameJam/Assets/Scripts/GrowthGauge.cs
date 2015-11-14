using UnityEngine;
using System.Collections;

public class GrowthGauge : MonoBehaviour
{
	IEnumerator AdjustGage(float a_value)
	{
		Quaternion nextValue = new Quaternion(transform.rotation.x, transform.rotation.y, energy + 90 + a_value, transform.rotation.w);

		while(transform.rotation != nextValue)
		{
			Quaternion.Lerp(transform.localRotation, nextValue, Time.deltaTime * 10);
			yield return null;
		}
	}

	[SerializeField] private float m_energy;
	
	public float energy
	{
		get
		{
			return m_energy;
		}

		set
		{
			m_energy = value;
			StopAllCoroutines();
			StartCoroutine(AdjustGage(m_energy));
		}
	}
}
