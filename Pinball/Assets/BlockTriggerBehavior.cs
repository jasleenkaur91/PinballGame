using UnityEngine;
using System.Collections;

public class BlockTriggerBehavior : MonoBehaviour {
	
	public GameObject LaunchBlock;
	public BlockBehavior blockController;
	
	// Use this for initialization
	void Start () 
	{
		LaunchBlock = GameObject.Find("LauncherBlock");
		blockController = (BlockBehavior) LaunchBlock.GetComponent(typeof(BlockBehavior));
	}
	
	void OnTriggerEnter(Collider Other)
	{
		blockController.Block();
	}
}
