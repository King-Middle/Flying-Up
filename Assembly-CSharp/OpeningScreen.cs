using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OpeningScreen : MonoBehaviour
{
	public Image targetImage;

	public float fadeSpeed = 1f;

	private bool CanStartNow;

	private void Start()
	{
		((MonoBehaviour)this).StartCoroutine(WaitAndStart());
	}

	private void Update()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		if (((Graphic)targetImage).color.a > 0f && CanStartNow)
		{
			Color color = ((Graphic)targetImage).color;
			color.a -= Time.deltaTime * fadeSpeed;
			color.a = Mathf.Clamp01(color.a);
			((Graphic)targetImage).color = color;
		}
	}

	private IEnumerator WaitAndStart()
	{
		yield return (object)new WaitForSeconds(0.3f);
		CanStartNow = true;
		yield return (object)new WaitForSeconds(0.2f);
		((Component)this).gameObject.SetActive(false);
	}
}
