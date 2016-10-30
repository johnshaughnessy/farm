using UnityEngine;
using VRTK;

public class VivianMotionControllerVivePlug : MonoBehaviour, GetVector2, Action
{
	[SerializeField] private VivianMotionController motionController;
	[SerializeField] private VRTK_ControllerEvents controller;

	void Start()
	{
		motionController.moveInput = this;
		motionController.jumpInput = this;
	}

	public Vector2 Get()
	{
		return controller.GetTouchpadAxis();
	}

	bool Action.Get()
	{
		return controller.touchpadPressed;
	}
}
