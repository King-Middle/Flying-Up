using System.Collections;
using UnityEngine;

namespace TMPro.Examples;

public class SkewTextExample : MonoBehaviour
{
	private TMP_Text m_TextComponent;

	public AnimationCurve VertexCurve = new AnimationCurve((Keyframe[])(object)new Keyframe[5]
	{
		new Keyframe(0f, 0f),
		new Keyframe(0.25f, 2f),
		new Keyframe(0.5f, 0f),
		new Keyframe(0.75f, 2f),
		new Keyframe(1f, 0f)
	});

	public float CurveScale = 1f;

	public float ShearAmount = 1f;

	private void Awake()
	{
		m_TextComponent = ((Component)this).gameObject.GetComponent<TMP_Text>();
	}

	private void Start()
	{
		((MonoBehaviour)this).StartCoroutine(WarpText());
	}

	private AnimationCurve CopyAnimationCurve(AnimationCurve curve)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		return new AnimationCurve
		{
			keys = curve.keys
		};
	}

	private IEnumerator WarpText()
	{
		VertexCurve.preWrapMode = (WrapMode)1;
		VertexCurve.postWrapMode = (WrapMode)1;
		m_TextComponent.havePropertiesChanged = true;
		CurveScale *= 10f;
		float old_CurveScale = CurveScale;
		float old_ShearValue = ShearAmount;
		AnimationCurve old_curve = CopyAnimationCurve(VertexCurve);
		Vector3 val2 = default(Vector3);
		Vector3 val3 = default(Vector3);
		while (true)
		{
			if (!m_TextComponent.havePropertiesChanged && old_CurveScale == CurveScale && ((Keyframe)(ref old_curve.keys[1])).value == ((Keyframe)(ref VertexCurve.keys[1])).value && old_ShearValue == ShearAmount)
			{
				yield return null;
				continue;
			}
			old_CurveScale = CurveScale;
			old_curve = CopyAnimationCurve(VertexCurve);
			old_ShearValue = ShearAmount;
			m_TextComponent.ForceMeshUpdate(false, false);
			TMP_TextInfo textInfo = m_TextComponent.textInfo;
			int characterCount = textInfo.characterCount;
			if (characterCount == 0)
			{
				continue;
			}
			Bounds bounds = m_TextComponent.bounds;
			float x = ((Bounds)(ref bounds)).min.x;
			bounds = m_TextComponent.bounds;
			float x2 = ((Bounds)(ref bounds)).max.x;
			for (int i = 0; i < characterCount; i++)
			{
				if (textInfo.characterInfo[i].isVisible)
				{
					int vertexIndex = textInfo.characterInfo[i].vertexIndex;
					int materialReferenceIndex = textInfo.characterInfo[i].materialReferenceIndex;
					Vector3[] vertices = textInfo.meshInfo[materialReferenceIndex].vertices;
					Vector3 val = Vector2.op_Implicit(new Vector2((vertices[vertexIndex].x + vertices[vertexIndex + 2].x) / 2f, textInfo.characterInfo[i].baseLine));
					ref Vector3 reference = ref vertices[vertexIndex];
					reference += -val;
					ref Vector3 reference2 = ref vertices[vertexIndex + 1];
					reference2 += -val;
					ref Vector3 reference3 = ref vertices[vertexIndex + 2];
					reference3 += -val;
					ref Vector3 reference4 = ref vertices[vertexIndex + 3];
					reference4 += -val;
					float num = ShearAmount * 0.01f;
					((Vector3)(ref val2))._002Ector(num * (textInfo.characterInfo[i].topRight.y - textInfo.characterInfo[i].baseLine), 0f, 0f);
					((Vector3)(ref val3))._002Ector(num * (textInfo.characterInfo[i].baseLine - textInfo.characterInfo[i].bottomRight.y), 0f, 0f);
					ref Vector3 reference5 = ref vertices[vertexIndex];
					reference5 += -val3;
					ref Vector3 reference6 = ref vertices[vertexIndex + 1];
					reference6 += val2;
					ref Vector3 reference7 = ref vertices[vertexIndex + 2];
					reference7 += val2;
					ref Vector3 reference8 = ref vertices[vertexIndex + 3];
					reference8 += -val3;
					float num2 = (val.x - x) / (x2 - x);
					float num3 = num2 + 0.0001f;
					float num4 = VertexCurve.Evaluate(num2) * CurveScale;
					float num5 = VertexCurve.Evaluate(num3) * CurveScale;
					Vector3 val4 = new Vector3(1f, 0f, 0f);
					Vector3 val5 = new Vector3(num3 * (x2 - x) + x, num5) - new Vector3(val.x, num4);
					float num6 = Mathf.Acos(Vector3.Dot(val4, ((Vector3)(ref val5)).normalized)) * 57.29578f;
					float num7 = ((Vector3.Cross(val4, val5).z > 0f) ? num6 : (360f - num6));
					Matrix4x4 val6 = Matrix4x4.TRS(new Vector3(0f, num4, 0f), Quaternion.Euler(0f, 0f, num7), Vector3.one);
					vertices[vertexIndex] = ((Matrix4x4)(ref val6)).MultiplyPoint3x4(vertices[vertexIndex]);
					vertices[vertexIndex + 1] = ((Matrix4x4)(ref val6)).MultiplyPoint3x4(vertices[vertexIndex + 1]);
					vertices[vertexIndex + 2] = ((Matrix4x4)(ref val6)).MultiplyPoint3x4(vertices[vertexIndex + 2]);
					vertices[vertexIndex + 3] = ((Matrix4x4)(ref val6)).MultiplyPoint3x4(vertices[vertexIndex + 3]);
					ref Vector3 reference9 = ref vertices[vertexIndex];
					reference9 += val;
					ref Vector3 reference10 = ref vertices[vertexIndex + 1];
					reference10 += val;
					ref Vector3 reference11 = ref vertices[vertexIndex + 2];
					reference11 += val;
					ref Vector3 reference12 = ref vertices[vertexIndex + 3];
					reference12 += val;
				}
			}
			m_TextComponent.UpdateVertexData();
			yield return null;
		}
	}
}
