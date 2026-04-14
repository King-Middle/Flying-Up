using UnityEngine;
using UnityEngine.UI;

namespace TMPro.Examples;

public class Benchmark04 : MonoBehaviour
{
	public int SpawnType;

	public int MinPointSize = 12;

	public int MaxPointSize = 64;

	public int Steps = 4;

	private Transform m_Transform;

	private void Start()
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		m_Transform = ((Component)this).transform;
		float num = 0f;
		float num3 = (Camera.main.orthographicSize = Screen.height / 2);
		float num4 = num3;
		float num5 = (float)Screen.width / (float)Screen.height;
		for (int i = MinPointSize; i <= MaxPointSize; i += Steps)
		{
			if (SpawnType == 0)
			{
				GameObject val = new GameObject("Text - " + i + " Pts");
				if (num > num4 * 2f)
				{
					break;
				}
				val.transform.position = m_Transform.position + new Vector3(num5 * (0f - num4) * 0.975f, num4 * 0.975f - num, 0f);
				TextMeshPro obj = val.AddComponent<TextMeshPro>();
				((TMP_Text)obj).rectTransform.pivot = new Vector2(0f, 0.5f);
				((TMP_Text)obj).textWrappingMode = (TextWrappingModes)0;
				((TMP_Text)obj).extraPadding = true;
				((TMP_Text)obj).isOrthographic = true;
				((TMP_Text)obj).fontSize = i;
				((TMP_Text)obj).text = i + " pts - Lorem ipsum dolor sit...";
				((Graphic)obj).color = Color32.op_Implicit(new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue));
				num += (float)i;
			}
		}
	}
}
