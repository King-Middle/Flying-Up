using UnityEngine;

public class PervaneScript : MonoBehaviour
{
	public static bool CanTurn;

	private void Update()
	{
		if (CanTurn)
		{
			((Component)this).transform.Rotate(0f, 0f, 12f);
		}
	}
}
