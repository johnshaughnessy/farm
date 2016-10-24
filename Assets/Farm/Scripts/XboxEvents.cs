using UnityEngine;

public class XboxEvents : MonoBehaviour {
	public struct Axis
	{
		public float vert;
		public float horizontal;
	}
	public delegate void AxisChange(Axis axis);
	public event AxisChange LeftJoystick;
	private Axis leftJoystick;
	private static readonly float epsilon;

	void Start () {
		leftJoystick = new Axis();
	}
	
	void Update ()
	{
		var leftJoystickX = Input.GetAxis("LeftJoystickX");
		var leftJoystickY = Input.GetAxis("LeftJoystickY");
		var sendLeftJoystick = false;
		if (leftJoystickX > epsilon)
		{
			leftJoystick.horizontal = leftJoystickX;
			sendLeftJoystick = true;
		}
		if (leftJoystickY > epsilon)
		{
			leftJoystick.vert = leftJoystickY;
			sendLeftJoystick = true;
		}
		if (sendLeftJoystick && (LeftJoystick != null))
		{
			LeftJoystick(leftJoystick);
		}
	}
}
