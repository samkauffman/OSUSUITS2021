using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AirlockTutorialController : MonoBehaviour
{
	public Animator frontDoorAnimator;
	public Animator backDoorAnimator;


	public float pressureTime;
	public TMP_Text tutorialText;
	public int currentInstruction;
	private int startingInstruction;
	private bool isInstructionReady = true;
	public ProgressBar pressureBar;

	public GameObject tutorialButton;
	private AudioSource audioSource;
	public AudioClip[] instructionSounds;
    private void Start()
    {
		startingInstruction = currentInstruction;
		audioSource = GetComponent<AudioSource>();
		UpdateText();
    }

	private void UpdateText()
	{
		switch (currentInstruction)
		{
			case 0:
				tutorialText.text = "Airlock Tutorial";
				break;
			case 1:
				tutorialText.text = "Open Inner Door";
				break;
			case 2:
				tutorialText.text = "Close Inner Door";
				break;
			case 3:
				tutorialText.text = "Depressurize Chamber";

				break;
			case 4:
				tutorialText.text = "Open Outer Door";
				break;
			case 5:
				tutorialText.text = "Close Outer Door";
				break;

		}
	}
	public void OpenFrontDoor()
	{
		frontDoorAnimator.Play("Open Front Door");
		audioSource.clip = instructionSounds[0];
		audioSource.Play();
	}

	public void CloseFrontDoor()
	{
		frontDoorAnimator.Play("Close Front Door");
		audioSource.clip = instructionSounds[1];
		audioSource.Play();
	}

	public void OpenBackDoor()
	{
		backDoorAnimator.Play("Open Back Door");
		audioSource.clip = instructionSounds[2];
		audioSource.Play();
	}


	public void CloseBackDoor()
	{
		backDoorAnimator.Play("Close Back Door");
		audioSource.clip = instructionSounds[1];
		audioSource.Play();
	}

	public void NextInstruction()
	{
		if (isInstructionReady)
		{
			switch (currentInstruction)
			{
				case 0:
					tutorialText.text = "Open Inner Door";
					currentInstruction++;
					break;
				case 1:
					OpenFrontDoor();
					tutorialText.text = "Close Inner Door";
					currentInstruction++;
					break;
				case 2:
					CloseFrontDoor();
					tutorialText.text = "Depressurize Chamber";
					currentInstruction++;
					break;
				case 3:
					isInstructionReady = false;
					tutorialButton.SetActive(false);
					pressureBar.gameObject.SetActive(true);
					StartCoroutine(DepressurizeChamber());
					currentInstruction++;
					tutorialText.text = "Open Outer Door";
					break;
				case 4:
					OpenBackDoor();
					tutorialText.text = "Close Outer Door";
					currentInstruction++;
					break;
				case 5:
					CloseBackDoor();
					tutorialText.text = "Airlock Tutorial";
					currentInstruction = 0;
					break;

			}
		}
			
	}

	public void InstructionReady()
	{
		isInstructionReady = true;
	}

	private IEnumerator DepressurizeChamber()
	{
		audioSource.clip = instructionSounds[3];
		audioSource.Play();
		float startTime = Time.time;
		while (Time.time - startTime < pressureTime)
		{
			pressureBar.percentage = 1 - ((Time.time - startTime) / pressureTime);

			yield return new WaitForEndOfFrame();
		}
		audioSource.clip = instructionSounds[4];
		audioSource.Play();
		isInstructionReady = true;
		tutorialButton.SetActive(true);
		pressureBar.gameObject.SetActive(false);
	}

	public void ResetToDefault()
	{
		currentInstruction = startingInstruction;
		frontDoorAnimator.Play("Front Door Reset");
		//backDoorAnimator.Play("Back Door Reset");
		tutorialButton.SetActive(true);
		pressureBar.gameObject.SetActive(false);
		isInstructionReady = true;
		UpdateText();
		StopCoroutine(DepressurizeChamber());
	}
}
