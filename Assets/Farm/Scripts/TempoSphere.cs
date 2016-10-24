using System.Collections;
using UnityEngine;
using SonicBloom.Koreo;

public class TempoSphere : MonoBehaviour
{
	[EventID] [SerializeField] private string tempo;
	private Renderer rend;
	private IEnumerator grower;
	private MouseEvents mouse;

	void Start()
	{ 
		Koreographer.Instance.RegisterForEvents(tempo, OnTempo);
		mouse = GetComponent<MouseEvents>();
		mouse.RightClick += DoGrow;
	}

	private void OnTempo(KoreographyEvent koreoevent)
	{
		DoGrow();
	}

	public void DoGrow()
	{
		if (grower != null)
		{
			transform.localScale = Vector3.one;
			StopCoroutine(grower);
		}
		grower = Grow();
		StartCoroutine(grower);
	}

	private IEnumerator Grow()
	{
		var time = Time.time;
		var endTime = Time.time + 0.2f;
		while (time < endTime)
		{
			yield return new WaitForEndOfFrame();
			time = Time.time;

			transform.localScale = transform.localScale*1.1f;
		}
		transform.localScale = Vector3.one;
	}
}
