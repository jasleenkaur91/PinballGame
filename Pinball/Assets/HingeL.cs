using UnityEngine;
using System.Collections;

public class HingeL : MonoBehaviour {
	private Quaternion downPoint, upPoint;	
	private float downAngle = 300f;
	private float upAngle = 240f;
	private float flipperSpeed = 40f;
	
	// Use this for initialization
	void Start () {		
		downPoint = Quaternion.Euler(downAngle, 90f, 90f);
		upPoint = Quaternion.Euler(upAngle, 90f, 90f);		
	}
	
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			this.Flip ();
		}
		else {
			this.Fall();
		}
	}
	
	void Flip()
	{
		this.gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.localRotation, upPoint, flipperSpeed * Time.fixedDeltaTime);
	}
	
	void Fall()
	{
		this.gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.localRotation, downPoint, flipperSpeed * Time.fixedDeltaTime);
	}

}
