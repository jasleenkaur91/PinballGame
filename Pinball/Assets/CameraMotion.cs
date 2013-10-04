using UnityEngine;
using System.Collections;

public class CameraMotion : MonoBehaviour {
	private float bottomY, topY;
	private GameObject ball;
	
	// Use this for initialization
	void Start () {
		bottomY = -1.3f;
		topY = 1.5f;
		ball = GameObject.FindGameObjectWithTag("Ball");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 prevPosition = this.transform.position;
		if (ball)
		{
			if (((ball.rigidbody.velocity.y > 0) && ((ball.transform.position.y - prevPosition.y) > .3))
				|| ((ball.transform.position.y - prevPosition.y) > .6))
			{
				if (prevPosition.y < topY)
				{
					prevPosition = new Vector3(prevPosition.x, prevPosition.y + Mathf.Abs(ball.rigidbody.velocity.y*Time.deltaTime*.9f), prevPosition.z);
					this.transform.position = prevPosition;
				}
			}
			else
			{
				if (((ball.rigidbody.velocity.y < 0) && ((ball.transform.position.y - prevPosition.y) < .6))
					|| ((ball.transform.position.y - prevPosition.y) < .3))
				{
					if (prevPosition.y > bottomY)
					{
						prevPosition = new Vector3(prevPosition.x, prevPosition.y - Mathf.Abs (ball.rigidbody.velocity.y*Time.deltaTime*1.1f), prevPosition.z);
						this.transform.position = prevPosition;
					}
				}			
			}
		}
	}
}
