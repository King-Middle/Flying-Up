using UnityEngine;

public class PlaySoundOnAnimation : MonoBehaviour
{
	public AudioSource WingFlap;

	public AudioSource Walking;

	public void PlayTheSound()
	{
		WingFlap.Play();
	}

	public void PlayAnotherSound()
	{
		Walking.Play();
	}
}
