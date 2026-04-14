using UnityEngine;

public class StaminaBarController : MonoBehaviour
{
	public GameObject StaminaBar;

	public BirdController birdController;

	private void Update()
	{
		if (birdController.StaminaValue >= 12f)
		{
			if (StaminaBar.activeSelf)
			{
				Off();
			}
		}
		else if (birdController.StaminaValue != 12f && !StaminaBar.activeSelf)
		{
			On();
		}
	}

	private void On()
	{
		StaminaBar.SetActive(true);
	}

	private void Off()
	{
		StaminaBar.SetActive(false);
	}
}
