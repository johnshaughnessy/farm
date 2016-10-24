using UnityEngine;

public class EyeGlassCursor : MonoBehaviour
{
	[SerializeField] private EyeGlass eyeGlass;
	private readonly float epsilon = 0.01f;
	
	void Update () {
		if (Vector3.SqrMagnitude(eyeGlass.hitPoint) > epsilon)
		{
			transform.position = eyeGlass.hitPoint;
		}
	}
}
