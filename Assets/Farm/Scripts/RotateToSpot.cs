using UnityEngine;
using System.Collections;

public class RotateToSpot : MonoBehaviour
{
	private static readonly float epsilon = 0.1f;

	public static IEnumerator RotateToSpotWithSpeed(Transform rotator, Vector3 point, float angularMoveSpeed)
	{
		var angle = Mathf.PI;
		while (angle > epsilon)
		{
			angle = 0;
			yield return new WaitForEndOfFrame();
		}
		yield return new WaitForEndOfFrame();
	}
}
