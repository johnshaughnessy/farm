using UnityEngine;
using Valve.VR;

// Rotate this object so that it looks at the thing, but 
// take the hip rotation into account such that you never 
// turn more than 90 degrees in either direction around the y axis
// relative to hips.
public class LookAtTheThing : MonoBehaviour
{
	[SerializeField]
	private Transform hips;
	public Transform ThingToLookAt;

	void LateUpdate()
	{
		var directionToLook = ThingToLookAt.position - hips.position;
		var lookRotation = Quaternion.LookRotation(directionToLook, Vector3.up);
		var angleDiff = Quaternion.Angle(hips.rotation, lookRotation);
		if (Mathf.Abs(angleDiff) > 90)
		{
			var isFacingRight = Quaternion.Euler(Quaternion.FromToRotation(hips.forward, directionToLook) * Vector3.forward).x > 0;
			var left = -hips.right;
			var rotator = Quaternion.FromToRotation(hips.forward, isFacingRight ? hips.right : left);
			var direction = rotator * hips.forward;
			lookRotation = Quaternion.LookRotation(direction);
		}
		transform.rotation = lookRotation;
	}
}
