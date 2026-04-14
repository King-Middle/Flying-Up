using UnityEngine;

public class RotateOnScroll : MonoBehaviour
{
	public float rotationSpeed = 2000f;

	private void Update()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		float axis = Input.GetAxis("Mouse ScrollWheel");
		if (axis != 0f)
		{
			float num = axis * rotationSpeed * Time.deltaTime * 10f;
			((Component)this).transform.Rotate(Vector3.up, num);
		}
	}
}
