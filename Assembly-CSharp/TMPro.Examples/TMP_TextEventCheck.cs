using UnityEngine;
using UnityEngine.Events;

namespace TMPro.Examples;

public class TMP_TextEventCheck : MonoBehaviour
{
	public TMP_TextEventHandler TextEventHandler;

	private TMP_Text m_TextComponent;

	private void OnEnable()
	{
		if ((Object)(object)TextEventHandler != (Object)null)
		{
			m_TextComponent = ((Component)TextEventHandler).GetComponent<TMP_Text>();
			((UnityEvent<char, int>)TextEventHandler.onCharacterSelection).AddListener((UnityAction<char, int>)OnCharacterSelection);
			((UnityEvent<char, int>)TextEventHandler.onSpriteSelection).AddListener((UnityAction<char, int>)OnSpriteSelection);
			((UnityEvent<string, int, int>)TextEventHandler.onWordSelection).AddListener((UnityAction<string, int, int>)OnWordSelection);
			((UnityEvent<string, int, int>)TextEventHandler.onLineSelection).AddListener((UnityAction<string, int, int>)OnLineSelection);
			((UnityEvent<string, string, int>)TextEventHandler.onLinkSelection).AddListener((UnityAction<string, string, int>)OnLinkSelection);
		}
	}

	private void OnDisable()
	{
		if ((Object)(object)TextEventHandler != (Object)null)
		{
			((UnityEvent<char, int>)TextEventHandler.onCharacterSelection).RemoveListener((UnityAction<char, int>)OnCharacterSelection);
			((UnityEvent<char, int>)TextEventHandler.onSpriteSelection).RemoveListener((UnityAction<char, int>)OnSpriteSelection);
			((UnityEvent<string, int, int>)TextEventHandler.onWordSelection).RemoveListener((UnityAction<string, int, int>)OnWordSelection);
			((UnityEvent<string, int, int>)TextEventHandler.onLineSelection).RemoveListener((UnityAction<string, int, int>)OnLineSelection);
			((UnityEvent<string, string, int>)TextEventHandler.onLinkSelection).RemoveListener((UnityAction<string, string, int>)OnLinkSelection);
		}
	}

	private void OnCharacterSelection(char c, int index)
	{
		Debug.Log((object)("Character [" + c + "] at Index: " + index + " has been selected."));
	}

	private void OnSpriteSelection(char c, int index)
	{
		Debug.Log((object)("Sprite [" + c + "] at Index: " + index + " has been selected."));
	}

	private void OnWordSelection(string word, int firstCharacterIndex, int length)
	{
		Debug.Log((object)("Word [" + word + "] with first character index of " + firstCharacterIndex + " and length of " + length + " has been selected."));
	}

	private void OnLineSelection(string lineText, int firstCharacterIndex, int length)
	{
		Debug.Log((object)("Line [" + lineText + "] with first character index of " + firstCharacterIndex + " and length of " + length + " has been selected."));
	}

	private void OnLinkSelection(string linkID, string linkText, int linkIndex)
	{
		if ((Object)(object)m_TextComponent != (Object)null)
		{
			_ = ref m_TextComponent.textInfo.linkInfo[linkIndex];
		}
		Debug.Log((object)("Link Index: " + linkIndex + " with ID [" + linkID + "] and Text \"" + linkText + "\" has been selected."));
	}
}
