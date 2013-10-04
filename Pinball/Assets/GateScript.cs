using UnityEngine;
using System.Collections;

public class GateScript : MonoBehaviour {

	public bool[] triggers;
	private GameObject tramp;
	public bool gateLowered;
	
	void Start()
	{
		tramp = GameObject.FindGameObjectWithTag("Tramp");
		gateLowered = false;
	}

	void LightTriggerHit(int id)
	{
		if (!triggers[id])
			triggers[id] = true;
		
		bool openGate = true;
		foreach (bool trigger in triggers)
			if (!trigger)
				openGate = false;
		
		if (openGate)
		{
			if (!gateLowered)
			{
				gateLowered = true;
				audio.Play();
				if (this.tag == "TopGate")
					tramp.transform.position = new Vector3(tramp.transform.position.x, tramp.transform.position.y, -.1f); 
			}
		}
			
	}
	
	void Update()
	{
		if (gateLowered)
		{
			transform.position = Vector3.Lerp (transform.position, new Vector3(-0.03681336f,0.71f,0.2f), Time.deltaTime*2);	
		}
	}
}


