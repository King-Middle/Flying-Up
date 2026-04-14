using System.Collections;
using UnityEngine;

public class BirdController : MonoBehaviour
{
	public float MovementSpeed;

	private Animator animator;

	private Rigidbody rb;

	private float moveZ;

	private float moveX;

	private bool IsGrounded = true;

	private bool IsFlying;

	private bool HeyYouUsedYourChance;

	public float StaminaValue = 12f;

	private bool StaminaIsOk;

	private Vector3 FrontCheck;

	private Vector3 BackCheck;

	private Vector3 LeftCheck;

	private Vector3 RightCheck;

	public float MouseSensitivity = 2f;

	public Transform CameraTransform;

	private float rotationY;

	public Transform BirdBody;

	public Transform NormalCamera;

	public float distance = 4f;

	public float minDistance = 4f;

	public float maxDistance = 10f;

	public float distanceFactor = 30f;

	private float DashDuration = 0.3f;

	public float DashForce;

	private Vector3 RightWay;

	private bool IsDashing;

	public GameMenu gameMenu;

	private bool AllowToDash = true;

	public AudioSource audioSource;

	public AudioSource audioSource2;

	public float maxFallSpeed = 50f;

	public Transform Root;

	public Material GoldenMaterial;

	public static bool MaterialIsGolden;

	public GameObject targetObject;

	private float Deger;

	private float DegerIcinDeger;

	private bool InfiniteStaminaForTesting;

	private bool ForOnceSpeedOnAir;

	private float SpeedOnAirX;

	private float SpeedOnAirY;

	private bool OkToMove;

	private void Start()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		animator = ((Component)this).GetComponent<Animator>();
		rb = ((Component)this).GetComponent<Rigidbody>();
		Physics.gravity = new Vector3(0f, -12f, 0f);
		Cursor.lockState = (CursorLockMode)1;
		HeyYouUsedYourChance = true;
		((MonoBehaviour)this).StartCoroutine(ChangeMute());
		rb.collisionDetectionMode = (CollisionDetectionMode)1;
	}

	private void Update()
	{
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_0384: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_035e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0536: Unknown result type (might be due to invalid IL or missing references)
		//IL_0575: Unknown result type (might be due to invalid IL or missing references)
		//IL_0580: Unknown result type (might be due to invalid IL or missing references)
		//IL_0585: Unknown result type (might be due to invalid IL or missing references)
		//IL_058a: Unknown result type (might be due to invalid IL or missing references)
		//IL_058d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0592: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0605: Unknown result type (might be due to invalid IL or missing references)
		//IL_068e: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_071b: Unknown result type (might be due to invalid IL or missing references)
		//IL_072d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0742: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dd: Unknown result type (might be due to invalid IL or missing references)
		if ((!Input.GetKeyDown((KeyCode)116) || InfiniteStaminaForTesting) && Input.GetKeyDown((KeyCode)116) && InfiniteStaminaForTesting)
		{
			InfiniteStaminaForTesting = false;
		}
		if (OkToMove && !IsGrounded && !IsFlying)
		{
			_ = IsDashing;
		}
		if (!animator.GetBool("Walking") && !IsDashing)
		{
			Deger = 0f - ((Component)this).transform.localEulerAngles.y + 90f + DegerIcinDeger;
			Root.localRotation = Quaternion.Euler(0f, 0f, Deger);
		}
		else
		{
			Root.localRotation = Quaternion.Euler(0f, 0f, 0f);
			DegerIcinDeger = Root.eulerAngles.y - BirdBody.eulerAngles.y + (((Component)this).transform.eulerAngles.y - 90f);
		}
		if (gameMenu.MenuIsOn)
		{
			Cursor.lockState = (CursorLockMode)0;
		}
		else
		{
			Cursor.lockState = (CursorLockMode)1;
		}
		float num = 0f;
		float num2 = 0f;
		if (!IsDashing)
		{
			if (Input.GetKey((KeyCode)97) && Input.GetKey((KeyCode)100))
			{
				num2 = 0f;
			}
			else if (Input.GetKey((KeyCode)97))
			{
				num2 = -1f;
			}
			else if (Input.GetKey((KeyCode)100))
			{
				num2 = 1f;
			}
			if (Input.GetKey((KeyCode)119) && Input.GetKey((KeyCode)115))
			{
				num = 0f;
			}
			else if (Input.GetKey((KeyCode)119))
			{
				num = 1f;
			}
			else if (Input.GetKey((KeyCode)115))
			{
				num = -1f;
			}
		}
		Vector3 val = ((Component)this).transform.right * num2 + ((Component)this).transform.forward * num;
		Vector3 normalized = ((Vector3)(ref val)).normalized;
		if (IsGrounded || IsFlying || IsDashing || OkToMove)
		{
			if (IsGrounded || IsFlying || IsDashing)
			{
				rb.linearVelocity = new Vector3(normalized.x * MovementSpeed, rb.linearVelocity.y, normalized.z * MovementSpeed);
			}
			else if (OkToMove && !IsGrounded && !IsFlying && !IsDashing && !HeyYouUsedYourChance)
			{
				rb.linearVelocity = new Vector3(normalized.x * 0.2f, rb.linearVelocity.y, normalized.z * 0.2f);
			}
			ForOnceSpeedOnAir = true;
		}
		else
		{
			if (ForOnceSpeedOnAir)
			{
				SpeedOnAirX = rb.linearVelocity.x;
				SpeedOnAirY = rb.linearVelocity.z;
				ForOnceSpeedOnAir = false;
			}
			if (!HeyYouUsedYourChance)
			{
				rb.linearVelocity = new Vector3(SpeedOnAirX + normalized.x * 0.5f, rb.linearVelocity.y, SpeedOnAirY + normalized.z * 0.5f);
			}
			else
			{
				rb.linearVelocity = new Vector3(normalized.x * 0.5f, rb.linearVelocity.y, normalized.z * 0.5f);
			}
		}
		if (rb.linearVelocity.x != 0f || rb.linearVelocity.z != 0f)
		{
			if (!IsGrounded || IsDashing)
			{
				audioSource2.mute = true;
			}
			else if (IsGrounded || !IsDashing)
			{
				audioSource2.mute = false;
			}
			animator.SetBool("Walking", true);
			if (num == 1f)
			{
				if (num2 == 1f)
				{
					TurnFR();
				}
				else if (num2 == -1f)
				{
					TurnFL();
				}
				else if (num2 == 0f)
				{
					TurnF();
				}
			}
			else if (num == -1f)
			{
				if (num2 == 1f)
				{
					TurnBR();
				}
				else if (num2 == -1f)
				{
					TurnBL();
				}
				else if (num2 == 0f)
				{
					TurnB();
				}
			}
			else if (num == 0f)
			{
				if (num2 == 1f)
				{
					TurnR();
				}
				else if (num2 == -1f)
				{
					TurnL();
				}
			}
		}
		else
		{
			animator.SetBool("Walking", false);
		}
		if (!gameMenu.MenuIsOn)
		{
			float num3 = Input.GetAxis("Mouse X") * MouseSensitivity;
			float num4 = Input.GetAxis("Mouse Y") * MouseSensitivity;
			((Component)this).transform.Rotate(Vector3.up * num3);
			rotationY -= num4;
			rotationY = Mathf.Clamp(rotationY, -105f, 65f);
			CameraTransform.localRotation = Quaternion.Euler(rotationY, 0f, 0f);
			float num5 = Mathf.Lerp(minDistance, maxDistance, Mathf.InverseLerp(-85f, 50f, rotationY) * distanceFactor);
			val = NormalCamera.position - CameraTransform.position;
			Vector3 normalized2 = ((Vector3)(ref val)).normalized;
			NormalCamera.position = CameraTransform.position + normalized2 * num5;
		}
		if (Input.GetKeyDown((KeyCode)32) && IsGrounded)
		{
			rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y + 4f, rb.linearVelocity.z);
			animator.SetTrigger("Jump");
		}
		if (Input.GetKeyDown((KeyCode)32) && !IsGrounded && !IsFlying && !HeyYouUsedYourChance && StaminaIsOk)
		{
			Fly();
		}
		else if (IsGrounded && IsFlying)
		{
			DontFly();
		}
		if (Input.GetKeyDown((KeyCode)32))
		{
			_ = IsFlying;
		}
		if (IsFlying)
		{
			float num6 = 0f;
			if (rb.linearVelocity.y <= 0f)
			{
				MovementSpeed = 5.5f;
			}
			else
			{
				MovementSpeed = 4f;
			}
			if (Input.GetKey((KeyCode)32))
			{
				num6 = ((rb.linearVelocity.x != 0f || rb.linearVelocity.z != 0f) ? 2.25f : 2.9f);
			}
			else if (Input.GetKey((KeyCode)304))
			{
				num6 = -3f;
			}
			Vector3 linearVelocity = default(Vector3);
			((Vector3)(ref linearVelocity))._002Ector(rb.linearVelocity.x, num6, rb.linearVelocity.z);
			rb.linearVelocity = linearVelocity;
		}
		if (IsGrounded)
		{
			HeyYouUsedYourChance = false;
			if (Input.GetKeyDown((KeyCode)114) && AllowToDash)
			{
				DashRoll();
			}
		}
		if (StaminaValue > 0f)
		{
			StaminaIsOk = true;
		}
		else
		{
			DontFly();
		}
		if (animator.GetBool("Fly") && !InfiniteStaminaForTesting)
		{
			StaminaValue -= 3.2f * Time.deltaTime;
			StaminaValue = Mathf.Clamp(StaminaValue, 0f, 12f);
		}
		else if (IsGrounded && !IsDashing && StaminaValue < 12f)
		{
			StaminaValue += 9f * Time.deltaTime;
			StaminaValue = Mathf.Clamp(StaminaValue, 0f, 12f);
		}
		if (MaterialIsGolden)
		{
			ChangeMaterial();
		}
	}

	private void FixedUpdate()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		if (rb.linearVelocity.y < 0f - maxFallSpeed)
		{
			rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f - maxFallSpeed, rb.linearVelocity.z);
		}
	}

	private void Fly()
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		if (!animator.GetBool("Fly"))
		{
			animator.SetBool("Fly", true);
			((MonoBehaviour)this).StartCoroutine(ChangeFlying());
			Physics.gravity = new Vector3(0f, -30f, 0f);
			rb.linearVelocity = Vector3.zero;
			HeyYouUsedYourChance = true;
		}
	}

	private void DontFly()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		animator.SetBool("Fly", false);
		IsFlying = false;
		Physics.gravity = new Vector3(0f, -12f, 0f);
		MovementSpeed = 1.7f;
	}

	private IEnumerator ChangeFlying()
	{
		yield return (object)new WaitForSeconds(0.1f);
		IsFlying = true;
	}

	private void DashRoll()
	{
		animator.SetTrigger("Dash");
		((MonoBehaviour)this).StartCoroutine(DashController());
		((MonoBehaviour)this).StartCoroutine(DashWithTime());
	}

	private void TurnR()
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		BirdBody.localRotation = Quaternion.Euler(-90f, 90f, BirdBody.localRotation.z);
	}

	private void TurnL()
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		BirdBody.localRotation = Quaternion.Euler(-90f, 270f, BirdBody.localRotation.z);
	}

	private void TurnF()
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		BirdBody.localRotation = Quaternion.Euler(-90f, 0f, BirdBody.localRotation.z);
	}

	private void TurnB()
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		BirdBody.localRotation = Quaternion.Euler(-90f, 180f, BirdBody.localRotation.z);
	}

	private void TurnFR()
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		BirdBody.localRotation = Quaternion.Euler(-90f, 45f, BirdBody.localRotation.z);
	}

	private void TurnFL()
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		BirdBody.localRotation = Quaternion.Euler(-90f, 315f, BirdBody.localRotation.z);
	}

	private void TurnBR()
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		BirdBody.localRotation = Quaternion.Euler(-90f, 135f, BirdBody.localRotation.z);
	}

	private void TurnBL()
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		BirdBody.localRotation = Quaternion.Euler(-90f, 225f, BirdBody.localRotation.z);
	}

	private IEnumerator DashWithTime()
	{
		rb.useGravity = false;
		IsDashing = true;
		float ElapsedTime = 0f;
		while (ElapsedTime < DashDuration)
		{
			ElapsedTime += Time.deltaTime;
			float num = ElapsedTime / DashDuration;
			float num2 = Mathf.SmoothStep(0f, 1f, num);
			RightWay = Quaternion.Euler(0f, BirdBody.eulerAngles.y, 0f) * Vector3.forward;
			rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, RightWay * DashForce, num2);
			yield return null;
		}
		rb.linearVelocity = RightWay * DashForce * 0.1f;
		rb.useGravity = true;
		IsDashing = false;
	}

	private IEnumerator DashController()
	{
		AllowToDash = false;
		yield return (object)new WaitForSeconds(0.5f);
		AllowToDash = true;
	}

	private IEnumerator ChangeMute()
	{
		yield return (object)new WaitForSeconds(0.3f);
		audioSource.mute = !audioSource.mute;
		audioSource2.mute = !audioSource2.mute;
	}

	private void OnTriggerStay()
	{
		if (!IsGrounded)
		{
			IsGrounded = true;
		}
	}

	private void OnTriggerExit()
	{
		if (IsGrounded)
		{
			IsGrounded = false;
		}
	}

	public void Win()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		((Component)this).transform.position = new Vector3(-949.46f, 794.9f, 172.65f);
		((Component)this).transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
		animator.SetBool("Sit", true);
	}

	private void ChangeMaterial()
	{
		targetObject.GetComponent<Renderer>().material = GoldenMaterial;
	}

	private void OnCollisionStay()
	{
		OkToMove = true;
	}

	private void OnCollisionExit()
	{
		OkToMove = false;
	}
}
