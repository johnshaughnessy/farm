using UnityEngine;

public class BeUnderHead : MonoBehaviour
{
	[SerializeField] private Transform head;
	[SerializeField] private Vector3 offset;
	
	void Update ()
	{
		transform.position = head.transform.position - offset;
		var xzProjection = new Vector3(head.localRotation.eulerAngles.x, 0, head.localRotation.eulerAngles.z);
		transform.rotation = Quaternion.LookRotation(xzProjection, Vector3.up);
	}
}
