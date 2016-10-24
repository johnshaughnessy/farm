using UnityEngine;

public class EyeGlass : MonoBehaviour
{
	public Transform eye;
	public Transform glass;
	[SerializeField] private LayerMask layerMask;
	public Vector3 hitPoint = Vector3.zero;

	void Update ()
	{
		Ray ray = new Ray(eye.position, glass.position + (glass.forward * 0.1f) -eye.position); //TODO clarify. moving forward by 1/10th of a meter so hitpoint isn't blocked by my controller.
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100.0f, layerMask))
		{
			hitPoint = hit.point;
		}
	}
}
