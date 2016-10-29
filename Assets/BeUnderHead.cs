using UnityEngine;

public class BeUnderHead : MonoBehaviour
{
	[SerializeField] private Transform head;
	[SerializeField] private Vector3 offset;
	
	void Update ()
	{
		transform.position = head.transform.position - offset;
	}
}
