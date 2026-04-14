using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Demo : MonoBehaviour
{
	private GameObject[] animals;

	private int animalIndex;

	private List<string> animationList = new List<string>
	{
		"Attack", "Bounce", "Clicked", "Death", "Eat", "Fear", "Fly", "Hit", "Idle_A", "Idle_B",
		"Idle_C", "Jump", "Roll", "Run", "Sit", "Spin/Splash", "Swim", "Walk"
	};

	private List<string> shapekeyList = new List<string>
	{
		"Eyes_Annoyed", "Eyes_Blink", "Eyes_Cry", "Eyes_Dead", "Eyes_Excited", "Eyes_Happy", "Eyes_LookDown", "Eyes_LookIn", "Eyes_LookOut", "Eyes_LookUp",
		"Eyes_Rabid", "Eyes_Sad", "Eyes_Shrink", "Eyes_Sleep", "Eyes_Spin", "Eyes_Squint", "Eyes_Trauma", "Sweat_L", "Sweat_R", "Teardrop_L",
		"Teardrop_R"
	};

	[Space(10f)]
	private Transform animal_parent;

	private Dropdown dropdownAnimal;

	private Dropdown dropdownAnimation;

	private Dropdown dropdownShapekey;

	private void Start()
	{
		animal_parent = GameObject.Find("Animals").transform;
		Transform transform = GameObject.Find("Canvas").transform;
		dropdownAnimal = ((Component)transform.Find("Animal").Find("Dropdown")).GetComponent<Dropdown>();
		dropdownAnimation = ((Component)transform.Find("Animation").Find("Dropdown")).GetComponent<Dropdown>();
		dropdownShapekey = ((Component)transform.Find("Shapekey").Find("Dropdown")).GetComponent<Dropdown>();
		int childCount = animal_parent.childCount;
		animals = (GameObject[])(object)new GameObject[childCount];
		List<string> list = new List<string>();
		for (int i = 0; i < childCount; i++)
		{
			animals[i] = ((Component)animal_parent.GetChild(i)).gameObject;
			string name = ((Object)animal_parent.GetChild(i)).name;
			list.Add(name);
			if (i == 0)
			{
				animals[i].SetActive(true);
			}
			else
			{
				animals[i].SetActive(false);
			}
		}
		dropdownAnimal.AddOptions(list);
		dropdownAnimation.AddOptions(animationList);
		dropdownShapekey.AddOptions(shapekeyList);
		dropdownShapekey.value = 1;
		ChangeShapekey();
	}

	private void Update()
	{
		if (Input.GetKeyDown("up"))
		{
			PrevAnimal();
		}
		else if (Input.GetKeyDown("down"))
		{
			NextAnimal();
		}
		else if (Input.GetKeyDown("right") && (Input.GetKey((KeyCode)306) || Input.GetKey((KeyCode)305)))
		{
			NextShapekey();
		}
		else if (Input.GetKeyDown("left") && (Input.GetKey((KeyCode)306) || Input.GetKey((KeyCode)305)))
		{
			PrevShapekey();
		}
		else if (Input.GetKeyDown("right"))
		{
			NextAnimation();
		}
		else if (Input.GetKeyDown("left"))
		{
			PrevAnimation();
		}
	}

	public void NextAnimal()
	{
		if (dropdownAnimal.value >= dropdownAnimal.options.Count - 1)
		{
			dropdownAnimal.value = 0;
		}
		else
		{
			Dropdown obj = dropdownAnimal;
			int value = obj.value;
			obj.value = value + 1;
		}
		ChangeAnimal();
	}

	public void PrevAnimal()
	{
		if (dropdownAnimal.value <= 0)
		{
			dropdownAnimal.value = dropdownAnimal.options.Count - 1;
		}
		else
		{
			Dropdown obj = dropdownAnimal;
			int value = obj.value;
			obj.value = value - 1;
		}
		ChangeAnimal();
	}

	public void ChangeAnimal()
	{
		animals[animalIndex].SetActive(false);
		animals[dropdownAnimal.value].SetActive(true);
		animalIndex = dropdownAnimal.value;
		ChangeAnimation();
		ChangeShapekey();
	}

	public void NextAnimation()
	{
		if (dropdownAnimation.value >= dropdownAnimation.options.Count - 1)
		{
			dropdownAnimation.value = 0;
		}
		else
		{
			Dropdown obj = dropdownAnimation;
			int value = obj.value;
			obj.value = value + 1;
		}
		ChangeAnimation();
	}

	public void PrevAnimation()
	{
		if (dropdownAnimation.value <= 0)
		{
			dropdownAnimation.value = dropdownAnimation.options.Count - 1;
		}
		else
		{
			Dropdown obj = dropdownAnimation;
			int value = obj.value;
			obj.value = value - 1;
		}
		ChangeAnimation();
	}

	public void ChangeAnimation()
	{
		Animator component = animals[dropdownAnimal.value].GetComponent<Animator>();
		if (!((Object)(object)component != (Object)null))
		{
			return;
		}
		int value = dropdownAnimation.value;
		if (value == 15)
		{
			if (component.HasState(0, Animator.StringToHash("Spin")))
			{
				component.Play("Spin");
			}
			else if (component.HasState(0, Animator.StringToHash("Splash")))
			{
				component.Play("Splash");
			}
		}
		else
		{
			component.Play(dropdownAnimation.options[value].text);
		}
	}

	public void NextShapekey()
	{
		if (dropdownShapekey.value >= dropdownShapekey.options.Count - 1)
		{
			dropdownShapekey.value = 0;
		}
		else
		{
			Dropdown obj = dropdownShapekey;
			int value = obj.value;
			obj.value = value + 1;
		}
		ChangeShapekey();
	}

	public void PrevShapekey()
	{
		if (dropdownShapekey.value <= 0)
		{
			dropdownShapekey.value = dropdownShapekey.options.Count - 1;
		}
		else
		{
			Dropdown obj = dropdownShapekey;
			int value = obj.value;
			obj.value = value - 1;
		}
		ChangeShapekey();
	}

	public void ChangeShapekey()
	{
		Animator component = animals[dropdownAnimal.value].GetComponent<Animator>();
		if ((Object)(object)component != (Object)null)
		{
			component.Play(dropdownShapekey.options[dropdownShapekey.value].text);
		}
	}

	public void GoToWebsite(string URL)
	{
		Application.OpenURL(URL);
	}
}
