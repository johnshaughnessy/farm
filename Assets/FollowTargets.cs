using UnityEngine;

public class FollowTargets : MonoBehaviour
{
	[SerializeField] private Transform target;
	private bool isFollowing;
	public bool triggerFollow;
	private Vector3 offset;

	void Update () {
		if (triggerFollow)
		{
			triggerFollow = false;
			isFollowing = true;
			offset = transform.position - target.position;
		}

		if (isFollowing && target != null)
		{
			var xz = target.position + offset;
			transform.position = new Vector3(xz.x, transform.position.y, xz.z);
		}
	}
}
