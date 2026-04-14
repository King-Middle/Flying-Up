using System.Collections;
using UnityEngine;

public class Instructions : MonoBehaviour
{
	public Transform Bird;

	public GameObject Instruction1;

	public GameObject Instruction2;

	public GameObject Instruction3;

	public GameObject Instruction4;

	private bool WaitingForBlackScreenToCloseIsDone;

	private void Start()
	{
		((MonoBehaviour)this).StartCoroutine(WaitForBlackScreen());
	}

	private void FixedUpdate()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		if (!WaitingForBlackScreenToCloseIsDone)
		{
			return;
		}
		if (Bird.position.y < 10f)
		{
			if (Bird.position.z < 10f && Bird.position.z > 0f)
			{
				if (Bird.position.x < -793f && Bird.position.x >= -820f)
				{
					if (!Instruction1.activeSelf)
					{
						Ins1();
					}
				}
				else if (Bird.position.x < -787f && Bird.position.x >= -793f)
				{
					if (!Instruction2.activeSelf)
					{
						Ins2();
					}
				}
				else if (Bird.position.x < -781f && Bird.position.x >= -787f)
				{
					if (!Instruction3.activeSelf)
					{
						Ins3();
					}
				}
				else if (Bird.position.x < -770f && Bird.position.x >= -781f)
				{
					if (!Instruction4.activeSelf)
					{
						Ins4();
					}
				}
				else
				{
					CloseIns();
				}
			}
			else
			{
				CloseIns();
			}
		}
		else
		{
			CloseIns();
		}
	}

	private void Ins1()
	{
		Instruction1.SetActive(true);
		Instruction2.SetActive(false);
		Instruction3.SetActive(false);
		Instruction4.SetActive(false);
	}

	private void Ins2()
	{
		Instruction1.SetActive(false);
		Instruction2.SetActive(true);
		Instruction3.SetActive(false);
		Instruction4.SetActive(false);
	}

	private void Ins3()
	{
		Instruction1.SetActive(false);
		Instruction2.SetActive(false);
		Instruction3.SetActive(true);
		Instruction4.SetActive(false);
	}

	private void Ins4()
	{
		Instruction1.SetActive(false);
		Instruction2.SetActive(false);
		Instruction3.SetActive(false);
		Instruction4.SetActive(true);
	}

	private void CloseIns()
	{
		Instruction1.SetActive(false);
		Instruction2.SetActive(false);
		Instruction3.SetActive(false);
		Instruction4.SetActive(false);
	}

	private IEnumerator WaitForBlackScreen()
	{
		yield return (object)new WaitForSeconds(0.7f);
		WaitingForBlackScreenToCloseIsDone = true;
	}
}
