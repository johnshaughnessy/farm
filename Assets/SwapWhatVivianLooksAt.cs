using System.Runtime.InteropServices;
using UnityEngine;
// When imInFrontOfVivian && imLookingBehindVivian, 
// I want vivian to look at me.

// In order to tell when imInFrontOfVivian, 
// I will compute the line-plane intersection
// of vivian's forward direction and the plane
// whose normal is vivian's forward direction 
// and that contains my position.
// https://en.wikipedia.org/wiki/Line%E2%80%93plane_intersection

// In order to tell when imLookingBehindVivian,
// I will do the check, but substitute my position 
// with my cursor's position.
public class SwapWhatVivianLooksAt : MonoBehaviour
{
	[SerializeField]
	private LookAtTheThing lookAtTheThing;
	[SerializeField]
	private Transform cursor;
	[SerializeField]
	private Transform me;
	[SerializeField]
	private Transform vivian;

	void Update()
	{
		var imInFrontOfVivian = LinePlaneIntersectionIsPositive(vivian.position, vivian.forward, me.position);
		var imLookingBehindVivian = !LinePlaneIntersectionIsPositive(vivian.position, vivian.forward, cursor.position);
		var lookAtMe = imInFrontOfVivian && imLookingBehindVivian;
		
		lookAtTheThing.ThingToLookAt = lookAtMe ? me : cursor;
	}

	private bool LinePlaneIntersectionIsPositive(Vector3 vivian, Vector3 forward, Vector3 objectInQuestion)
	{
		// Plane == {p : (p-p0) . n == 0} where {p0 == point on plane, n == plane normal}
		// Line ==  {p : dl + l0} where {d in Reals, l is direction of line, l0 is point on the line}
		// Intersection happens when point on line == point on plane, 
		// which is when we substite p from line into p from plane: 
		// (dl + l0 - p0) . n == 0

		// d = (p0-l0) . n
		//     -----------
		//        l . n

		// If l.n == 0, then the plane is parallel to the line, and we don't care about this case.
		// If d > 0, then intersection is in "front". Otherwise, it's "behind"

		var p0 = objectInQuestion;
		var l0 = vivian;
		var n = forward;
		var l = forward;
		var denom = Vector3.Dot(l, n);
		if (denom == 0)
		{
			Debug.LogError("Can't compute. It's parallel");
			return false;
		}
		var d =  Vector3.Dot(p0 - l0, n)/denom;
		return d > 0;
	}
}
