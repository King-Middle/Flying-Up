using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AimSlider : MonoBehaviour
{
	public Slider aimSlider;

	public BirdController birdController;

	private void Start()
	{
		float @float = PlayerPrefs.GetFloat("MouseSensitivity", 2f);
		birdController.MouseSensitivity = @float;
		aimSlider.value = @float;
		((UnityEvent<float>)(object)aimSlider.onValueChanged).AddListener((UnityAction<float>)delegate(float value)
		{
			UpdateSensitivity(value);
		});
	}

	private void UpdateSensitivity(float value)
	{
		birdController.MouseSensitivity = value;
		PlayerPrefs.SetFloat("MouseSensitivity", value);
		PlayerPrefs.Save();
	}
}
