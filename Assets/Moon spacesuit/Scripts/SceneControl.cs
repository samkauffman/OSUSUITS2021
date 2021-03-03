using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MoonSpacesuit {
	
	public class SceneControl : MonoBehaviour {

		public float gravity = 1.62f; // Lunar gravity
		public bool cursorVisible = false;
		public CursorLockMode cursorLocked = CursorLockMode.Locked;
	
		// Use this for initialization
		void Awake () {
			print("SceneControl set gravity");
			Physics.gravity = Vector3.down * gravity;
			// cursor to center
			Cursor.lockState = cursorLocked;
			Cursor.visible = cursorVisible;
		}
	}

}
