using UnityEngine;

public class MimicHeadRotation : MonoBehaviour
{
	[SerializeField] private Transform head;
	void Update ()
	{
		var headYRotation = head.rotation.eulerAngles.y;
		transform.rotation = Quaternion.Euler(0, headYRotation, 0);
	}
}
