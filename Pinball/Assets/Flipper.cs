using UnityEngine;
using System.Collections;

public class Flipper : MonoBehaviour {
	
	private Quaternion enterRotation, exitRotation;
	private Vector3 initialBallVelocity;
	private Vector3 initialBallPosition;
	private float lowestBallPoint;
	private float initialTime;

	void OnCollisionEnter (Collision obj) {
		if (obj.gameObject.tag == "Ball")
		{
			enterRotation = this.transform.parent.transform.rotation;
			initialBallVelocity = obj.rigidbody.velocity;
			initialBallPosition = obj.transform.position;
			lowestBallPoint = initialBallPosition.y;
			initialTime = Time.time;
		}
	}
	
	void OnCollisionStay (Collision obj) {
		if (obj.gameObject.tag == "Ball")
		{
			if (obj.transform.position.y < lowestBallPoint)
				lowestBallPoint = initialBallPosition.y;
		}
	}

	
	void OnCollisionExit (Collision obj) {
		float rotationChange;
		Vector3 finalBallPosition = obj.transform.position;
		float collisionDuration = Time.time - initialTime;
		if (obj.gameObject.tag == "Ball")
		{
			exitRotation = this.transform.parent.transform.rotation;
			rotationChange = Quaternion.Angle(exitRotation, enterRotation);
			Debug.Log (rotationChange);
			Debug.DrawLine( this.transform.position, obj.transform.position, Color.red, 5);
			if (rotationChange > 15)
			{
				Vector3 velocity = new Vector3(
					(finalBallPosition.x - initialBallPosition.x)/collisionDuration, 
					Mathf.Max((finalBallPosition.y - lowestBallPoint)/collisionDuration, 1)*3, 0);
				obj.rigidbody.velocity = velocity;
			}
			else
			{
				Vector3 velocity = obj.rigidbody.velocity;
				velocity = new Vector3(velocity.x, velocity.y / 10, velocity.z);
				obj.rigidbody.velocity = velocity;
			}
		}
		audio.Play();
	}
	
/*	void OnCollisionEnter (Collision obj) {
		if (obj.gameObject.tag == "Ball")
		{
			enterRotation = this.transform.parent.transform.rotation;
			initialBallVelocity = obj.rigidbody.velocity;
		}
	}
	
	
	void OnCollisionExit (Collision obj) {
		float rotationChange;
		if (obj.gameObject.tag == "Ball")
		{
			exitRotation = this.transform.parent.transform.rotation;
			rotationChange = Quaternion.Angle(exitRotation, enterRotation);
			Debug.Log (rotationChange);
			Debug.DrawLine( this.transform.position, obj.transform.position, Color.red, 5);
	//		GameObject.FindGameObjectWithTag("Score").guiText.text = 				
	//				rotationChange.ToString();
			if (rotationChange > 15)
			{
				Vector3 velocity = obj.rigidbody.velocity;
				velocity = new Vector3(velocity.x, velocity.y + rotationChange/10  , velocity.z);
				obj.rigidbody.velocity = velocity;
			}
			else
			{
				Vector3 velocity = obj.rigidbody.velocity;
				velocity = new Vector3(velocity.x, velocity.y / 10, velocity.z);
				obj.rigidbody.velocity = velocity;
			}
		}
	}*/

	
	
}
