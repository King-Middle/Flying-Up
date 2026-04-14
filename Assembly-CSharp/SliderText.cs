using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderText : MonoBehaviour
{
	public Slider slider;

	public TMP_Text text;

	private void Start()
	{
		text = ((Component)this).GetComponent<TMP_Text>();
		if ((Object)(object)slider != (Object)null)
		{
			UpdateText(slider.value);
			((UnityEvent<float>)(object)slider.onValueChanged).AddListener((UnityAction<float>)UpdateText);
		}
	}

	private void UpdateText(float value)
	{
		if ((double)(value % 1f) < 0.005 || ((double)value + 0.0051) % 1.0 < 0.005)
		{
			text.text = value.ToString("0");
		}
		else if ((double)value % 0.1 < 0.005 || ((double)value + 0.0051) % 0.1 < 0.005)
		{
			text.text = value.ToString("0.0");
		}
		else
		{
			text.text = value.ToString("0.00");
		}
	}
}
