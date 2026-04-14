using UnityEngine;

public class CameraScript : MonoBehaviour
{
	public Transform CameraHold;

	public void Normal()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		((Component)this).transform.position = new Vector3(0f, 0f, 0f);
		Vector3 position = ((Component)this).transform.position;
		Debug.Log((object)("Position set to: " + ((object)(Vector3)(ref position)).ToString()));
	}

	public void Closer()
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		((Component)this).transform.position = new Vector3(0f, 0f, CameraHold.rotation.x / -30f);
	}

	private void Update()
	{
	}
}
