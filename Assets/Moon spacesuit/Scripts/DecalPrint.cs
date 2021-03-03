using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonSpacesuit {
	
	public class DecalPrint : MonoBehaviour {

		public virtual void Stick (RaycastHit hit, GameObject heel, GameObject toe) {
			Debug.Log("DecalPrint hello");
		}
	}

}
