using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonSpacesuit {
	
	// 14:57 10.05.2017 ground footprint
	// object: right and left Astronauta/metarig/Bone/Foot.IK.R(L)

	public class Footprint : MonoBehaviour {

		int layerMask; // the bit mask of the Ground layer // = 1 << 15 // http://docs.unity3d.com/Manual/Layers.html
		public GameObject heel, toe; // we need heel and toe objects, because bone has a strange rotation
		public List<GameObject> footStepEffects; // walking dust effects
		Ray ray = new Ray(Vector3.zero, Vector3.down);
		RaycastHit hit;
		public string groundLayerName = "Ground";
		public float dustLifetime = 1.1f;
		
		void Start () {
			layerMask = 1 << LayerMask.NameToLayer(groundLayerName);
		}
		
		// MoonSpacesuit.Controller calls this method
		public void Print () {
			Vector3 rayPoint = (heel.transform.position + (toe.transform.position - heel.transform.position) / 2) + Vector3.up * 0.5f;
			#if UNITY_EDITOR
			Debug.DrawLine(rayPoint, rayPoint  - Vector3.up * 1, Color.red, 20, false);
			#endif
			ray.origin = rayPoint;
			if (Physics.Raycast(ray, out hit, 1, layerMask)) {
				MoonSpacesuit.DecalPrint dp = GetComponent<MoonSpacesuit.DecalPrint>();
				if (dp) dp.Stick(hit, heel, toe);
			}
			#if UNITY_EDITOR
			else print("No ground here");
			#endif
		}

		// MoonSpacesuit.Controller calls this method
		public void Dust () {
			ray.origin = toe.transform.position + Vector3.up * 0.5f;
			// if (Physics.Raycast(ray, out hit, 1.5f) && hit.transform.CompareTag("Ground")) { // зачем-то проверяется тег, не знаю
			if (Physics.Raycast(ray, out hit, 1.5f, layerMask)) {
				// try to throw the dust ahead
				Vector3 course = Vector3.Cross(Vector3.up, Vector3.Cross(toe.transform.position - heel.transform.position, Vector3.up)); // heading vector
				int var = Random.Range(0, footStepEffects.Count + 1);
				if (var < footStepEffects.Count) {
					GameObject dust = Instantiate(footStepEffects[var], toe.transform.position, Quaternion.LookRotation(course, Vector3.up)) as GameObject;
					Destroy(dust, dustLifetime);
				}
			}
		}
		
	}

}
