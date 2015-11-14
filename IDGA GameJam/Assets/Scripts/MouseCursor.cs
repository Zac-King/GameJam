using UnityEngine;
using System.Collections;

public class MouseCursor : Singleton<MouseCursor> 
{
	public Vector3 MousePosition;
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

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
		Vector3 v3 = Input.mousePosition;
		v3.z = 50;
		v3 = Camera.main.ScreenToWorldPoint(v3);
		MousePosition = v3;
	}

	// Update is called once per frame
	void Update() 
	{
		CursorMovement();
	}
}
