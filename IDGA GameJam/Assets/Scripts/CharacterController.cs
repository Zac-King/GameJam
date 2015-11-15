using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour 
{
	public GameObject field;
	public GameObject gravityField;
	public GameObject source;
	public float G_Force;

	public float speed;

	public float gravityAcceleration;

	void GravityTool()
	{
		if(Input.GetMouseButton(0) && G_Force <= 40)
		{
			G_Force += Time.deltaTime * gravityAcceleration;
		}
		
		else if(Input.GetMouseButtonUp(0))
		{
			G_Force = 0;
		}
	}

	// Use this for initialization
	void Start () 
	{
		field = Instantiate(gravityField, transform.position, Quaternion.identity) as GameObject;
		source = GameObject.FindWithTag("Player");
	}

	void GField()
	{
		GameObject mousePos = FindObjectOfType<MouseCursor>().gameObject;
		field.transform.localScale = new Vector3(G_Force,0.01f,G_Force);;
		field.transform.position = new Vector3(mousePos.GetComponent<MouseCursor>().mPos.x,0,mousePos.GetComponent<MouseCursor>().mPos.z);
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
