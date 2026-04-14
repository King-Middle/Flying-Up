using UnityEngine;

namespace TMPro.Examples;

public class CameraController : MonoBehaviour
{
	public enum CameraModes
	{
		Follow,
		Isometric,
		Free
	}

	private Transform cameraTransform;

	private Transform dummyTarget;

	public Transform CameraTarget;

	public float FollowDistance = 30f;

	public float MaxFollowDistance = 100f;

	public float MinFollowDistance = 2f;

	public float ElevationAngle = 30f;

	public float MaxElevationAngle = 85f;

	public float MinElevationAngle;

	public float OrbitalAngle;

	public CameraModes CameraMode;

	public bool MovementSmoothing = true;

	public bool RotationSmoothing;

	private bool previousSmoothing;

	public float MovementSmoothingValue = 25f;

	public float RotationSmoothingValue = 5f;

	public float MoveSensitivity = 2f;

	private Vector3 currentVelocity = Vector3.zero;

	private Vector3 desiredPosition;

	private float mouseX;

	private float mouseY;

	private Vector3 moveVector;

	private float mouseWheel;

	private const string event_SmoothingValue = "Slider - Smoothing Value";

	private const string event_FollowDistance = "Slider - Camera Zoom";

	private void Awake()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Invalid comparison between Unknown and I4
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		if (QualitySettings.vSyncCount > 0)
		{
			Application.targetFrameRate = 60;
		}
		else
		{
			Application.targetFrameRate = -1;
		}
		if ((int)Application.platform == 8 || (int)Application.platform == 11)
		{
			Input.simulateMouseWithTouches = false;
		}
		cameraTransform = ((Component)this).transform;
		previousSmoothing = MovementSmoothing;
	}

	private void Start()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)CameraTarget == (Object)null)
		{
			dummyTarget = new GameObject("Camera Target").transform;
			CameraTarget = dummyTarget;
		}
	}

	private void LateUpdate()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		GetPlayerInput();
		if ((Object)(object)CameraTarget != (Object)null)
		{
			if (CameraMode == CameraModes.Isometric)
			{
				desiredPosition = CameraTarget.position + Quaternion.Euler(ElevationAngle, OrbitalAngle, 0f) * new Vector3(0f, 0f, 0f - FollowDistance);
			}
			else if (CameraMode == CameraModes.Follow)
			{
				desiredPosition = CameraTarget.position + CameraTarget.TransformDirection(Quaternion.Euler(ElevationAngle, OrbitalAngle, 0f) * new Vector3(0f, 0f, 0f - FollowDistance));
			}
			if (MovementSmoothing)
			{
				cameraTransform.position = Vector3.SmoothDamp(cameraTransform.position, desiredPosition, ref currentVelocity, MovementSmoothingValue * Time.fixedDeltaTime);
			}
			else
			{
				cameraTransform.position = desiredPosition;
			}
			if (RotationSmoothing)
			{
				cameraTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, Quaternion.LookRotation(CameraTarget.position - cameraTransform.position), RotationSmoothingValue * Time.deltaTime);
			}
			else
			{
				cameraTransform.LookAt(CameraTarget);
			}
		}
	}

	private void GetPlayerInput()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0419: Unknown result type (might be due to invalid IL or missing references)
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_042a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0431: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Unknown result type (might be due to invalid IL or missing references)
		//IL_043d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0444: Unknown result type (might be due to invalid IL or missing references)
		//IL_0449: Unknown result type (might be due to invalid IL or missing references)
		//IL_044e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0450: Unknown result type (might be due to invalid IL or missing references)
		//IL_0452: Unknown result type (might be due to invalid IL or missing references)
		//IL_0457: Unknown result type (might be due to invalid IL or missing references)
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		//IL_0469: Unknown result type (might be due to invalid IL or missing references)
		//IL_046e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0473: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Invalid comparison between Unknown and I4
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_0375: Unknown result type (might be due to invalid IL or missing references)
		//IL_038b: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		moveVector = Vector3.zero;
		mouseWheel = Input.GetAxis("Mouse ScrollWheel");
		float num = Input.touchCount;
		if (Input.GetKey((KeyCode)304) || Input.GetKey((KeyCode)303) || num > 0f)
		{
			mouseWheel *= 10f;
			if (Input.GetKeyDown((KeyCode)105))
			{
				CameraMode = CameraModes.Isometric;
			}
			if (Input.GetKeyDown((KeyCode)102))
			{
				CameraMode = CameraModes.Follow;
			}
			if (Input.GetKeyDown((KeyCode)115))
			{
				MovementSmoothing = !MovementSmoothing;
			}
			if (Input.GetMouseButton(1))
			{
				mouseY = Input.GetAxis("Mouse Y");
				mouseX = Input.GetAxis("Mouse X");
				if (mouseY > 0.01f || mouseY < -0.01f)
				{
					ElevationAngle -= mouseY * MoveSensitivity;
					ElevationAngle = Mathf.Clamp(ElevationAngle, MinElevationAngle, MaxElevationAngle);
				}
				if (mouseX > 0.01f || mouseX < -0.01f)
				{
					OrbitalAngle += mouseX * MoveSensitivity;
					if (OrbitalAngle > 360f)
					{
						OrbitalAngle -= 360f;
					}
					if (OrbitalAngle < 0f)
					{
						OrbitalAngle += 360f;
					}
				}
			}
			if (num == 1f)
			{
				Touch touch = Input.GetTouch(0);
				if ((int)((Touch)(ref touch)).phase == 1)
				{
					touch = Input.GetTouch(0);
					Vector2 deltaPosition = ((Touch)(ref touch)).deltaPosition;
					if (deltaPosition.y > 0.01f || deltaPosition.y < -0.01f)
					{
						ElevationAngle -= deltaPosition.y * 0.1f;
						ElevationAngle = Mathf.Clamp(ElevationAngle, MinElevationAngle, MaxElevationAngle);
					}
					if (deltaPosition.x > 0.01f || deltaPosition.x < -0.01f)
					{
						OrbitalAngle += deltaPosition.x * 0.1f;
						if (OrbitalAngle > 360f)
						{
							OrbitalAngle -= 360f;
						}
						if (OrbitalAngle < 0f)
						{
							OrbitalAngle += 360f;
						}
					}
				}
			}
			RaycastHit val = default(RaycastHit);
			if (Input.GetMouseButton(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), ref val, 300f, 23552))
			{
				if ((Object)(object)((RaycastHit)(ref val)).transform == (Object)(object)CameraTarget)
				{
					OrbitalAngle = 0f;
				}
				else
				{
					CameraTarget = ((RaycastHit)(ref val)).transform;
					OrbitalAngle = 0f;
					MovementSmoothing = previousSmoothing;
				}
			}
			if (Input.GetMouseButton(2))
			{
				if ((Object)(object)dummyTarget == (Object)null)
				{
					dummyTarget = new GameObject("Camera Target").transform;
					dummyTarget.position = CameraTarget.position;
					dummyTarget.rotation = CameraTarget.rotation;
					CameraTarget = dummyTarget;
					previousSmoothing = MovementSmoothing;
					MovementSmoothing = false;
				}
				else if ((Object)(object)dummyTarget != (Object)(object)CameraTarget)
				{
					dummyTarget.position = CameraTarget.position;
					dummyTarget.rotation = CameraTarget.rotation;
					CameraTarget = dummyTarget;
					previousSmoothing = MovementSmoothing;
					MovementSmoothing = false;
				}
				mouseY = Input.GetAxis("Mouse Y");
				mouseX = Input.GetAxis("Mouse X");
				moveVector = cameraTransform.TransformDirection(mouseX, mouseY, 0f);
				dummyTarget.Translate(-moveVector, (Space)0);
			}
		}
		if (num == 2f)
		{
			Touch touch2 = Input.GetTouch(0);
			Touch touch3 = Input.GetTouch(1);
			Vector2 val2 = ((Touch)(ref touch2)).position - ((Touch)(ref touch2)).deltaPosition;
			Vector2 val3 = ((Touch)(ref touch3)).position - ((Touch)(ref touch3)).deltaPosition;
			Vector2 val4 = val2 - val3;
			float magnitude = ((Vector2)(ref val4)).magnitude;
			val4 = ((Touch)(ref touch2)).position - ((Touch)(ref touch3)).position;
			float magnitude2 = ((Vector2)(ref val4)).magnitude;
			float num2 = magnitude - magnitude2;
			if (num2 > 0.01f || num2 < -0.01f)
			{
				FollowDistance += num2 * 0.25f;
				FollowDistance = Mathf.Clamp(FollowDistance, MinFollowDistance, MaxFollowDistance);
			}
		}
		if (mouseWheel < -0.01f || mouseWheel > 0.01f)
		{
			FollowDistance -= mouseWheel * 5f;
			FollowDistance = Mathf.Clamp(FollowDistance, MinFollowDistance, MaxFollowDistance);
		}
	}
}
