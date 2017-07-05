using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAffordance : MonoBehaviour {
	[SerializeField]
	Texture2D walkCursor = null;

	[SerializeField]
	Texture2D targetCursor = null;

	[SerializeField]
	Texture2D unknownCursor = null;

	[SerializeField]
	Vector2 cursorHotspot = new Vector2(96, 96);

	CameraRaycaster raycaster;

	// Use this for initialization
	void Start () {
		raycaster = GetComponent<CameraRaycaster>();
	}
	
	// Update is called once per frame
	void Update () {		
		Texture2D cursor;
		switch (raycaster.layerHit)
		{
			case Layer.Walkable:
				cursor = walkCursor;
				break;
			case Layer.Enemy:
				cursor = targetCursor;
				break;
			case Layer.RaycastEndStop:
				cursor = unknownCursor;
				break;
			default:
				Debug.LogError("We don't know what cursor to show");
				return;
		}
		Cursor.SetCursor(cursor, cursorHotspot, CursorMode.Auto);
	}
}
