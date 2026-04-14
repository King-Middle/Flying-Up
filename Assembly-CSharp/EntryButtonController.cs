using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EntryButtonController : MonoBehaviour
{
	public GameObject AreYouSurePanel;

	public GameObject Settings;

	public GameObject Credits;

	public GameObject PauseMenuPanel;

	public GameObject BlackScreen;

	private bool CanStartNow;

	public Image targetImage;

	private float fadeSpeed = 3f;

	private void Start()
	{
		((MonoBehaviour)this).StartCoroutine(ClosePanelMenuPause());
	}

	public void StartTheGame()
	{
		SceneManager.LoadScene("Main Game");
	}

	public void EndTheGame()
	{
		Application.Quit();
	}

	public void CancelQuit()
	{
		AreYouSurePanel.SetActive(false);
	}

	public void OpenPanel()
	{
		AreYouSurePanel.SetActive(true);
	}

	public void OpenSettings()
	{
		Settings.SetActive(true);
	}

	public void CloseSettings()
	{
		Settings.SetActive(false);
	}

	public void OpenCredits()
	{
		Credits.SetActive(true);
	}

	public void CloseCredits()
	{
		Credits.SetActive(false);
	}

	private void Update()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		if (((Graphic)targetImage).color.a > 0f && CanStartNow)
		{
			Color color = ((Graphic)targetImage).color;
			color.a -= Time.deltaTime * fadeSpeed;
			color.a = Mathf.Clamp01(color.a);
			((Graphic)targetImage).color = color;
		}
	}

	private IEnumerator ClosePanelMenuPause()
	{
		yield return (object)new WaitForSeconds(0.01f);
		PauseMenuPanel.SetActive(false);
		Credits.SetActive(false);
		yield return (object)new WaitForSeconds(0.1f);
		CanStartNow = true;
		yield return (object)new WaitForSeconds(0.2f);
		BlackScreen.SetActive(false);
	}
}
