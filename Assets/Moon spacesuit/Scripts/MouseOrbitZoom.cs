using UnityEngine;
using System.Collections;
// http://wiki.unity3d.com/index.php/MouseOrbitZoom

namespace MoonSpacesuit {

[AddComponentMenu("Camera-Control/3dsMax Camera Style")]
    public class MouseOrbitZoom : MonoBehaviour {

        public Transform target;
        public Vector3 groundOffset;
        public float distance = 5.0f;
        public float maxDistance = 20;
        public float minDistance = .6f;
        public float switchDistance = 0.5f; // к минимальной дистанции алгоритм не даст приблизиться, поэтому переключаем чуть дальше
        public float xSpeed = 200.0f;
        public float ySpeed = 200.0f;
        public int yMinLimit = -80;
        public int yMaxLimit = 80; // см. значения в редакторе
        public int zoomRate = 40;
        public float panSpeed = 0.3f;
        public float zoomDampening = 5.0f;

        private float xDeg = 0.0f;
        private float yDeg = 0.0f;
        public float currentDistance;
        private float desiredDistance;
        //private Quaternion currentRotation;
        private Quaternion desiredRotation;
        private Quaternion rotation;
        private Vector3 position;
        //void Start() { Init(); }
        //void OnEnable() { Init(); }
		bool rotate = true;
		public KeyCode stopRotateKey = KeyCode.Period;
		RaycastHit hit;
		float undergroundRotationSpeed = 3;
		
	void UpdateRotation() {
		yDeg = transform.rotation.eulerAngles.y;
		xDeg = transform.rotation.eulerAngles.x;
		if (xDeg > 180) xDeg -= 360;
		if (yDeg > 180) yDeg -= 360;
	}
		
    public void Start() {
        //If there is no target, create a temporary target at 'distance' from the cameras current viewpoint
        if (!target) {
			GameObject go = new GameObject("Cam Target");
			go.transform.position = transform.position + (transform.forward * distance);
			target = go.transform;
		}
		distance = Vector3.Distance(transform.position, target.position);
		currentDistance = distance;
		desiredDistance = distance;
		//be sure to grab the current rotations as starting points.
		position = transform.position;
		rotation = transform.rotation;
		//currentRotation = transform.rotation;
		desiredRotation = transform.rotation;
		UpdateRotation();
    }

    /*
     * Camera logic on LateUpdate to only update after all character movement logic has been handled. 
     */
    void LateUpdate() {
		if (Input.GetKeyUp(stopRotateKey)) rotate = !rotate;
		yDeg += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
		xDeg -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f * undergroundRotationSpeed;
		////////OrbitAngle
		//Clamp the vertical axis for the orbit
		xDeg = ClampAngle(xDeg, yMinLimit, yMaxLimit);
		// set camera rotation 
		desiredRotation = Quaternion.Euler(xDeg, yDeg, 0);
		//currentRotation = transform.rotation;
		// заменяю плавный поворот на равномерный, соответствующий движению мыши
		//rotation = Quaternion.Lerp(currentRotation, desiredRotation, Time.deltaTime * zoomDampening);
		rotation = desiredRotation;
		////////Orbit Position
		// affect the desired Zoom distance if we roll the scrollwheel
		desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomRate * Mathf.Abs(desiredDistance);
		//clamp the zoom min/max
		// 13:40 25.11.2017 на базе http://wiki.unity3d.com/index.php?title=MouseOrbitImproved
		desiredDistance = Mathf.Clamp(desiredDistance, minDistance, maxDistance); // независимая от поверхности позиция.
		// надо не позволять камере опускаться под землю, всё время оставаясь на поверхности. При движении вниз, камера будет приближаться, а вверх - отдаляться вдоль поверхности, пока не удалится на заданную дистанцию.
		// Для этого надо протыкать грунт лучом на заданное расстояние и пока пересечение существует, задавать дистанцию до точки пересечения.
		if (Physics.Linecast(target.position, target.position + (position - target.position).normalized * desiredDistance, out hit, 1 << LayerMask.NameToLayer("Ground"))) {
			currentDistance = Mathf.Clamp(hit.distance, minDistance, maxDistance); // из-за рельефа нельзя придвигать к цели, надо вверх двигать.
			undergroundRotationSpeed = 0.5f; // 20:59 25.11.2017 чтоб помедленнее скользил под землёй
		}
		else {
			currentDistance = Mathf.Lerp(currentDistance, desiredDistance, Time.deltaTime * zoomDampening);           
			undergroundRotationSpeed = 1;
		}
		// For smoothing of the zoom, lerp distance
		//currentDistance = Mathf.Lerp(currentDistance, desiredDistance, Time.deltaTime * zoomDampening);           
		// calculate position based on the new currentDistance 
		if (rotate) {
			transform.rotation = rotation;
			position = target.position - (rotation * Vector3.forward * currentDistance);
		} else {
			position = target.position - (transform.rotation * Vector3.forward * currentDistance);
		}
		transform.position = position + groundOffset; // 20:59 25.11.2017 финальное смещение вверх над грунтом, чтоб не видно было подземелье
	}
			
        private static float ClampAngle(float angle, float min, float max) {
            if (angle < -360)
                angle += 360;
            if (angle > 360)
                angle -= 360;
            return Mathf.Clamp(angle, min, max);
        }
    }

}