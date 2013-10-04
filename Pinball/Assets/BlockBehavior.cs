using UnityEngine;
using System.Collections;

public class BlockBehavior : MonoBehaviour {
	
	bool blocking;

	// Use this for initialization
	void Start () {
		
		blocking = false;
		
	}
	
	public void Block()
	{
		blocking = true;
	}
	
	public void unBlock ()
	{	
		blocking = false;		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (blocking)
		{
			transform.position = Vector3.Lerp (transform.position, new Vector3(0.75f, 0.5f,-0.05f), Time.deltaTime*2);
		}
		else
		{
			transform.position = Vector3.Lerp (transform.position, new Vector3(0.75f,0.32f,-0.05f), Time.deltaTime*2);
		}
		
	}
}
