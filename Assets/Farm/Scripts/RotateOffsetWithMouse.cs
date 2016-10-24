using System.Collections;
using UnityEngine;

public class RotateOffsetWithMouse : MonoBehaviour
{
	[SerializeField] private Transform target;
	[SerializeField] private Transform playerForward;
	[SerializeField] private MouseEvents clicks;
	[SerializeField] private MouseAxis mouse;
	[SerializeField] private MaintainOffsetFrom offset;
	[SerializeField] private static readonly float angularSpeedY = 30.0f;
	private static readonly float epsilon = 0.01f;
	private static readonly KeyCode alt = KeyCode.LeftAlt;
	private IEnumerator rotator;

	void Start()
	{
		clicks = GetComponent<MouseEvents>();
		clicks.LeftClick += OnLeftClick;
		clicks.LeftClickUp += OnLeftClickUp;
	}

	private void OnLeftClick()
	{
		if (Input.GetKey(alt) || true)
		{
			if (rotator != null)
			{
				StopCoroutine(rotator);
			}
			rotator = InterpretMouseMotionForRotation(target, playerForward);
			StartCoroutine(rotator);
		}
	}

	private void OnLeftClickUp()
	{
		if (rotator != null)
		{
			StopCoroutine(rotator);
		}
	}

	private static IEnumerator InterpretMouseMotionForRotation(Transform target, Transform playerForward)
	{
		var prev = Input.mousePosition;
		while (true)
		{
			var delta = Input.mousePosition - prev;
			if (delta.magnitude < epsilon)
			{
				yield return new WaitForEndOfFrame();
				continue;
			}
			prev = Input.mousePosition;
			target.Rotate(Vector3.up, delta.x * Time.deltaTime * angularSpeedY);
			//target.Rotate(Vector3.right, delta.y * Time.deltaTime * angularSpeedY);

			yield return new WaitForEndOfFrame();
		}
	}

	void Update ()
	{
		if (false && Mathf.Abs(mouse.scrollWheel) > epsilon)
		{
		//	var dir = offset.Target.position - offset.Offset;
		//	offset.Offset = Vector3.RotateTowards(offset.Offset, offset.Target.forward, mouse.scrollWheel, mouse.scrollWheel);
		}
	}
}
