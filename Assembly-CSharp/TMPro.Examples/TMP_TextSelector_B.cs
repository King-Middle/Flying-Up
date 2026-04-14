using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TMPro.Examples;

public class TMP_TextSelector_B : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler, IPointerUpHandler
{
	public RectTransform TextPopup_Prefab_01;

	private RectTransform m_TextPopup_RectTransform;

	private TextMeshProUGUI m_TextPopup_TMPComponent;

	private const string k_LinkText = "You have selected link <#ffff00>";

	private const string k_WordText = "Word Index: <#ffff00>";

	private TextMeshProUGUI m_TextMeshPro;

	private Canvas m_Canvas;

	private Camera m_Camera;

	private bool isHoveringObject;

	private int m_selectedWord = -1;

	private int m_selectedLink = -1;

	private int m_lastIndex = -1;

	private Matrix4x4 m_matrix;

	private TMP_MeshInfo[] m_cachedMeshInfoVertexData;

	private void Awake()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		m_TextMeshPro = ((Component)this).gameObject.GetComponent<TextMeshProUGUI>();
		m_Canvas = ((Component)this).gameObject.GetComponentInParent<Canvas>();
		if ((int)m_Canvas.renderMode == 0)
		{
			m_Camera = null;
		}
		else
		{
			m_Camera = m_Canvas.worldCamera;
		}
		m_TextPopup_RectTransform = Object.Instantiate<RectTransform>(TextPopup_Prefab_01);
		((Transform)m_TextPopup_RectTransform).SetParent(((Component)m_Canvas).transform, false);
		m_TextPopup_TMPComponent = ((Component)m_TextPopup_RectTransform).GetComponentInChildren<TextMeshProUGUI>();
		((Component)m_TextPopup_RectTransform).gameObject.SetActive(false);
	}

	private void OnEnable()
	{
		TMPro_EventManager.TEXT_CHANGED_EVENT.Add((Action<Object>)ON_TEXT_CHANGED);
	}

	private void OnDisable()
	{
		TMPro_EventManager.TEXT_CHANGED_EVENT.Remove((Action<Object>)ON_TEXT_CHANGED);
	}

	private void ON_TEXT_CHANGED(Object obj)
	{
		if (obj == (Object)(object)m_TextMeshPro)
		{
			m_cachedMeshInfoVertexData = ((TMP_Text)m_TextMeshPro).textInfo.CopyMeshInfoVertexData();
		}
	}

	private void LateUpdate()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_0583: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_0407: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Unknown result type (might be due to invalid IL or missing references)
		//IL_0415: Unknown result type (might be due to invalid IL or missing references)
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		//IL_042a: Unknown result type (might be due to invalid IL or missing references)
		//IL_042c: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0604: Unknown result type (might be due to invalid IL or missing references)
		//IL_0561: Unknown result type (might be due to invalid IL or missing references)
		//IL_0643: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_051b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0525: Unknown result type (might be due to invalid IL or missing references)
		//IL_052a: Unknown result type (might be due to invalid IL or missing references)
		//IL_052f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0531: Unknown result type (might be due to invalid IL or missing references)
		//IL_053b: Unknown result type (might be due to invalid IL or missing references)
		//IL_053d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0547: Unknown result type (might be due to invalid IL or missing references)
		//IL_0549: Unknown result type (might be due to invalid IL or missing references)
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		//IL_0554: Unknown result type (might be due to invalid IL or missing references)
		//IL_0672: Unknown result type (might be due to invalid IL or missing references)
		if (isHoveringObject)
		{
			int num = TMP_TextUtilities.FindIntersectingCharacter((TMP_Text)(object)m_TextMeshPro, Input.mousePosition, m_Camera, true);
			if (num == -1 || num != m_lastIndex)
			{
				RestoreCachedVertexAttributes(m_lastIndex);
				m_lastIndex = -1;
			}
			if (num != -1 && num != m_lastIndex && (Input.GetKey((KeyCode)304) || Input.GetKey((KeyCode)303)))
			{
				m_lastIndex = num;
				int materialReferenceIndex = ((TMP_Text)m_TextMeshPro).textInfo.characterInfo[num].materialReferenceIndex;
				int vertexIndex = ((TMP_Text)m_TextMeshPro).textInfo.characterInfo[num].vertexIndex;
				Vector3[] vertices = ((TMP_Text)m_TextMeshPro).textInfo.meshInfo[materialReferenceIndex].vertices;
				Vector3 val = Vector2.op_Implicit(Vector2.op_Implicit((vertices[vertexIndex] + vertices[vertexIndex + 2]) / 2f));
				vertices[vertexIndex] -= val;
				vertices[vertexIndex + 1] = vertices[vertexIndex + 1] - val;
				vertices[vertexIndex + 2] = vertices[vertexIndex + 2] - val;
				vertices[vertexIndex + 3] = vertices[vertexIndex + 3] - val;
				float num2 = 1.5f;
				m_matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, Vector3.one * num2);
				vertices[vertexIndex] = ((Matrix4x4)(ref m_matrix)).MultiplyPoint3x4(vertices[vertexIndex]);
				vertices[vertexIndex + 1] = ((Matrix4x4)(ref m_matrix)).MultiplyPoint3x4(vertices[vertexIndex + 1]);
				vertices[vertexIndex + 2] = ((Matrix4x4)(ref m_matrix)).MultiplyPoint3x4(vertices[vertexIndex + 2]);
				vertices[vertexIndex + 3] = ((Matrix4x4)(ref m_matrix)).MultiplyPoint3x4(vertices[vertexIndex + 3]);
				vertices[vertexIndex] += val;
				vertices[vertexIndex + 1] = vertices[vertexIndex + 1] + val;
				vertices[vertexIndex + 2] = vertices[vertexIndex + 2] + val;
				vertices[vertexIndex + 3] = vertices[vertexIndex + 3] + val;
				Color32 val2 = default(Color32);
				((Color32)(ref val2))._002Ector(byte.MaxValue, byte.MaxValue, (byte)192, byte.MaxValue);
				Color32[] colors = ((TMP_Text)m_TextMeshPro).textInfo.meshInfo[materialReferenceIndex].colors32;
				colors[vertexIndex] = val2;
				colors[vertexIndex + 1] = val2;
				colors[vertexIndex + 2] = val2;
				colors[vertexIndex + 3] = val2;
				TMP_MeshInfo val3 = ((TMP_Text)m_TextMeshPro).textInfo.meshInfo[materialReferenceIndex];
				int num3 = vertices.Length - 4;
				((TMP_MeshInfo)(ref val3)).SwapVertexData(vertexIndex, num3);
				((TMP_Text)m_TextMeshPro).UpdateVertexData((TMP_VertexDataUpdateFlags)255);
			}
			int num4 = TMP_TextUtilities.FindIntersectingWord((TMP_Text)(object)m_TextMeshPro, Input.mousePosition, m_Camera);
			if ((Object)(object)m_TextPopup_RectTransform != (Object)null && m_selectedWord != -1 && (num4 == -1 || num4 != m_selectedWord))
			{
				TMP_WordInfo val4 = ((TMP_Text)m_TextMeshPro).textInfo.wordInfo[m_selectedWord];
				for (int i = 0; i < val4.characterCount; i++)
				{
					int num5 = val4.firstCharacterIndex + i;
					int materialReferenceIndex2 = ((TMP_Text)m_TextMeshPro).textInfo.characterInfo[num5].materialReferenceIndex;
					int vertexIndex2 = ((TMP_Text)m_TextMeshPro).textInfo.characterInfo[num5].vertexIndex;
					Color32[] colors2 = ((TMP_Text)m_TextMeshPro).textInfo.meshInfo[materialReferenceIndex2].colors32;
					colors2[vertexIndex2 + 3] = (colors2[vertexIndex2 + 2] = (colors2[vertexIndex2 + 1] = (colors2[vertexIndex2] = TMPro_ExtensionMethods.Tint(colors2[vertexIndex2], 1.33333f))));
				}
				((TMP_Text)m_TextMeshPro).UpdateVertexData((TMP_VertexDataUpdateFlags)255);
				m_selectedWord = -1;
			}
			if (num4 != -1 && num4 != m_selectedWord && !Input.GetKey((KeyCode)304) && !Input.GetKey((KeyCode)303))
			{
				m_selectedWord = num4;
				TMP_WordInfo val5 = ((TMP_Text)m_TextMeshPro).textInfo.wordInfo[num4];
				for (int j = 0; j < val5.characterCount; j++)
				{
					int num6 = val5.firstCharacterIndex + j;
					int materialReferenceIndex3 = ((TMP_Text)m_TextMeshPro).textInfo.characterInfo[num6].materialReferenceIndex;
					int vertexIndex3 = ((TMP_Text)m_TextMeshPro).textInfo.characterInfo[num6].vertexIndex;
					Color32[] colors3 = ((TMP_Text)m_TextMeshPro).textInfo.meshInfo[materialReferenceIndex3].colors32;
					colors3[vertexIndex3 + 3] = (colors3[vertexIndex3 + 2] = (colors3[vertexIndex3 + 1] = (colors3[vertexIndex3] = TMPro_ExtensionMethods.Tint(colors3[vertexIndex3], 0.75f))));
				}
				((TMP_Text)m_TextMeshPro).UpdateVertexData((TMP_VertexDataUpdateFlags)255);
			}
			int num7 = TMP_TextUtilities.FindIntersectingLink((TMP_Text)(object)m_TextMeshPro, Input.mousePosition, m_Camera);
			if ((num7 == -1 && m_selectedLink != -1) || num7 != m_selectedLink)
			{
				((Component)m_TextPopup_RectTransform).gameObject.SetActive(false);
				m_selectedLink = -1;
			}
			if (num7 == -1 || num7 == m_selectedLink)
			{
				return;
			}
			m_selectedLink = num7;
			TMP_LinkInfo val6 = ((TMP_Text)m_TextMeshPro).textInfo.linkInfo[num7];
			Vector3 position = default(Vector3);
			RectTransformUtility.ScreenPointToWorldPointInRectangle(((TMP_Text)m_TextMeshPro).rectTransform, Vector2.op_Implicit(Input.mousePosition), m_Camera, ref position);
			string linkID = ((TMP_LinkInfo)(ref val6)).GetLinkID();
			if (!(linkID == "id_01"))
			{
				if (linkID == "id_02")
				{
					((Transform)m_TextPopup_RectTransform).position = position;
					((Component)m_TextPopup_RectTransform).gameObject.SetActive(true);
					((TMP_Text)m_TextPopup_TMPComponent).text = "You have selected link <#ffff00> ID 02";
				}
			}
			else
			{
				((Transform)m_TextPopup_RectTransform).position = position;
				((Component)m_TextPopup_RectTransform).gameObject.SetActive(true);
				((TMP_Text)m_TextPopup_TMPComponent).text = "You have selected link <#ffff00> ID 01";
			}
		}
		else if (m_lastIndex != -1)
		{
			RestoreCachedVertexAttributes(m_lastIndex);
			m_lastIndex = -1;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		isHoveringObject = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		isHoveringObject = false;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}

	private void RestoreCachedVertexAttributes(int index)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Unknown result type (might be due to invalid IL or missing references)
		//IL_035e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		//IL_039d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e0: Unknown result type (might be due to invalid IL or missing references)
		if (index != -1 && index <= ((TMP_Text)m_TextMeshPro).textInfo.characterCount - 1)
		{
			int materialReferenceIndex = ((TMP_Text)m_TextMeshPro).textInfo.characterInfo[index].materialReferenceIndex;
			int vertexIndex = ((TMP_Text)m_TextMeshPro).textInfo.characterInfo[index].vertexIndex;
			Vector3[] vertices = m_cachedMeshInfoVertexData[materialReferenceIndex].vertices;
			Vector3[] vertices2 = ((TMP_Text)m_TextMeshPro).textInfo.meshInfo[materialReferenceIndex].vertices;
			vertices2[vertexIndex] = vertices[vertexIndex];
			vertices2[vertexIndex + 1] = vertices[vertexIndex + 1];
			vertices2[vertexIndex + 2] = vertices[vertexIndex + 2];
			vertices2[vertexIndex + 3] = vertices[vertexIndex + 3];
			Color32[] colors = ((TMP_Text)m_TextMeshPro).textInfo.meshInfo[materialReferenceIndex].colors32;
			Color32[] colors2 = m_cachedMeshInfoVertexData[materialReferenceIndex].colors32;
			colors[vertexIndex] = colors2[vertexIndex];
			colors[vertexIndex + 1] = colors2[vertexIndex + 1];
			colors[vertexIndex + 2] = colors2[vertexIndex + 2];
			colors[vertexIndex + 3] = colors2[vertexIndex + 3];
			Vector4[] uvs = m_cachedMeshInfoVertexData[materialReferenceIndex].uvs0;
			Vector4[] uvs2 = ((TMP_Text)m_TextMeshPro).textInfo.meshInfo[materialReferenceIndex].uvs0;
			uvs2[vertexIndex] = uvs[vertexIndex];
			uvs2[vertexIndex + 1] = uvs[vertexIndex + 1];
			uvs2[vertexIndex + 2] = uvs[vertexIndex + 2];
			uvs2[vertexIndex + 3] = uvs[vertexIndex + 3];
			Vector2[] uvs3 = m_cachedMeshInfoVertexData[materialReferenceIndex].uvs2;
			Vector2[] uvs4 = ((TMP_Text)m_TextMeshPro).textInfo.meshInfo[materialReferenceIndex].uvs2;
			uvs4[vertexIndex] = uvs3[vertexIndex];
			uvs4[vertexIndex + 1] = uvs3[vertexIndex + 1];
			uvs4[vertexIndex + 2] = uvs3[vertexIndex + 2];
			uvs4[vertexIndex + 3] = uvs3[vertexIndex + 3];
			int num = (vertices.Length / 4 - 1) * 4;
			vertices2[num] = vertices[num];
			vertices2[num + 1] = vertices[num + 1];
			vertices2[num + 2] = vertices[num + 2];
			vertices2[num + 3] = vertices[num + 3];
			colors2 = m_cachedMeshInfoVertexData[materialReferenceIndex].colors32;
			Color32[] colors3 = ((TMP_Text)m_TextMeshPro).textInfo.meshInfo[materialReferenceIndex].colors32;
			colors3[num] = colors2[num];
			colors3[num + 1] = colors2[num + 1];
			colors3[num + 2] = colors2[num + 2];
			colors3[num + 3] = colors2[num + 3];
			uvs = m_cachedMeshInfoVertexData[materialReferenceIndex].uvs0;
			Vector4[] uvs5 = ((TMP_Text)m_TextMeshPro).textInfo.meshInfo[materialReferenceIndex].uvs0;
			uvs5[num] = uvs[num];
			uvs5[num + 1] = uvs[num + 1];
			uvs5[num + 2] = uvs[num + 2];
			uvs5[num + 3] = uvs[num + 3];
			uvs3 = m_cachedMeshInfoVertexData[materialReferenceIndex].uvs2;
			Vector2[] uvs6 = ((TMP_Text)m_TextMeshPro).textInfo.meshInfo[materialReferenceIndex].uvs2;
			uvs6[num] = uvs3[num];
			uvs6[num + 1] = uvs3[num + 1];
			uvs6[num + 2] = uvs3[num + 2];
			uvs6[num + 3] = uvs3[num + 3];
			((TMP_Text)m_TextMeshPro).UpdateVertexData((TMP_VertexDataUpdateFlags)255);
		}
	}
}
