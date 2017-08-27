using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (CameraRaycaster))] 
public class CursorAffordance : MonoBehaviour {
	[SerializeField]
	Texture2D walkCursor = null;

	[SerializeField]
	Texture2D targetCursor = null;

	[SerializeField]
	Texture2D unknownCursor = null;

	[SerializeField]
	Vector2 cursorHotspot = new Vector2(0, 0);

	CameraRaycaster raycaster;

	// Use this for initialization
	void Start() {
		raycaster = GetComponent<CameraRaycaster>();
		raycaster.layerChangeObservers += OnLayerChanged;
	}
	
	void OnLayerChanged() {		
		Texture2D cursor;
		switch (raycaster.currentLayerHit)
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
