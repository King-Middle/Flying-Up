using System.Collections;
using UnityEngine;

public class Balloon : MonoBehaviour
{
	public Animator animator;

	private void Start()
	{
		animator = ((Component)this).GetComponent<Animator>();
	}

	public void Go()
	{
		((MonoBehaviour)this).StartCoroutine(GoWithTime());
	}

	public void Come()
	{
		((MonoBehaviour)this).StartCoroutine(ComeWithTime());
	}

	private void Update()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		if (((Component)this).transform.position.z > 120f)
		{
			animator.SetBool("GoThere", false);
		}
		else if (((Component)this).transform.position.z < 120f)
		{
			animator.SetBool("ComeBack", false);
		}
	}

	private IEnumerator GoWithTime()
	{
		yield return (object)new WaitForSeconds(1f);
		animator.SetBool("GoThere", true);
		animator.SetBool("ComeBack", false);
	}

	private IEnumerator ComeWithTime()
	{
		yield return (object)new WaitForSeconds(1f);
		animator.SetBool("GoThere", false);
		animator.SetBool("ComeBack", true);
		animator.SetTrigger("GoThere1");
	}
}
