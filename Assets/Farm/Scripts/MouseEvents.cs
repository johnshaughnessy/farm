using System;
using UnityEngine;

public class MouseEvents : MonoBehaviour {

	public delegate void OnRightClick();
	public event OnRightClick RightClick;
	private static readonly int RightClickButton = 1;

	public delegate void OnLeftClick();
	public event OnLeftClick LeftClick;
	private static readonly int LeftClickButton = 0;

	public delegate void OnLeftClickUp();
	public event OnLeftClickUp LeftClickUp;

	public delegate void OnRightClickUp();
	public event OnRightClickUp RightClickUp;

	void Update () {
		if (Input.GetMouseButtonDown(RightClickButton))
		{
			if (RightClick != null)
			{
				RightClick();
			}
		}

		if (Input.GetMouseButtonDown(LeftClickButton))
		{
			if (LeftClick != null)
			{
				LeftClick();
			}
		}

		if (Input.GetMouseButtonUp(LeftClickButton))
		{
			if (LeftClickUp != null)
			{
				LeftClickUp();
			}
		}
		if (Input.GetMouseButtonUp(RightClickButton))
		{
			if (RightClickUp != null)
			{
				RightClickUp();
			}
		}
	}
}
