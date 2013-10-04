using UnityEngine;
using System.Collections;

public class GenericPlaySoundOnCollision : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	 void OnCollisionEnter(Collision collision) {
		audio.Play();
	}
}
