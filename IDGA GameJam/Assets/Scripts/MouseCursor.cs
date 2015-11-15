using UnityEngine;
using System.Collections;

public class MouseCursor : Singleton<MouseCursor> 
{
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;
	public Vector3 mPos;
	Ray ray;
	protected override void Awake()
	{
		base.Awake();
	}

	// Use this for initialization
	void Start () 
	{
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}
	
	void CursorMovement()
	{
		Vector3 pos = Input.mousePosition;
		pos.z = Screen.height;
		pos = Camera.main.ScreenToWorldPoint(pos);
		ray = new Ray(pos, Vector3.down);
		mPos = pos;
	}

	// Update is called once per frame
	void Update() 
	{
		CursorMovement();
	}
}
