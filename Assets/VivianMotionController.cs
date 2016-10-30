using System;
using System.Collections;
using UnityEngine;

public interface GetVector2
{
	Vector2 Get();
}

public interface GetVector3
{
	Vector3 Get();
}

public interface Action
{
	bool Get();
}

public class VivianMotionController : MonoBehaviour
{
	public Action jumpInput;
	public GetVector2 moveInput;
	public Vector3 jump;
	public Transform head;
	public CharacterController controller;
	[SerializeField] [Range(0.0f, 4.0f)] public float speed;
	[SerializeField] [Range(0.0f, 4.0f)] public float jumpStrength;
	private bool didJumpThisFrame;

	// Project a vector3 from vivian in the XZ direction I am looking
	// Use this vector as forward, and its cross product with Vector3.up as right
	// Map the moveInput controls onto these vectors,
	// Move vivian in that direction
	void Update ()
	{
		var headEuler = head.rotation.eulerAngles;
		var rotation = Quaternion.Euler(0, headEuler.y, 0);
		var input = moveInput.Get();
		if (controller.isGrounded && jumpInput.Get())
		{
			StartCoroutine(Jump());
			didJumpThisFrame = true;
		}

		var gravity = controller.isGrounded ? Vector3.zero : Physics.gravity;
		var planarMotion = rotation*new Vector3(input.x, 0, input.y)*speed;

		controller.Move((planarMotion + gravity + jump) * Time.deltaTime);

		if (!IsInDeadZone(input))
		{
			transform.forward = planarMotion.normalized;
		}
	}


	private IEnumerator Jump()
	{
		var originalJump = -Physics.gravity * jumpStrength;
		jump = originalJump;
		var scale = 1.0f;
		while (scale > 0.1f && (didJumpThisFrame || !controller.isGrounded))
		{
			yield return new WaitForEndOfFrame();
			jump = originalJump * scale;
			scale = scale - Time.deltaTime;
			didJumpThisFrame = false;
		}
		jump = Vector3.zero;
	}

	private bool IsInDeadZone(Vector2 input)
	{
		return input.magnitude < 0.1f;
	}
}
