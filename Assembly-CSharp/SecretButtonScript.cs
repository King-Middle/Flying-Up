using UnityEngine;
using UnityEngine.UI;

public class SecretButtonScript : MonoBehaviour
{
	public Material YellowMaterial;

	public Material NoneMaterial;

	private Image buttonImage;

	private void Start()
	{
		buttonImage = ((Component)this).GetComponent<Image>();
		LoadMaterialGoldenStatus();
	}

	public void ChangeGoldValue()
	{
		if (!BirdController.MaterialIsGolden)
		{
			BirdController.MaterialIsGolden = true;
			ChangeUIMaterial(YellowMaterial);
		}
		else if (BirdController.MaterialIsGolden)
		{
			BirdController.MaterialIsGolden = false;
			ChangeUIMaterial(NoneMaterial);
		}
		SaveMaterialGoldenStatus();
	}

	private void ChangeUIMaterial(Material material)
	{
		if ((Object)(object)buttonImage != (Object)null)
		{
			((Graphic)buttonImage).material = material;
		}
	}

	private void SaveMaterialGoldenStatus()
	{
		PlayerPrefs.SetInt("MaterialIsGolden", BirdController.MaterialIsGolden ? 1 : 0);
		PlayerPrefs.Save();
	}

	private void LoadMaterialGoldenStatus()
	{
		if (PlayerPrefs.HasKey("MaterialIsGolden"))
		{
			BirdController.MaterialIsGolden = PlayerPrefs.GetInt("MaterialIsGolden") == 1;
			if (BirdController.MaterialIsGolden)
			{
				ChangeUIMaterial(YellowMaterial);
			}
			else
			{
				ChangeUIMaterial(NoneMaterial);
			}
		}
	}
}
