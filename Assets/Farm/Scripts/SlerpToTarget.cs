using UnityEngine;
using System.Collections;

public class SlerpToTarget : MonoBehaviour
{
	[SerializeField] private Transform target;
	[SerializeField] [Range(0.0f, 0.1f)] private float slerpSpeed;
	void Update ()
	{
		transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, slerpSpeed);

	}
}
