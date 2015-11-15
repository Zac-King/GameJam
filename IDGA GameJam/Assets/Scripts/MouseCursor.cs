using UnityEngine;
using System.Collections;

public class MouseCursor : Singleton<MouseCursor> 
{
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;
	public Vector3 mPos;

	protected override void Awake()
	{
		base.Awake();
	}

	// Use this for initialization
	void Start () 
	{
		//Cursor.visible = false;
	}
	
	void CursorMovement()
	{
		mPos = Input.mousePosition;
//		mPos.z = (mPos.x - (Screen.height)) - (mPos.y - (Screen.width));
		mPos.z = Screen.height/2;
		mPos = Camera.main.ScreenToWorldPoint(mPos);
		transform.position = mPos;
//		pos.z = Screen.height/2;  /*Mathf.Sqrt((Screen.height*Screen.height) + (Screen.width * Screen.width)) /2;*/
//		//pos.x =	  Mathf.Sqrt((Screen.height*Screen.height) + (Screen.width * Screen.width)) /2;
//		pos = Camera.main.WorldToScreenPoint(pos);
//		transform.position = pos;
//		mPos = pos;
	}

	// Update is called once per frame
	void Update() 
	{
		CursorMovement();
	}
}
