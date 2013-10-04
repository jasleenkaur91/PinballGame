using UnityEngine;
using System.Collections;

public class TriggerLight : MonoBehaviour {
	public Texture2D litTexture;
	public Texture2D darkTexture;
	public string target;
	public int id;
	
	private GameObject gate;
	
	// Use this for initialization
	void Start () {
		gate = GameObject.FindGameObjectWithTag(target);
	}
	
	void OnCollisionExit (Collision obj) {
		this.gameObject.light.enabled = true;
		this.renderer.material.mainTexture = litTexture;
		this.light.enabled = true;
		gate.SendMessage("LightTriggerHit", id);
		audio.Play();
	}
}
