using UnityEngine;

namespace TMPro.Examples;

public class ObjectSpin : MonoBehaviour
{
	public enum MotionType
	{
		Rotation,
		SearchLight,
		Translation
	}

	public MotionType Motion;

	public Vector3 TranslationDistance = new Vector3(5f, 0f, 0f);

	public float TranslationSpeed = 1f;

	public float SpinSpeed = 5f;

	public int RotationRange = 15;

	private Transform m_transform;

	private float m_time;

	private Vector3 m_prevPOS;

	private Vector3 m_initial_Rotation;

	private Vector3 m_initial_Position;

	private Color32 m_lightColor;

	private void Awake()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		m_transform = ((Component)this).transform;
		Quaternion rotation = m_transform.rotation;
		m_initial_Rotation = ((Quaternion)(ref rotation)).eulerAngles;
		m_initial_Position = m_transform.position;
		Light component = ((Component)this).GetComponent<Light>();
		m_lightColor = Color32.op_Implicit(((Object)(object)component != (Object)null) ? component.color : Color.black);
	}

	private void Update()
	{
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		switch (Motion)
		{
		case MotionType.Rotation:
			m_transform.Rotate(0f, SpinSpeed * Time.deltaTime, 0f);
			break;
		case MotionType.SearchLight:
			m_time += SpinSpeed * Time.deltaTime;
			m_transform.rotation = Quaternion.Euler(m_initial_Rotation.x, Mathf.Sin(m_time) * (float)RotationRange + m_initial_Rotation.y, m_initial_Rotation.z);
			break;
		case MotionType.Translation:
		{
			m_time += TranslationSpeed * Time.deltaTime;
			float num = TranslationDistance.x * Mathf.Cos(m_time);
			float num2 = TranslationDistance.y * Mathf.Sin(m_time) * Mathf.Cos(m_time * 1f);
			float num3 = TranslationDistance.z * Mathf.Sin(m_time);
			m_transform.position = m_initial_Position + new Vector3(num, num3, num2);
			m_prevPOS = m_transform.position;
			break;
		}
		}
	}
}
