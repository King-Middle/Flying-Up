using UnityEngine;
using UnityEngine.SceneManagement;

public class NestScript : MonoBehaviour
{
	public CameraMovement cameraMovement;

	public GameObject BlackingScreen;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			BlackingScreen.SetActive(true);
			SceneManager.LoadScene(2);
		}
	}
}
