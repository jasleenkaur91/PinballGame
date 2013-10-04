using UnityEngine;
using System.Collections;

public class LauncherBehavior : MonoBehaviour 
{
	Vector3 pullBackPos = new Vector3(0.8472332f,-1.2f,-0.05f);
	Vector3 startPos = new Vector3(0.8472332f,-0.7f,-0.05f);
	float pullBackTime = 0;
	
	// Use this for initialization
	void Start () {
		
		rigidbody.velocity = Vector3.zero;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	 	if (Input.GetKey ("space" ))
		{	
			rigidbody.AddForce (new Vector3(0,-50,0));
			if(pullBackTime < 10000)
			{
			pullBackTime++;
			}
		}
		else if (Input.GetKeyUp ("space"))
		{
			rigidbody.AddForce (new Vector3(0, pullBackTime*1000,0));
			pullBackTime = 0;
			audio.Play();
		}
		
		if (transform.position.y > -0.7f)
		{
			transform.position = startPos;
			rigidbody.velocity = Vector3.zero;
		}	
	}
}
