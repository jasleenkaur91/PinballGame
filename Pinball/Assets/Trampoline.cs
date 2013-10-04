using UnityEngine;
using System.Collections;

public class Trampoline : MonoBehaviour {
	
	private Vector3 bounceVelocity;
	// Use this for initialization
	void Start () {
		bounceVelocity = new Vector3 (0f, 2f, 0f);
	}
	
	void OnCollisionEnter (Collision obj) {
		if (obj.gameObject.tag == "Ball")
		{
			obj.rigidbody.velocity = bounceVelocity;
		}

	}
}
