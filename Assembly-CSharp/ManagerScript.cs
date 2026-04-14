using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScript : MonoBehaviour
{
	public GameObject EndingScreen;

	private void Start()
	{
		((MonoBehaviour)this).StartCoroutine(ManageEnding());
		Cursor.lockState = (CursorLockMode)1;
	}

	private void Update()
	{
		if (Input.GetKeyDown((KeyCode)27))
		{
			Cursor.lockState = (CursorLockMode)0;
			SceneManager.LoadScene("Entry");
		}
		else if (Input.GetKeyDown((KeyCode)32))
		{
			Cursor.lockState = (CursorLockMode)0;
			SceneManager.LoadScene("Entry");
		}
	}

	private IEnumerator ManageEnding()
	{
		yield return (object)new WaitForSeconds(16.5f);
		EndingScreen.SetActive(true);
		yield return (object)new WaitForSeconds(3.5f);
		Cursor.lockState = (CursorLockMode)0;
		SceneManager.LoadScene("Entry");
	}
}
