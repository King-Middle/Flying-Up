using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderMusic : MonoBehaviour
{
	public AudioSource targetAudio;

	public Slider volumeSlider;

	private const string VolumePrefKey = "Volume1";

	private void Start()
	{
		if ((Object)(object)targetAudio != (Object)null && (Object)(object)volumeSlider != (Object)null)
		{
			float @float = PlayerPrefs.GetFloat("Volume1", 50f);
			volumeSlider.value = @float;
			targetAudio.volume = @float / 200f;
			((UnityEvent<float>)(object)volumeSlider.onValueChanged).AddListener((UnityAction<float>)UpdateVolume);
		}
	}

	private void UpdateVolume(float value)
	{
		if ((Object)(object)targetAudio != (Object)null)
		{
			targetAudio.volume = value / 200f;
			PlayerPrefs.SetFloat("Volume1", value);
			PlayerPrefs.Save();
		}
	}
}
