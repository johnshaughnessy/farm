using UnityEngine;

public class LockMouse : MonoBehaviour
{
	private Vector3 virtualMouse;
	public Vector3 virtualMouseDelta;
	private Vector3 lastPosition;
	private readonly float epsilon = 0.1f;
	void Start()
	{
		virtualMouse = Vector3.zero;
		lastPosition = Vector3.zero;
	}

	void Update()
	{
		var x = Input.mousePosition.x;
		var y = Input.mousePosition.y;
		var atBorder = Screen.width - x < epsilon ||
						Screen.height - y < epsilon || 
						x < epsilon ||
						y < epsilon;
		if (atBorder)
		{
		//	Debug.Log("A");
		}

		virtualMouseDelta += Input.mousePosition - lastPosition;
		virtualMouse += virtualMouseDelta;
		lastPosition = Input.mousePosition;
		//Debug.Log("TODO");//TODO
		//Debug.LogFormat("d:{0}, m:{1}", virtualMouseDelta, virtualMouse);
	}
}
