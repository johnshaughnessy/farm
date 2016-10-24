using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MouseEvents))]
public class ClickMover : MonoBehaviour
{
	public class Mover
	{
		public IEnumerator Method;
		public Vector3 Destination;

		public Mover(IEnumerator Method, Vector3 Destination)
		{
			this.Destination = Destination;
			this.Method = Method;
		}
	}

	public class Rotator
	{
		public IEnumerator Method;
		public Vector3 Target;

		public Rotator(IEnumerator Method, Vector3 Target)
		{
			this.Method = Method;
			this.Target = Target;
		}
	}

	public Rotator rotator;
	public Mover transformer;

	private MouseEvents mouse;
	[SerializeField] private LayerMask layerMask;
	[SerializeField] private GameObject plane;
	[SerializeField] public float MoveSpeed;
	[SerializeField] public float AngularMoveSpeed;
	[SerializeField] public Transform thingThatRotates;
	[SerializeField] public Transform thingThatMoves;

	void Start ()
	{
		mouse = GetComponent<MouseEvents>();
		mouse.RightClick += CreateTransformer;
		mouse.RightClick += CreateRotator;
	}

	private void CreateRotator()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100.0f, layerMask))
		{
			rotator = new Rotator(RotateToSpot.RotateToSpotWithSpeed(thingThatRotates, hit.point, AngularMoveSpeed), hit.point);
		}
	}

	private void CreateTransformer()
	{
		if (transformer != null)
		{
			StopCoroutine(transformer.Method);
		}
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100.0f, layerMask))
		{
			transformer = new Mover(Movers.MoveToSpotWithSpeed(thingThatMoves, hit.point, MoveSpeed), hit.point);
			StartCoroutine(transformer.Method);
		}
	}

}

