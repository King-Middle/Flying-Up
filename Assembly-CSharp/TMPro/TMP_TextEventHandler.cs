using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace TMPro;

public class TMP_TextEventHandler : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[Serializable]
	public class CharacterSelectionEvent : UnityEvent<char, int>
	{
	}

	[Serializable]
	public class SpriteSelectionEvent : UnityEvent<char, int>
	{
	}

	[Serializable]
	public class WordSelectionEvent : UnityEvent<string, int, int>
	{
	}

	[Serializable]
	public class LineSelectionEvent : UnityEvent<string, int, int>
	{
	}

	[Serializable]
	public class LinkSelectionEvent : UnityEvent<string, string, int>
	{
	}

	[SerializeField]
	private CharacterSelectionEvent m_OnCharacterSelection = new CharacterSelectionEvent();

	[SerializeField]
	private SpriteSelectionEvent m_OnSpriteSelection = new SpriteSelectionEvent();

	[SerializeField]
	private WordSelectionEvent m_OnWordSelection = new WordSelectionEvent();

	[SerializeField]
	private LineSelectionEvent m_OnLineSelection = new LineSelectionEvent();

	[SerializeField]
	private LinkSelectionEvent m_OnLinkSelection = new LinkSelectionEvent();

	private TMP_Text m_TextComponent;

	private Camera m_Camera;

	private Canvas m_Canvas;

	private int m_selectedLink = -1;

	private int m_lastCharIndex = -1;

	private int m_lastWordIndex = -1;

	private int m_lastLineIndex = -1;

	public CharacterSelectionEvent onCharacterSelection
	{
		get
		{
			return m_OnCharacterSelection;
		}
		set
		{
			m_OnCharacterSelection = value;
		}
	}

	public SpriteSelectionEvent onSpriteSelection
	{
		get
		{
			return m_OnSpriteSelection;
		}
		set
		{
			m_OnSpriteSelection = value;
		}
	}

	public WordSelectionEvent onWordSelection
	{
		get
		{
			return m_OnWordSelection;
		}
		set
		{
			m_OnWordSelection = value;
		}
	}

	public LineSelectionEvent onLineSelection
	{
		get
		{
			return m_OnLineSelection;
		}
		set
		{
			m_OnLineSelection = value;
		}
	}

	public LinkSelectionEvent onLinkSelection
	{
		get
		{
			return m_OnLinkSelection;
		}
		set
		{
			m_OnLinkSelection = value;
		}
	}

	private void Awake()
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		m_TextComponent = ((Component)this).gameObject.GetComponent<TMP_Text>();
		if (((object)m_TextComponent).GetType() == typeof(TextMeshProUGUI))
		{
			m_Canvas = ((Component)this).gameObject.GetComponentInParent<Canvas>();
			if ((Object)(object)m_Canvas != (Object)null)
			{
				if ((int)m_Canvas.renderMode == 0)
				{
					m_Camera = null;
				}
				else
				{
					m_Camera = m_Canvas.worldCamera;
				}
			}
		}
		else
		{
			m_Camera = Camera.main;
		}
	}

	private void LateUpdate()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Invalid comparison between Unknown and I4
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		if (TMP_TextUtilities.IsIntersectingRectTransform(m_TextComponent.rectTransform, Input.mousePosition, m_Camera))
		{
			int num = TMP_TextUtilities.FindIntersectingCharacter(m_TextComponent, Input.mousePosition, m_Camera, true);
			if (num != -1 && num != m_lastCharIndex)
			{
				m_lastCharIndex = num;
				TMP_TextElementType elementType = m_TextComponent.textInfo.characterInfo[num].elementType;
				if ((int)elementType == 0)
				{
					SendOnCharacterSelection(m_TextComponent.textInfo.characterInfo[num].character, num);
				}
				else if ((int)elementType == 1)
				{
					SendOnSpriteSelection(m_TextComponent.textInfo.characterInfo[num].character, num);
				}
			}
			int num2 = TMP_TextUtilities.FindIntersectingWord(m_TextComponent, Input.mousePosition, m_Camera);
			if (num2 != -1 && num2 != m_lastWordIndex)
			{
				m_lastWordIndex = num2;
				TMP_WordInfo val = m_TextComponent.textInfo.wordInfo[num2];
				SendOnWordSelection(((TMP_WordInfo)(ref val)).GetWord(), val.firstCharacterIndex, val.characterCount);
			}
			int num3 = TMP_TextUtilities.FindIntersectingLine(m_TextComponent, Input.mousePosition, m_Camera);
			if (num3 != -1 && num3 != m_lastLineIndex)
			{
				m_lastLineIndex = num3;
				TMP_LineInfo val2 = m_TextComponent.textInfo.lineInfo[num3];
				char[] array = new char[val2.characterCount];
				for (int i = 0; i < val2.characterCount && i < m_TextComponent.textInfo.characterInfo.Length; i++)
				{
					array[i] = m_TextComponent.textInfo.characterInfo[i + val2.firstCharacterIndex].character;
				}
				string line = new string(array);
				SendOnLineSelection(line, val2.firstCharacterIndex, val2.characterCount);
			}
			int num4 = TMP_TextUtilities.FindIntersectingLink(m_TextComponent, Input.mousePosition, m_Camera);
			if (num4 != -1 && num4 != m_selectedLink)
			{
				m_selectedLink = num4;
				TMP_LinkInfo val3 = m_TextComponent.textInfo.linkInfo[num4];
				SendOnLinkSelection(((TMP_LinkInfo)(ref val3)).GetLinkID(), ((TMP_LinkInfo)(ref val3)).GetLinkText(), num4);
			}
		}
		else
		{
			m_selectedLink = -1;
			m_lastCharIndex = -1;
			m_lastWordIndex = -1;
			m_lastLineIndex = -1;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	private void SendOnCharacterSelection(char character, int characterIndex)
	{
		if (onCharacterSelection != null)
		{
			((UnityEvent<char, int>)onCharacterSelection).Invoke(character, characterIndex);
		}
	}

	private void SendOnSpriteSelection(char character, int characterIndex)
	{
		if (onSpriteSelection != null)
		{
			((UnityEvent<char, int>)onSpriteSelection).Invoke(character, characterIndex);
		}
	}

	private void SendOnWordSelection(string word, int charIndex, int length)
	{
		if (onWordSelection != null)
		{
			((UnityEvent<string, int, int>)onWordSelection).Invoke(word, charIndex, length);
		}
	}

	private void SendOnLineSelection(string line, int charIndex, int length)
	{
		if (onLineSelection != null)
		{
			((UnityEvent<string, int, int>)onLineSelection).Invoke(line, charIndex, length);
		}
	}

	private void SendOnLinkSelection(string linkID, string linkText, int linkIndex)
	{
		if (onLinkSelection != null)
		{
			((UnityEvent<string, string, int>)onLinkSelection).Invoke(linkID, linkText, linkIndex);
		}
	}
}
