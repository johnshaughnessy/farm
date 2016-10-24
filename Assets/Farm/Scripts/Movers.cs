using System.Collections;
using UnityEngine;

public static class Movers 
{
	private static readonly float epsilon = 0.1f;
	/// <summary>
	/// Moves the transform to the indicated spot at the desired speed //TODO (in m/s)
	/// </summary>
	/// <param name="mover"></param>
	/// <param name="spot"></param>
	/// <param name="speed"></param>
	/// <returns></returns>
	public static IEnumerator MoveToSpotWithSpeed(Transform mover, Vector3 spot, float speed)
	{
		var dist = Vector3.Distance(mover.position, spot);
		var dir = Vector3.Normalize(spot - mover.position);
		while (dist > epsilon)
		{
			var dest = mover.position + dir*speed*Time.deltaTime;
			if (Vector3.Distance(mover.position, dest) > Vector3.Distance(mover.position, spot))
			{
				dest = spot;
			}
			mover.position = dest;
			yield return new WaitForEndOfFrame();
		}
		yield return new WaitForEndOfFrame();
	}

	public static IEnumerator RotateToSpotWithSpeed(Transform mover, Vector3 spot, float angularSpeed)
	{
		//while (Quaternion.AngleAxis(mover.forward,// ))
		yield return new WaitForEndOfFrame();
	}

	private struct Line
	{
		Vector3 a;
		Vector3 b;

		public Line(Vector3 a, Vector3 b)
		{
			this.a = a;
			this.b = b;
		}

		public static Line Draw(Vector3 from, Vector3 to)
		{
			return new Line(from, to);
		}

		public static Vector3 Lerp(Line line, float lerp)
		{
			// The left side is how I've thought about lerp for a while. 
			// The right side makes more sense to me in dimension > 1;
			// line.a + (line.b - line.a)*lerp	==	(1-lerp)*line.a + lerp*line.b
			return (1-lerp)*line.a + lerp*line.b;
		}
	}
}
