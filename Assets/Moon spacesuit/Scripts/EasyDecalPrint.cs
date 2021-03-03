using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Uncomment this if you have EasyDecal asset!
//using ch.sycoforge.Decal;

namespace MoonSpacesuit {

/* Uncomment this if you have EasyDecal asset!
	public class EasyDecalPrint : DecalPrint {

		public List<EasyDecal> footprints; // random use
		
		public override void Stick (RaycastHit hit, GameObject heel, GameObject toe) {
			if (footprints.Count > 0) {
				int i = Random.Range(0, footprints.Count);
				EasyDecal decal = EasyDecal.ProjectAt(footprints[i].gameObject, hit.collider.gameObject, hit.point, hit.normal);
				decal.transform.rotation = Quaternion.LookRotation(toe.transform.position - heel.transform.position);
			}
		}

	}
*/

}