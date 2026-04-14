using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
	public BirdController birdController;

	public Slider slider;

	private void Update()
	{
		slider.value = birdController.StaminaValue;
	}
}
