using UnityEngine;

public class BlurControl : MonoBehaviour
{
	private float value;

	private void Start()
	{
		value = 0f;
		((Component)((Component)this).transform).GetComponent<Renderer>().material.SetFloat("_blurSizeXY", value);
	}

	private void Update()
	{
		if (Input.GetButton("Up"))
		{
			value += Time.deltaTime;
			if (value > 20f)
			{
				value = 20f;
			}
			((Component)((Component)this).transform).GetComponent<Renderer>().material.SetFloat("_blurSizeXY", value);
		}
		else if (Input.GetButton("Down"))
		{
			value = (value - Time.deltaTime) % 20f;
			if (value < 0f)
			{
				value = 0f;
			}
			((Component)((Component)this).transform).GetComponent<Renderer>().material.SetFloat("_blurSizeXY", value);
		}
	}

	private void OnGUI()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		GUI.TextArea(new Rect(10f, 10f, 200f, 50f), "Press the 'Up' and 'Down' arrows \nto interact with the blur plane\nCurrent value: " + value);
	}
}
