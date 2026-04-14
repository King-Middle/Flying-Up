using UnityEngine;
using UnityEngine.EventSystems;

namespace TMPro.Examples;

public class TMP_TextSelector_A : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	private TextMeshPro m_TextMeshPro;

	private Camera m_Camera;

	private bool m_isHoveringObject;

	private int m_selectedLink = -1;

	private int m_lastCharIndex = -1;

	private int m_lastWordIndex = -1;

	private void Awake()
	{
		m_TextMeshPro = ((Component)this).gameObject.GetComponent<TextMeshPro>();
		m_Camera = Camera.main;
		((TMP_Text)m_TextMeshPro).ForceMeshUpdate(false, false);
	}

	private void LateUpdate()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_033d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		m_isHoveringObject = false;
		if (TMP_TextUtilities.IsIntersectingRectTransform(((TMP_Text)m_TextMeshPro).rectTransform, Input.mousePosition, Camera.main))
		{
			m_isHoveringObject = true;
		}
		if (!m_isHoveringObject)
		{
			return;
		}
		int num = TMP_TextUtilities.FindIntersectingCharacter((TMP_Text)(object)m_TextMeshPro, Input.mousePosition, Camera.main, true);
		if (num != -1 && num != m_lastCharIndex && (Input.GetKey((KeyCode)304) || Input.GetKey((KeyCode)303)))
		{
			m_lastCharIndex = num;
			int materialReferenceIndex = ((TMP_Text)m_TextMeshPro).textInfo.characterInfo[num].materialReferenceIndex;
			int vertexIndex = ((TMP_Text)m_TextMeshPro).textInfo.characterInfo[num].vertexIndex;
			Color32 val = default(Color32);
			((Color32)(ref val))._002Ector((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), byte.MaxValue);
			Color32[] colors = ((TMP_Text)m_TextMeshPro).textInfo.meshInfo[materialReferenceIndex].colors32;
			colors[vertexIndex] = val;
			colors[vertexIndex + 1] = val;
			colors[vertexIndex + 2] = val;
			colors[vertexIndex + 3] = val;
			((TMP_Text)m_TextMeshPro).textInfo.meshInfo[materialReferenceIndex].mesh.colors32 = colors;
		}
		int num2 = TMP_TextUtilities.FindIntersectingLink((TMP_Text)(object)m_TextMeshPro, Input.mousePosition, m_Camera);
		if ((num2 == -1 && m_selectedLink != -1) || num2 != m_selectedLink)
		{
			m_selectedLink = -1;
		}
		if (num2 != -1 && num2 != m_selectedLink)
		{
			m_selectedLink = num2;
			TMP_LinkInfo val2 = ((TMP_Text)m_TextMeshPro).textInfo.linkInfo[num2];
			Vector3 val3 = default(Vector3);
			RectTransformUtility.ScreenPointToWorldPointInRectangle(((TMP_Text)m_TextMeshPro).rectTransform, Vector2.op_Implicit(Input.mousePosition), m_Camera, ref val3);
			string linkID = ((TMP_LinkInfo)(ref val2)).GetLinkID();
			if (!(linkID == "id_01"))
			{
				_ = linkID == "id_02";
			}
		}
		int num3 = TMP_TextUtilities.FindIntersectingWord((TMP_Text)(object)m_TextMeshPro, Input.mousePosition, Camera.main);
		if (num3 != -1 && num3 != m_lastWordIndex)
		{
			m_lastWordIndex = num3;
			TMP_WordInfo val4 = ((TMP_Text)m_TextMeshPro).textInfo.wordInfo[num3];
			Vector3 val5 = m_TextMeshPro.transform.TransformPoint(((TMP_Text)m_TextMeshPro).textInfo.characterInfo[val4.firstCharacterIndex].bottomLeft);
			val5 = Camera.main.WorldToScreenPoint(val5);
			Color32[] colors2 = ((TMP_Text)m_TextMeshPro).textInfo.meshInfo[0].colors32;
			Color32 val6 = default(Color32);
			((Color32)(ref val6))._002Ector((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), byte.MaxValue);
			for (int i = 0; i < val4.characterCount; i++)
			{
				int vertexIndex2 = ((TMP_Text)m_TextMeshPro).textInfo.characterInfo[val4.firstCharacterIndex + i].vertexIndex;
				colors2[vertexIndex2] = val6;
				colors2[vertexIndex2 + 1] = val6;
				colors2[vertexIndex2 + 2] = val6;
				colors2[vertexIndex2 + 3] = val6;
			}
			((TMP_Text)m_TextMeshPro).mesh.colors32 = colors2;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log((object)"OnPointerEnter()");
		m_isHoveringObject = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log((object)"OnPointerExit()");
		m_isHoveringObject = false;
	}
}
