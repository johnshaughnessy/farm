using UnityEngine;
using SonicBloom.Koreo;

public class MusicBox : MonoBehaviour
{
	[EventID] [SerializeField] private string koreoEventID;
	[SerializeField] private float minEmission = 1;
	[SerializeField] private float maxEmission = 2;
	[SerializeField] private string emissionColorName = "_EmissionColor";

	private Material mat;
	private float emission = 1;
	[SerializeField] private float emissionDecayRate = 0.05f;
	[SerializeField] private float emissionBump;
	[SerializeField] private Color ogEmissionColor;
	[SerializeField] private float defaultEmission = 0.33f;
	[SerializeField] private int offset = 0;
	private int count = 0;
	
	void Start ()
	{
		mat = GetComponent<Renderer>().sharedMaterial;
		mat.EnableKeyword("_EMISSION");
		mat.SetColor(emissionColorName, defaultEmission * ogEmissionColor);

		Koreographer.Instance.RegisterForEvents(koreoEventID, LightUp);
	}

	void Update()
	{
		emission = Mathf.Clamp(Decay(emission, emissionDecayRate), minEmission, maxEmission);
		mat.SetColor(emissionColorName, emission * ogEmissionColor);
	}

	private static float Decay(float f, float rate)
	{
		return f - rate;
	}

	private void LightUp(KoreographyEvent koreoevent)
	{
		if (count%4 == offset)
		{
			emission += emissionBump;
		}
		count = count + 1;
	}
}
