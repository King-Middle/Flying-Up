using UnityEngine;

public class PlaneScript : MonoBehaviour
{
	public GameObject Bird;

	public GameObject Plane;

	public GeneralPlaneScript generalPlaneScript;

	public PervaneScript pervaneScript;

	private void OnTriggerEnter(Collider collision)
	{
		if (((Component)collision).CompareTag("Player"))
		{
			generalPlaneScript.PlaneGo();
			Bird.transform.SetParent(Plane.transform);
			PervaneScript.CanTurn = true;
		}
	}

	private void OnTriggerExit(Collider collision)
	{
		if (((Component)collision).CompareTag("Player"))
		{
			Bird.transform.SetParent((Transform)null);
		}
	}
}
