using UnityEngine;

public class ScaleOffsetWithMouse : MonoBehaviour
{
	[SerializeField] private MouseAxis mouse;
	private MaintainOffsetFrom offsetMaintainer;
	private static readonly float epsilon = 0.01f;

	void Start ()
	{
		offsetMaintainer = GetComponent<MaintainOffsetFrom>();
	}

	void Update ()
	{
		if (Mathf.Abs(mouse.scrollWheel) > epsilon)
		{
			offsetMaintainer.Offset = offsetMaintainer.Offset*(1.0f-mouse.scrollWheel);
		}
	}
}
