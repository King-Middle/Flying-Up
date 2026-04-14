using UnityEngine;
using UnityEngine.UI;

namespace TMPro.Examples;

public class TextMeshSpawner : MonoBehaviour
{
	public int SpawnType;

	public int NumberOfNPC = 12;

	public Font TheFont;

	private TextMeshProFloatingText floatingText_Script;

	private void Awake()
	{
	}

	private void Start()
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < NumberOfNPC; i++)
		{
			if (SpawnType == 0)
			{
				GameObject val = new GameObject();
				val.transform.position = new Vector3(Random.Range(-95f, 95f), 0.5f, Random.Range(-95f, 95f));
				TextMeshPro obj = val.AddComponent<TextMeshPro>();
				((TMP_Text)obj).fontSize = 96f;
				((TMP_Text)obj).text = "!";
				((Graphic)obj).color = Color32.op_Implicit(new Color32(byte.MaxValue, byte.MaxValue, (byte)0, byte.MaxValue));
				floatingText_Script = val.AddComponent<TextMeshProFloatingText>();
				floatingText_Script.SpawnType = 0;
			}
			else
			{
				GameObject val2 = new GameObject();
				val2.transform.position = new Vector3(Random.Range(-95f, 95f), 0.5f, Random.Range(-95f, 95f));
				TextMesh obj2 = val2.AddComponent<TextMesh>();
				((Component)obj2).GetComponent<Renderer>().sharedMaterial = TheFont.material;
				obj2.font = TheFont;
				obj2.anchor = (TextAnchor)7;
				obj2.fontSize = 96;
				obj2.color = Color32.op_Implicit(new Color32(byte.MaxValue, byte.MaxValue, (byte)0, byte.MaxValue));
				obj2.text = "!";
				floatingText_Script = val2.AddComponent<TextMeshProFloatingText>();
				floatingText_Script.SpawnType = 1;
			}
		}
	}
}
