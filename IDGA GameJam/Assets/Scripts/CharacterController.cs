using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour 
{
	GameObject field;
	public GameObject gravityField;
	public GameObject source;
	public float G_Force;

	public float speed;

	public float gravityAcceleration;

	void GravityTool()
	{
		if(Input.GetMouseButton(0))
		{
			G_Force += Time.deltaTime * gravityAcceleration;
		}
		
		else if(G_Force >= .2)
		{
			G_Force -= Time.deltaTime * gravityAcceleration;
		}
		
		else if(G_Force <= .2 && G_Force > 0)
		{
			G_Force = 0;
		}
		
		if(Input.GetMouseButton(1))
		{
			G_Force -= Time.deltaTime * gravityAcceleration;
		}

		else if(G_Force <= -.2)
		{
			G_Force += Time.deltaTime * gravityAcceleration;
		}
		
		else if(G_Force >= -.2 && G_Force < 0)
		{
			G_Force = 0;
		}
	}

	// Use this for initialization
	void Start () 
	{
		field = Instantiate(gravityField,transform.position,Quaternion.identity) as GameObject;
		source = GameObject.FindWithTag("Player");
	}

	void GField()
	{
		GameObject mousePos = FindObjectOfType<MouseCursor>().gameObject;
		field.transform.localScale = new Vector3(G_Force,0.01f,G_Force);;
		field.transform.position = mousePos.GetComponent<MouseCursor>().MousePosition;
		if(G_Force > 0)
		{
			field.GetComponent<Renderer>().material.color = Color.blue;
		}
		if(G_Force < 0)
		{
			field.GetComponent<Renderer>().material.color = Color.red;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		GravityTool();
		GField();
	}
}
