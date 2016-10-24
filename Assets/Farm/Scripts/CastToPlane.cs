using UnityEngine;

public class CastToPlane : MonoBehaviour
{
	[SerializeField] private LayerMask layerMask;
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100.0f, layerMask))
		{
			transform.position = hit.point;
		}
	}
}
