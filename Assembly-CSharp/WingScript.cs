using UnityEngine;

public class WingScript : MonoBehaviour
{
	private void Update()
	{
		((Component)this).transform.Rotate(0f, 1.5f, 0f);
	}
}
