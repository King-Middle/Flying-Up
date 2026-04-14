using System.Collections;
using UnityEngine;

public class GeneralPlaneScript : MonoBehaviour
{
	private Animator animator;

	private void Start()
	{
		animator = ((Component)this).GetComponent<Animator>();
	}

	public void PlaneGo()
	{
		((MonoBehaviour)this).StartCoroutine(PlaneGoWithTime());
	}

	private IEnumerator PlaneGoWithTime()
	{
		yield return (object)new WaitForSeconds(1.5f);
		animator.SetTrigger("PlaneGo");
	}
}
