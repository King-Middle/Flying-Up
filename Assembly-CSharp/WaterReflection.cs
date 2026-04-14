using UnityEngine;

public class WaterReflection : MonoBehaviour
{
	private Camera mainCamera;

	private Camera reflectionCamera;

	[Tooltip("The plane where the camera will be reflected, the water plane or any object with the same position and rotation")]
	public Transform reflectionPlane;

	[Tooltip("The texture used by the Water shader to display the reflection")]
	public RenderTexture outputTexture;

	public bool copyCameraParamerers;

	public float verticalOffset;

	private bool isReady;

	private Transform mainCamTransform;

	private Transform reflectionCamTransform;

	public void Awake()
	{
		mainCamera = Camera.main;
		reflectionCamera = ((Component)this).GetComponent<Camera>();
		Validate();
	}

	private void Update()
	{
		if (isReady)
		{
			RenderReflection();
		}
	}

	private void RenderReflection()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		Vector3 forward = mainCamTransform.forward;
		Vector3 up = mainCamTransform.up;
		Vector3 position = mainCamTransform.position;
		position.y += verticalOffset;
		Vector3 val = reflectionPlane.InverseTransformDirection(forward);
		Vector3 val2 = reflectionPlane.InverseTransformDirection(up);
		Vector3 val3 = reflectionPlane.InverseTransformPoint(position);
		val.y *= -1f;
		val2.y *= -1f;
		val3.y *= -1f;
		forward = reflectionPlane.TransformDirection(val);
		up = reflectionPlane.TransformDirection(val2);
		position = reflectionPlane.TransformPoint(val3);
		reflectionCamTransform.position = position;
		reflectionCamTransform.LookAt(position + forward, up);
	}

	private void Validate()
	{
		if ((Object)(object)mainCamera != (Object)null)
		{
			mainCamTransform = ((Component)mainCamera).transform;
			isReady = true;
		}
		else
		{
			isReady = false;
		}
		if ((Object)(object)reflectionCamera != (Object)null)
		{
			reflectionCamTransform = ((Component)reflectionCamera).transform;
			isReady = true;
		}
		else
		{
			isReady = false;
		}
		if (isReady && copyCameraParamerers)
		{
			copyCameraParamerers = !copyCameraParamerers;
			reflectionCamera.CopyFrom(mainCamera);
			reflectionCamera.targetTexture = outputTexture;
		}
	}
}
