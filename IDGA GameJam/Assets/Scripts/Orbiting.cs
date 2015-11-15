using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Orbiting : MonoBehaviour 
{
	public List<GameObject> planetList = new List<GameObject>();
	List<GameObject> planetsInOrbit = new List<GameObject>();

	//public float distanceApart;
	
	// Update is called once per frame
	void Update ()
	{
		SpawnPlanet(5);
	
		foreach(GameObject ps in planetsInOrbit)
			OrbitPlanet(ps);

	}

	void OrbitPlanet(GameObject plan)
	{ 
		float speedrot = 1;
		float speedorb = 0;
		if(plan.GetComponent<PlanetMovementStats>())
		{
			speedrot = plan.GetComponent<PlanetMovementStats>().rotationSpeed;
			speedorb = plan.GetComponent<PlanetMovementStats>().orbitSpeed;
		}

		plan.transform.rotation = new Quaternion(plan.transform.rotation.x, 
		                                         plan.transform.rotation.y + speedrot, 
		                                         plan.transform.rotation.z, 
		                                         plan.transform.rotation.w);
		
		Vector3 centre = gameObject.transform.position;
		Vector3 reletivePos = plan.transform.position - gameObject.transform.position;

		if(speedorb > 0)
		{
			float radien = plan.GetComponent<PlanetMovementStats>().orbitPos * (3.14f/180f);
			Vector2 newxz;

			newxz.x = (centre.x + reletivePos.x * Mathf.Cos(radien));
			newxz.y = (centre.z + reletivePos.z * Mathf.Sin(radien));

			GetComponent<Transform>().position = new Vector3(newxz.x, gameObject.transform.position.y, newxz.y);

			plan.GetComponent<PlanetMovementStats>().orbitPos ++;

		}
	}
	public void SpawnPlanet(float distance)
    {
		print ("Test");
		int r = Random.Range(0, planetList.Count);
		print ("Testd");
		planetsInOrbit.Add((GameObject)Instantiate(planetList[r], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + planetsInOrbit[planetsInOrbit.Count-1].transform.position.z + distance), Random.rotation));

	}

}
