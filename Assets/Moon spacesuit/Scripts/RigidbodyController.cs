using UnityEngine;
using System.Collections;

namespace MoonSpacesuit {

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

	public class RigidbodyController : MonoBehaviour {
		
		private Animator anim;
		public float speed = 10.0f;
		public float maxVelocityChange = 10.0f;
		public float turnSpeed = 60.0f;
		public bool canJump = true;
		public float jumpHeight = 2.0f;
		bool grounded = false;
		bool turnTrigger = false;
		float turn;
		Rigidbody rb;
		bool walking = false; // inner flag of walking
		public KeyCode keyToBunnyHop = KeyCode.B;
		public MoonSpacesuit.Footprint leftFoot, rightFoot; // foot objects with component SpacesuitFootprint.cs which makes footprints during walking and turning
		public float thrustAfterJump = 1; // empiric constant
		public float maxHitImpulse = 300;
		public float maxHitImpulse2 = 600;
		Vector3 vel; // save velocity during move
		public bool debug = false;
		bool bump = false;
		float speedup = 1; // default velocity multiplicator
		bool jumping = false;

		void Awake() {
			anim = GetComponent<Animator>();
			rb = GetComponent<Rigidbody>();
			rb.freezeRotation = true; // FPS-controller
		}

	    // Calling at the end of 90° rotation animation
		void Turn (int grad) {
			transform.Rotate(0, grad, 0);
			turn = 0;
			turnTrigger = false;
		}

		float CalculateJumpVerticalSpeed() {
			// From the jump height and gravity we deduce the upwards speed 
			// for the character to reach at the apex.
			return Mathf.Sqrt(2 * jumpHeight * Physics.gravity.magnitude);
		}

		// Jump event comes when jumping animation reaches proper frame 
		void Jump () {
			jumping = true;
			rb.velocity = new Vector3(rb.velocity.x, CalculateJumpVerticalSpeed(), rb.velocity.z);
		}

		// signal from end of start-walking clip
		void Walking () {
			if (anim.GetBool("walk")) walking = true;
			//print("start walking");
		}

		// increase speed
		void SpeedUp (float percentage) {
			speedup = percentage;
		}
		
		void FixedUpdate() {
			if (bump) {
				vel.y = 0;
				rb.AddForce(vel * thrustAfterJump, ForceMode.VelocityChange);
				bump = false;
			}
			vel = rb.velocity;
			// stop walking anyway
			if (!Input.GetButton("Vertical")) {
				speedup = 1;
				anim.SetBool("walk", false);
				walking = false;
				//print("stop walking");
			}
			if (grounded) {
				turn = Input.GetAxis("Horizontal");
				if (walking) {
					transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
					// Calculate how fast it should be moving
					Vector3 targetVelocity = new Vector3(0, 0, Input.GetAxis("Vertical"));
					targetVelocity = transform.TransformDirection(targetVelocity);
					targetVelocity *= speed * speedup;
					// Apply a force that attempts to reach our target velocity
					Vector3 velocity = rb.velocity;
					Vector3 velocityChange = (targetVelocity - velocity);
					velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
					velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
					velocityChange.y = 0;
					rb.AddForce(velocityChange, ForceMode.VelocityChange);
					// Jump
					if (canJump && Input.GetButton("Jump")) {
						anim.SetBool("jumpforward", true); // start the jump forward algorythm
					}
					// run the bunny hop animation
					if (Input.GetKeyDown(keyToBunnyHop)) anim.SetTrigger("bunnyhop");
				} else if (!walking && !jumping) {
					// run the walking animation
					if (Input.GetButtonDown("Vertical")) {
						anim.SetBool("walk", true); // walking flag will be set up from the walk01 animation event
						//print("button walk down");
					}
					// turn right or left
					if (turn > 0) TurnTo(true); else if (turn < 0) TurnTo(false);
				}
			}
		}

		public void TurnTo (bool right) {
			if (anim.GetCurrentAnimatorStateInfo(0).IsName("Standing")) {
				if (!turnTrigger) {
					if (right) {
						anim.SetTrigger("turnRight");
						turnTrigger = true;
					} else if (!right) {
						anim.SetTrigger("turnLeft");
						turnTrigger = true;
					}
				}
			}
		}

		public void SetAnimationTrigger (string triggerName) {
			anim.SetTrigger(triggerName);
		}
		
		void OnCollisionStay() {
			grounded = true;
		}

		void OnCollisionExit() {
			grounded = false;
		}

		void OnCollisionEnter(Collision collision) {
			if (jumping) {
				#if UNITY_EDITOR
					if (debug) print("Bump impulse = " + collision.impulse.magnitude);
				#endif
				bump = true; // common flag of ground hit, to add force for a short sliding
				int fall = 0; // select a fall down variants
				if ((collision.impulse.magnitude > maxHitImpulse) && (collision.impulse.magnitude < maxHitImpulse2)) {
					fall = 1;
				} else if (collision.impulse.magnitude > maxHitImpulse2) {
					fall = 2;
				}
				// set animation params
				anim.SetInteger("fallDown", fall);
				anim.SetBool("jumpforward", false);
				jumping = false;
			}
		}

		// events from metarig/Bone/foot.IK.R(L)
		// Animation clip, i.e. Walk01, has event FootstepRight/FootstepLeft
		public void FootstepRight () { rightFoot.Print(); }
		public void FootstepDustRight () { rightFoot.Dust(); }
		public void FootstepLeft () { leftFoot.Print(); }
		public void FootstepDustLeft () { leftFoot.Dust(); }
	}
}
