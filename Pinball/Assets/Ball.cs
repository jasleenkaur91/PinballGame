using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	Vector3 ballVelocity = Vector3.zero;
	GameObject[] topFlippers;
	public GameObject LaunchBlock;
	public BlockBehavior blockController;
	public HUDScript hudController;
	public GameObject mainCamera;
	
	
	// Use this for initialization
	void Start (bool ready) {
		mainCamera = GameObject.Find("Main Camera");
		hudController = (HUDScript) mainCamera.GetComponent(typeof(HUDScript));
		if (ready)
		{
			this.rigidbody.isKinematic = false;
			this.transform.position = new Vector3 (0.85f, -.5f, -.05f);
			this.rigidbody.velocity = ballVelocity;
			this.rigidbody.angularVelocity = ballVelocity;
			topFlippers = GameObject.FindGameObjectsWithTag("Flipper2");
			LaunchBlock = GameObject.Find("LauncherBlock");
			blockController = (BlockBehavior) LaunchBlock.GetComponent(typeof(BlockBehavior));
			blockController.unBlock();
		}
		else
		{
			this.rigidbody.isKinematic = true;
		}
	}
		
	void OnCollisionEnter (Collision obj) {
		
		if (obj.gameObject.tag == "Bottom")
		{
			hudController.decreaseBalls();
			this.rigidbody.velocity = Vector3.zero;		
			this.Start(true);
		}
		else
			audio.Play();
	}
	
	void OnTriggerExit (Collider obj) {
		if ((obj.gameObject.tag == "Level2") && (this.transform.position.y > 1.1))
		{
			TopSide();
		}
		if ((obj.gameObject.tag == "Level2") && (this.transform.position.y < 1))
		{
			BottomSide();
		}
	}
	
	void TopSide() {
		foreach (GameObject o in topFlippers)
		{
			o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y, -.05f);
		}
	}

	void BottomSide() {
		foreach (GameObject o in topFlippers)
		{
			o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y, .15f);
		}
	}	
	
	void Hide()
	{
		this.transform.position = new Vector3 (0f, -.5f, .05f);
		this.rigidbody.velocity = ballVelocity;
		this.rigidbody.angularVelocity = ballVelocity;
	}		
}
