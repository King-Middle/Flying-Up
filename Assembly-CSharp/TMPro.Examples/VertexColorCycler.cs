using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro.Examples;

public class VertexColorCycler : MonoBehaviour
{
	private TMP_Text m_TextComponent;

	private void Awake()
	{
		m_TextComponent = ((Component)this).GetComponent<TMP_Text>();
	}

	private void Start()
	{
		((MonoBehaviour)this).StartCoroutine(AnimateVertexColors());
	}

	private IEnumerator AnimateVertexColors()
	{
		m_TextComponent.ForceMeshUpdate(false, false);
		TMP_TextInfo textInfo = m_TextComponent.textInfo;
		int currentCharacter = 0;
		Color32 val = Color32.op_Implicit(((Graphic)m_TextComponent).color);
		while (true)
		{
			int characterCount = textInfo.characterCount;
			if (characterCount == 0)
			{
				yield return (object)new WaitForSeconds(0.25f);
				continue;
			}
			int materialReferenceIndex = textInfo.characterInfo[currentCharacter].materialReferenceIndex;
			Color32[] colors = textInfo.meshInfo[materialReferenceIndex].colors32;
			int vertexIndex = textInfo.characterInfo[currentCharacter].vertexIndex;
			if (textInfo.characterInfo[currentCharacter].isVisible)
			{
				((Color32)(ref val))._002Ector((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), byte.MaxValue);
				colors[vertexIndex] = val;
				colors[vertexIndex + 1] = val;
				colors[vertexIndex + 2] = val;
				colors[vertexIndex + 3] = val;
				m_TextComponent.UpdateVertexData((TMP_VertexDataUpdateFlags)16);
			}
			currentCharacter = (currentCharacter + 1) % characterCount;
			yield return (object)new WaitForSeconds(0.05f);
		}
	}
}
