using UnityEngine;

public class GoldenBirdConverter : MonoBehaviour
{
	public GameObject targetObject;

	public Material GoldenMaterial;

	public Material NormalMaterial;

	private Animator animator;

	private void Start()
	{
		animator = ((Component)this).GetComponent<Animator>();
		animator.SetBool("Sit", true);
	}

	private void Update()
	{
		if (!BirdController.MaterialIsGolden)
		{
			targetObject.GetComponent<Renderer>().material = NormalMaterial;
		}
		else if (BirdController.MaterialIsGolden)
		{
			targetObject.GetComponent<Renderer>().material = GoldenMaterial;
		}
	}
}
