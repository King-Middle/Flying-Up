using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	private Animator animator;

	public BirdController birdController;

	private void Start()
	{
		animator = ((Component)this).GetComponent<Animator>();
	}

	public void Win()
	{
		Time.timeScale = 0f;
		animator.SetTrigger("CameraEnding");
		birdController.Win();
	}
}
