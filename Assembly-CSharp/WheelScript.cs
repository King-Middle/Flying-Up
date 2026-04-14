using UnityEngine;

public class WheelScript : MonoBehaviour
{
	public GameObject Bird;

	public GameObject Wheel;

	private bool BirdIsTouching;

	public Transform BirdTransform;

	private void Update()
	{
		((Component)this).transform.Rotate(0f, 1.2f, 0f);
		if (BirdIsTouching)
		{
			BirdTransform.Rotate(0f, -1.2f, 0f);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		Bird.transform.SetParent(Wheel.transform);
		BirdIsTouching = true;
	}

	private void OnCollisionExit(Collision collision)
	{
		Bird.transform.SetParent((Transform)null);
		BirdIsTouching = false;
	}
}
