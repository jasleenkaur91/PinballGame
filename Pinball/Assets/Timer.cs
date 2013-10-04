using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

public float myTime = 0.1f;

// Update is called once per frame
void Update () {
		
	if(myTime>0.1) {
		myTime += Time.deltaTime;
		}	
		
		

	}
	
}