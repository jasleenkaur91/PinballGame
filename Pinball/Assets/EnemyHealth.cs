using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int health = 15;
	public Texture minorDamage;
	public Texture moderateDamage;
	public Texture severeDamage;
	
	public HUDScript hudController;
	public GameObject mainCamera;
	
	void Start()
	{
		mainCamera = GameObject.Find("Main Camera");
		hudController = (HUDScript) mainCamera.GetComponent(typeof(HUDScript));	
	}

	void OnCollisionEnter( Collision obj ) {
		audio.Play();
		--health;
		
		if(health <= 3 && health > 2)
		{
			renderer.material.mainTexture = minorDamage;
		}
		else if (health <= 2 && health > 1)
		{
			renderer.material.mainTexture = moderateDamage;
		}
		else if (health <= 1 && health > 0)
		{
			renderer.material.mainTexture = severeDamage;
		}
		else if (health <= 0) 
		{
			hudController.enemyDestroyed();
			Destroy(gameObject);
		}
	}
}
