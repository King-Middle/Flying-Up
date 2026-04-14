using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SFXSlider : MonoBehaviour
{
	public AudioSource targetAudio;

	public Slider volumeSlider;

	public AudioSource targetAudio2;

	private const string VolumePrefKey = "Volume";

	private void Start()
	{
		if ((Object)(object)targetAudio != (Object)null && (Object)(object)volumeSlider != (Object)null)
		{
			float @float = PlayerPrefs.GetFloat("Volume", 50f);
			volumeSlider.value = @float;
			targetAudio.volume = @float / 200f;
			targetAudio2.volume = @float / 450f;
			((UnityEvent<float>)(object)volumeSlider.onValueChanged).AddListener((UnityAction<float>)UpdateVolume);
		}
	}

	private void UpdateVolume(float value)
	{
		if ((Object)(object)targetAudio != (Object)null)
		{
			targetAudio.volume = value / 200f;
			targetAudio2.volume = value / 450f;
			PlayerPrefs.SetFloat("Volume", value);
			PlayerPrefs.Save();
		}
	}
}
