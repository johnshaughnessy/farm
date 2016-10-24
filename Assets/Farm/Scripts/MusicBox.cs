using UnityEngine;
using SonicBloom.Koreo;

public class MusicBox : MonoBehaviour
{
	[EventID] [SerializeField] private string koreoEventID;
	[SerializeField] private float minEmission = 1;
	[SerializeField] private float maxEmission = 2;

	private Material mat;
	private float emission = 1;
	[SerializeField] private float emissionDecayRate = 0.05f;
	[SerializeField] private float emissionBump;
	[SerializeField] private Color ogEmissionColor;
	[SerializeField] private float defaultEmission = 0.33f;
	
	void Start ()
	{

		mat = GetComponent<Renderer>().sharedMaterial;
		mat.EnableKeyword("_EMISSION");
		mat.SetColor("_EmissionColor", defaultEmission * ogEmissionColor);

		Koreographer.Instance.RegisterForEvents(koreoEventID, LightUp);
	}

	void Update()
	{
		emission = Mathf.Clamp(Decay(emission, emissionDecayRate), minEmission, maxEmission);
		mat.SetColor("_EmissionColor", emission * ogEmissionColor);
	}

	private static float Decay(float f, float rate)
	{
		return f - rate;
	}

	private void LightUp(KoreographyEvent koreoevent)
	{
		emission += emissionBump;
	}
}
