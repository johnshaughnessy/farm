using SonicBloom.Koreo;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Hover : MonoBehaviour
{
	private float force;
	private Rigidbody rigidbody;
	private static readonly float antiGrav = 9.6f;

	void Start ()
	{
		rigidbody = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate ()
	{
		var max = antiGrav;
		var time = Time.time*3.0f;
		force = Mathf.Clamp(Mathf.Sin(time)*max, antiGrav*0.8f, max);
		rigidbody.AddForce(force*Time.deltaTime*Vector3.up, ForceMode.Impulse);
	}
}
