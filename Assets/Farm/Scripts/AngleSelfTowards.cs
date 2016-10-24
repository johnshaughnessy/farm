using UnityEngine;

public class AngleSelfTowards : MonoBehaviour
{
	[SerializeField] private Transform target;
	
	void Update ()
	{
		transform.forward = target.transform.position - transform.position;
	}
}
