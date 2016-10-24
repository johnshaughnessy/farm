using UnityEngine;

public class MouseAxis : MonoBehaviour
{
	public float scrollWheel = 0.0f;
	private static readonly string scrollWheelAxis = "Mouse ScrollWheel";
	void Update () {
		scrollWheel = Input.GetAxis(scrollWheelAxis);
	}
}
