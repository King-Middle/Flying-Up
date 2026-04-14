using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMPro.Examples;

public class VertexZoom : MonoBehaviour
{
	public float AngleMultiplier = 1f;

	public float SpeedMultiplier = 1f;

	public float CurveScale = 1f;

	private TMP_Text m_TextComponent;

	private bool hasTextChanged;

	private void Awake()
	{
		m_TextComponent = ((Component)this).GetComponent<TMP_Text>();
	}

	private void OnEnable()
	{
		TMPro_EventManager.TEXT_CHANGED_EVENT.Add((Action<Object>)ON_TEXT_CHANGED);
	}

	private void OnDisable()
	{
		TMPro_EventManager.TEXT_CHANGED_EVENT.Remove((Action<Object>)ON_TEXT_CHANGED);
	}

	private void Start()
	{
		((MonoBehaviour)this).StartCoroutine(AnimateVertexColors());
	}

	private void ON_TEXT_CHANGED(Object obj)
	{
		if (obj == (Object)(object)m_TextComponent)
		{
			hasTextChanged = true;
		}
	}

	private IEnumerator AnimateVertexColors()
	{
		m_TextComponent.ForceMeshUpdate(false, false);
		TMP_TextInfo textInfo = m_TextComponent.textInfo;
		TMP_MeshInfo[] cachedMeshInfoVertexData = textInfo.CopyMeshInfoVertexData();
		List<float> modifiedCharScale = new List<float>();
		List<int> scaleSortingOrder = new List<int>();
		hasTextChanged = true;
		while (true)
		{
			if (hasTextChanged)
			{
				cachedMeshInfoVertexData = textInfo.CopyMeshInfoVertexData();
				hasTextChanged = false;
			}
			int characterCount = textInfo.characterCount;
			if (characterCount == 0)
			{
				yield return (object)new WaitForSeconds(0.25f);
				continue;
			}
			modifiedCharScale.Clear();
			scaleSortingOrder.Clear();
			for (int i = 0; i < characterCount; i++)
			{
				if (textInfo.characterInfo[i].isVisible)
				{
					int materialReferenceIndex = textInfo.characterInfo[i].materialReferenceIndex;
					int vertexIndex = textInfo.characterInfo[i].vertexIndex;
					Vector3[] vertices = cachedMeshInfoVertexData[materialReferenceIndex].vertices;
					Vector3 val = Vector2.op_Implicit(Vector2.op_Implicit((vertices[vertexIndex] + vertices[vertexIndex + 2]) / 2f));
					Vector3[] vertices2 = textInfo.meshInfo[materialReferenceIndex].vertices;
					vertices2[vertexIndex] = vertices[vertexIndex] - val;
					vertices2[vertexIndex + 1] = vertices[vertexIndex + 1] - val;
					vertices2[vertexIndex + 2] = vertices[vertexIndex + 2] - val;
					vertices2[vertexIndex + 3] = vertices[vertexIndex + 3] - val;
					float num = Random.Range(1f, 1.5f);
					modifiedCharScale.Add(num);
					scaleSortingOrder.Add(modifiedCharScale.Count - 1);
					Matrix4x4 val2 = Matrix4x4.TRS(new Vector3(0f, 0f, 0f), Quaternion.identity, Vector3.one * num);
					vertices2[vertexIndex] = ((Matrix4x4)(ref val2)).MultiplyPoint3x4(vertices2[vertexIndex]);
					vertices2[vertexIndex + 1] = ((Matrix4x4)(ref val2)).MultiplyPoint3x4(vertices2[vertexIndex + 1]);
					vertices2[vertexIndex + 2] = ((Matrix4x4)(ref val2)).MultiplyPoint3x4(vertices2[vertexIndex + 2]);
					vertices2[vertexIndex + 3] = ((Matrix4x4)(ref val2)).MultiplyPoint3x4(vertices2[vertexIndex + 3]);
					ref Vector3 reference = ref vertices2[vertexIndex];
					reference += val;
					ref Vector3 reference2 = ref vertices2[vertexIndex + 1];
					reference2 += val;
					ref Vector3 reference3 = ref vertices2[vertexIndex + 2];
					reference3 += val;
					ref Vector3 reference4 = ref vertices2[vertexIndex + 3];
					reference4 += val;
					Vector4[] uvs = cachedMeshInfoVertexData[materialReferenceIndex].uvs0;
					Vector4[] uvs2 = textInfo.meshInfo[materialReferenceIndex].uvs0;
					uvs2[vertexIndex] = uvs[vertexIndex];
					uvs2[vertexIndex + 1] = uvs[vertexIndex + 1];
					uvs2[vertexIndex + 2] = uvs[vertexIndex + 2];
					uvs2[vertexIndex + 3] = uvs[vertexIndex + 3];
					Color32[] colors = cachedMeshInfoVertexData[materialReferenceIndex].colors32;
					Color32[] colors2 = textInfo.meshInfo[materialReferenceIndex].colors32;
					colors2[vertexIndex] = colors[vertexIndex];
					colors2[vertexIndex + 1] = colors[vertexIndex + 1];
					colors2[vertexIndex + 2] = colors[vertexIndex + 2];
					colors2[vertexIndex + 3] = colors[vertexIndex + 3];
				}
			}
			for (int j = 0; j < textInfo.meshInfo.Length; j++)
			{
				scaleSortingOrder.Sort((int a, int b) => modifiedCharScale[a].CompareTo(modifiedCharScale[b]));
				((TMP_MeshInfo)(ref textInfo.meshInfo[j])).SortGeometry((IList<int>)scaleSortingOrder);
				textInfo.meshInfo[j].mesh.vertices = textInfo.meshInfo[j].vertices;
				textInfo.meshInfo[j].mesh.SetUVs(0, textInfo.meshInfo[j].uvs0);
				textInfo.meshInfo[j].mesh.colors32 = textInfo.meshInfo[j].colors32;
				m_TextComponent.UpdateGeometry(textInfo.meshInfo[j].mesh, j);
			}
			yield return (object)new WaitForSeconds(0.1f);
		}
	}
}
