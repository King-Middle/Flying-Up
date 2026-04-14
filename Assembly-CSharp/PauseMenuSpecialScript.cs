using UnityEngine;

public class PauseMenuSpecialScript : MonoBehaviour
{
	private void Start()
	{
		((Component)this).gameObject.SetActive(false);
	}
}
