using System.Collections;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
	public Transform Ball;

	private void OnTriggerEnter(Collider collider)
	{
		if (((Component)collider).CompareTag("SoccerBall"))
		{
			((MonoBehaviour)this).StartCoroutine(BallGoal());
		}
	}

	private IEnumerator BallGoal()
	{
		yield return (object)new WaitForSeconds(1.5f);
		Ball.position = new Vector3(-699.57f, 720.1484f, 45.26f);
	}
}
