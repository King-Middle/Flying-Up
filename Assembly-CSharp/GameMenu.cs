using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
	public GameObject MenuOnGame;

	public bool MenuIsOn;

	public GameObject AreYouSure;

	public GameObject AreYouSure2;

	public Transform Player;

	private void Start()
	{
		Time.timeScale = 1f;
		((MonoBehaviour)this).StartCoroutine(WaitAndClose());
		MenuOnGame.SetActive(true);
	}

	private void Update()
	{
		if (Input.GetKeyDown((KeyCode)27) && !MenuIsOn)
		{
			Pause();
		}
	}

	private void Pause()
	{
		MenuOnGame.SetActive(true);
		Time.timeScale = 0f;
		MenuIsOn = true;
	}

	public void Resume()
	{
		MenuOnGame.SetActive(false);
		Time.timeScale = 1f;
		MenuIsOn = false;
	}

	public void GoToMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("Entry");
	}

	public void OpenAreYouSure()
	{
		AreYouSure.SetActive(true);
	}

	public void CancelQuit()
	{
		AreYouSure.SetActive(false);
	}

	public void OpenAreYouSure2()
	{
		AreYouSure2.SetActive(true);
	}

	public void CancelQuit2()
	{
		AreYouSure2.SetActive(false);
	}

	public void Restart()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		Scene activeScene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(((Scene)(ref activeScene)).name);
		Time.timeScale = 1f;
	}

	private void FixedUpdate()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		if (Player.position.y < -2f)
		{
			Player.position = new Vector3(-805f, 0f, 5f);
		}
	}

	private IEnumerator WaitAndClose()
	{
		yield return (object)new WaitForSeconds(0.01f);
		MenuOnGame.SetActive(false);
	}
}
