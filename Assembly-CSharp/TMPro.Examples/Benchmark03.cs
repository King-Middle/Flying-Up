using UnityEngine;
using UnityEngine.TextCore.LowLevel;
using UnityEngine.UI;

namespace TMPro.Examples;

public class Benchmark03 : MonoBehaviour
{
	public enum BenchmarkType
	{
		TMP_SDF_MOBILE,
		TMP_SDF__MOBILE_SSD,
		TMP_SDF,
		TMP_BITMAP_MOBILE,
		TEXTMESH_BITMAP
	}

	public int NumberOfSamples = 100;

	public BenchmarkType Benchmark;

	public Font SourceFont;

	private void Awake()
	{
	}

	private void Start()
	{
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		TMP_FontAsset val = null;
		switch (Benchmark)
		{
		case BenchmarkType.TMP_SDF_MOBILE:
			val = TMP_FontAsset.CreateFontAsset(SourceFont, 90, 9, (GlyphRenderMode)4165, 256, 256, (AtlasPopulationMode)1, true);
			break;
		case BenchmarkType.TMP_SDF__MOBILE_SSD:
			val = TMP_FontAsset.CreateFontAsset(SourceFont, 90, 9, (GlyphRenderMode)4165, 256, 256, (AtlasPopulationMode)1, true);
			((TMP_Asset)val).material.shader = Shader.Find("TextMeshPro/Mobile/Distance Field SSD");
			break;
		case BenchmarkType.TMP_SDF:
			val = TMP_FontAsset.CreateFontAsset(SourceFont, 90, 9, (GlyphRenderMode)4165, 256, 256, (AtlasPopulationMode)1, true);
			((TMP_Asset)val).material.shader = Shader.Find("TextMeshPro/Distance Field");
			break;
		case BenchmarkType.TMP_BITMAP_MOBILE:
			val = TMP_FontAsset.CreateFontAsset(SourceFont, 90, 9, (GlyphRenderMode)4117, 256, 256, (AtlasPopulationMode)1, true);
			break;
		}
		for (int i = 0; i < NumberOfSamples; i++)
		{
			switch (Benchmark)
			{
			case BenchmarkType.TMP_SDF_MOBILE:
			case BenchmarkType.TMP_SDF__MOBILE_SSD:
			case BenchmarkType.TMP_SDF:
			case BenchmarkType.TMP_BITMAP_MOBILE:
			{
				GameObject val3 = new GameObject();
				val3.transform.position = new Vector3(0f, 1.2f, 0f);
				TextMeshPro val4 = val3.AddComponent<TextMeshPro>();
				((TMP_Text)val4).font = val;
				((TMP_Text)val4).fontSize = 128f;
				((TMP_Text)val4).text = "@";
				((TMP_Text)val4).alignment = (TextAlignmentOptions)514;
				((Graphic)val4).color = Color32.op_Implicit(new Color32(byte.MaxValue, byte.MaxValue, (byte)0, byte.MaxValue));
				if (Benchmark == BenchmarkType.TMP_BITMAP_MOBILE)
				{
					((TMP_Text)val4).fontSize = 132f;
				}
				break;
			}
			case BenchmarkType.TEXTMESH_BITMAP:
			{
				GameObject val2 = new GameObject();
				val2.transform.position = new Vector3(0f, 1.2f, 0f);
				TextMesh obj = val2.AddComponent<TextMesh>();
				((Component)obj).GetComponent<Renderer>().sharedMaterial = SourceFont.material;
				obj.font = SourceFont;
				obj.anchor = (TextAnchor)4;
				obj.fontSize = 130;
				obj.color = Color32.op_Implicit(new Color32(byte.MaxValue, byte.MaxValue, (byte)0, byte.MaxValue));
				obj.text = "@";
				break;
			}
			}
		}
	}
}
