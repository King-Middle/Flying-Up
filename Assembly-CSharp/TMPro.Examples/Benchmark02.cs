using UnityEngine;
using UnityEngine.UI;

namespace TMPro.Examples;

public class Benchmark02 : MonoBehaviour
{
	public int SpawnType;

	public int NumberOfNPC = 12;

	public bool IsTextObjectScaleStatic;

	private TextMeshProFloatingText floatingText_Script;

	private void Start()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < NumberOfNPC; i++)
		{
			if (SpawnType == 0)
			{
				GameObject val = new GameObject();
				val.transform.position = new Vector3(Random.Range(-95f, 95f), 0.25f, Random.Range(-95f, 95f));
				TextMeshPro obj = val.AddComponent<TextMeshPro>();
				((TMP_Text)obj).autoSizeTextContainer = true;
				((TMP_Text)obj).rectTransform.pivot = new Vector2(0.5f, 0f);
				((TMP_Text)obj).alignment = (TextAlignmentOptions)1026;
				((TMP_Text)obj).fontSize = 96f;
				((TMP_Text)obj).fontFeatures.Clear();
				((Graphic)obj).color = Color32.op_Implicit(new Color32(byte.MaxValue, byte.MaxValue, (byte)0, byte.MaxValue));
				((TMP_Text)obj).text = "!";
				((TMP_Text)obj).isTextObjectScaleStatic = IsTextObjectScaleStatic;
				floatingText_Script = val.AddComponent<TextMeshProFloatingText>();
				floatingText_Script.SpawnType = 0;
				floatingText_Script.IsTextObjectScaleStatic = IsTextObjectScaleStatic;
			}
			else if (SpawnType == 1)
			{
				GameObject val2 = new GameObject();
				val2.transform.position = new Vector3(Random.Range(-95f, 95f), 0.25f, Random.Range(-95f, 95f));
				TextMesh val3 = val2.AddComponent<TextMesh>();
				val3.font = Resources.Load<Font>("Fonts/ARIAL");
				((Component)val3).GetComponent<Renderer>().sharedMaterial = val3.font.material;
				val3.anchor = (TextAnchor)7;
				val3.fontSize = 96;
				val3.color = Color32.op_Implicit(new Color32(byte.MaxValue, byte.MaxValue, (byte)0, byte.MaxValue));
				val3.text = "!";
				floatingText_Script = val2.AddComponent<TextMeshProFloatingText>();
				floatingText_Script.SpawnType = 1;
			}
			else if (SpawnType == 2)
			{
				GameObject val4 = new GameObject();
				val4.AddComponent<Canvas>().worldCamera = Camera.main;
				val4.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
				val4.transform.position = new Vector3(Random.Range(-95f, 95f), 5f, Random.Range(-95f, 95f));
				TextMeshProUGUI obj2 = new GameObject().AddComponent<TextMeshProUGUI>();
				((Transform)((TMP_Text)obj2).rectTransform).SetParent(val4.transform, false);
				((Graphic)obj2).color = Color32.op_Implicit(new Color32(byte.MaxValue, byte.MaxValue, (byte)0, byte.MaxValue));
				((TMP_Text)obj2).alignment = (TextAlignmentOptions)1026;
				((TMP_Text)obj2).fontSize = 96f;
				((TMP_Text)obj2).text = "!";
				floatingText_Script = val4.AddComponent<TextMeshProFloatingText>();
				floatingText_Script.SpawnType = 0;
			}
		}
	}
}
