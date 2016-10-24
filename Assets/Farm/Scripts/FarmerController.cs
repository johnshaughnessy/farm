using UnityEngine;

[RequireComponent(typeof(ClickMover))]
public class FarmerController : MonoBehaviour
{
	[SerializeField]
	[Range(0.0f, 6.0f)]
	private float moveSpeed;

	public ClickMover ClickMover;
	private XboxMover xboxMover;
	private ClickMover.Mover transformer;
	private ClickMover.Mover rotator;
	[SerializeField]
	private Animator anim;
	private static readonly float epsilon = 0.1f;

	void Awake()
	{
		ClickMover = GetComponent<ClickMover>();
		xboxMover = GetComponent<XboxMover>();
	}

	void Update()
	{
		transformer = ClickMover.transformer;
		ClickMover.MoveSpeed = moveSpeed;
		xboxMover.MoveSpeed = moveSpeed;

		if (transformer != null)
		{
			if (Vector3.Distance(transform.position, transformer.Destination) < epsilon)
			{
				anim.SetFloat("MoveSpeed", 0f);
			}
			else
			{
				ClickMover.thingThatRotates.forward = transformer.Destination - ClickMover.thingThatMoves.position;
				anim.SetFloat("MoveSpeed", moveSpeed);
			}
		}
	}
}
