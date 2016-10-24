using UnityEngine;

public class LerpToTarget : MonoBehaviour
{
	[SerializeField] private Transform target;
	[SerializeField] [Range(0.0f, 0.1f)] private float lerpSpeed;
	void Update ()
	{
		transform.position = Vector3.Lerp(transform.position, target.position, lerpSpeed);
	}
}
