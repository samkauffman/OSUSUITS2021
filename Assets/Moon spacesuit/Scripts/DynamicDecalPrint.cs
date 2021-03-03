using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonSpacesuit {
	
	public class DynamicDecalPrint : DecalPrint {

		public List<GameObject> footprints; // random use

		public override void Stick (RaycastHit hit, GameObject heel, GameObject toe) {
			if (footprints.Count > 0) {
				int i = Random.Range(0, footprints.Count);
				// 14:12 25.09.2017 Dynamic Decals feature: vector Z should stuck into the ground
				Instantiate(footprints[i], hit.point, Quaternion.LookRotation(-hit.normal, toe.transform.position - heel.transform.position));
				//Debug.Break();
			}
		}

	}

}
