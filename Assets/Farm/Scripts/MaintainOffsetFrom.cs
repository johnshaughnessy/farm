using UnityEngine;

public class MaintainOffsetFrom : MonoBehaviour
{
	public Vector3 Offset;
	void Start ()
	{
		Offset = transform.localPosition;
	}
	
	void Update ()
	{
		transform.localPosition = Offset;
	}
}
