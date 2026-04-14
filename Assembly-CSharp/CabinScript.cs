using UnityEngine;

public class CabinScript : MonoBehaviour
{
	public GameObject Bird;

	public GameObject Ferris;

	private void Update()
	{
		((Component)this).transform.Rotate(0f, 0f, -0.2f);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			Bird.transform.SetParent(Ferris.transform);
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			Bird.transform.SetParent((Transform)null);
		}
	}
}
