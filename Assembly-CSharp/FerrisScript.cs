using UnityEngine;

public class FerrisScript : MonoBehaviour
{
	private void Update()
	{
		((Component)this).transform.Rotate(0f, 0f, 0.2f);
	}
}
