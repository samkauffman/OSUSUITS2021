using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationController : MonoBehaviour
{
	public GameObject hand;
	public void ShowHand()
	{
		hand.SetActive(true);
	}

	public void HideHand()
	{
		hand.SetActive(false);
	}
}
