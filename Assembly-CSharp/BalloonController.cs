using UnityEngine;

public class BalloonController : MonoBehaviour
{
	public Balloon balloon;

	public GameObject Bird;

	public GameObject Balon;

	private void OnTriggerEnter(Collider collider)
	{
		Bird.transform.SetParent(Balon.transform);
		balloon.Go();
	}

	private void OnTriggerExit(Collider collider)
	{
		Bird.transform.SetParent((Transform)null);
		balloon.Come();
	}
}
