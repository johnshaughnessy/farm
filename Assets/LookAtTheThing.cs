using UnityEngine;

// Rotate this object so that it looks at the thing, but 
// take the hip rotation into account such that you never 
// turn more than 90 degrees in either direction around the y axis
// relative to hips.
public class LookAtTheThing : MonoBehaviour
{
	[SerializeField] private Transform hips;
	[SerializeField] private Transform thingToLookAt;
	[SerializeField] private Transform debugEnd;

	void Update ()
	{
		var directionToLook = thingToLookAt.position - hips.position;
		var lookRotation = Quaternion.LookRotation(directionToLook, Vector3.up);
		var angleDiff = Quaternion.Angle(hips.rotation, lookRotation);
		/*
		if (Mathf.Abs(angleDiff) > 90)
		{
			var sign = angleDiff > 0 ? Mathf.PI/4 : -Mathf.PI/4;
			var direction = Quaternion.AngleAxis(sign, Vector3.up) * hips.forward;
			debugEnd.position = hips.position + direction;
			lookRotation = Quaternion.LookRotation(direction);
			Debug.Log("A");
		}
		*/
		debugEnd.position = transform.position + lookRotation*Vector3.forward;
		transform.rotation = lookRotation;
	}
}
