using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {
	
	float startTime;
	float newTime;
	public int startMinutes;
	private int minutes;
	private int seconds;
	public int balls;
	bool win;
	bool start;
	int tutorialPage;
	private GameObject ball;
	private GameObject titleScreen;
	int enemiesDestroyed;
		
	public void decreaseBalls()
	{
		balls--;	
	}
	
	public void enemyDestroyed()
	{
		enemiesDestroyed++;
		if (enemiesDestroyed == 3)
		{
			win = true;
		}
	}
	
	void Start()
	{
		ball = GameObject.FindGameObjectWithTag("Ball");
		titleScreen = GameObject.FindGameObjectWithTag("TitleScreen");
		win = false;
		tutorialPage = 0;
		enemiesDestroyed = 0;
	}

	void OnGUI () 
	{
		
		if (start && !win)
		{	
			newTime = Time.time - startTime;
		
			minutes = startMinutes-1 - (int) newTime/60;
			seconds = 59 - (int) newTime%60;
		
			GUI.TextArea(new Rect(Screen.width - 90,10,80,20),"Balls Left: " + balls);
		
			if (seconds < 10)
			{
				GUI.TextArea(new Rect(20,10,100,20), "Time Left - "+minutes+":0"+seconds);
			}
			else
			{
				GUI.TextArea(new Rect(20,10,100,20), "Time Left - "+minutes+":"+seconds);
			}
		
			if(balls == 0 || minutes < 0)
			{
				minutes = -1;
				ball.SendMessage("Hide");
				if (balls == 0)
				{
					GUI.TextArea (new Rect(Screen.width/2 - 75, Screen.height/2 - 20, 130, 20), "You ran out of balls!");
				}
				else
				{
					GUI.TextArea (new Rect(Screen.width/2 - 75, Screen.height/2 - 20, 130, 20), "You ran out of Time!");
				}
			
				if (GUI.Button (new Rect ((Screen.width/2) - 75,(Screen.height/2) + 0,130, 50), "Try Again")) 
				{
					Application.LoadLevel(Application.loadedLevel);
				}
				if (GUI.Button (new Rect ((Screen.width/2) - 75,(Screen.height/2) + 50, 130, 50), "Quit"))
				{
					Application.Quit();	
				}
			}
		}
		else
		{
			if (start && win)
			{
					ball.SendMessage("Hide");
					GUI.TextArea (new Rect(Screen.width/2 - 85, Screen.height/2 - 20, 170, 20), "You Won! Congratulations!");
					if (GUI.Button (new Rect ((Screen.width/2) - 75,(Screen.height/2) + 0,130, 50), "Play Again")) 
					{
						Application.LoadLevel(Application.loadedLevel);
					}
					if (GUI.Button (new Rect ((Screen.width/2) - 75,(Screen.height/2) + 50, 130, 50), "Quit"))
					{
						Application.Quit();	
					}
			}
			else
			{
				switch (tutorialPage)
				{
				case 1:
					GUI.TextArea (new Rect(Screen.width/2 - 85, Screen.height/2 - 100, 170, 20), "Welcome to Pinball Quest!");
					GUI.TextArea(new Rect(Screen.width/2 - 130, Screen.height/2 - 70, 260, 50), 
						"\tLeft and right arrows to use flippers\n\n\t\t\t\t\t\tTry it!");
					if (GUI.Button (new Rect ((Screen.width/2) - 75,(Screen.height/2) - 10, 130, 50), "Next")) 
						tutorialPage++;
					break;	
				case 2:
					GUI.TextArea (new Rect(Screen.width/2 - 130, Screen.height/2 - 70, 260, 50), 
						"\t\t\tSpace bar to launch ball\n\n\t\t\t\t\t\tTry it!");
					if (GUI.Button (new Rect ((Screen.width/2) - 75,(Screen.height/2) - 10, 130, 50), "Next")) 
						tutorialPage++;
					break;	
				case 3:
					GUI.TextArea (new Rect(Screen.width/2 - 130, Screen.height/2 - 70, 260, 50), 
						"\t\t\tHit red triggers to open gates,\n\tdestroy enemies before time runs out!");
					if (GUI.Button (new Rect ((Screen.width/2) - 75,(Screen.height/2) - 10, 130, 50), "Play")) 
					{
						start = true;
						startTime = Time.time;
						ball.SendMessage("Start", true);
					}
					if (GUI.Button (new Rect ((Screen.width/2) - 75,(Screen.height/2) + 50, 130, 50), "Quit"))
					{
						Application.Quit();	
					}
					break;
				case 0:
					if (GUI.Button (new Rect ((Screen.width/2) - 75,(Screen.height/2) - 70, 130, 50), "Tutorial")) 
					{
						tutorialPage = 1;
						Destroy(titleScreen);
					}
					if (GUI.Button (new Rect ((Screen.width/2) - 75,(Screen.height/2) - 10, 130, 50), "Play")) 
					{
						start = true;
						startTime = Time.time;
						ball.SendMessage("Start", true);
						Destroy(titleScreen);
					}
					if (GUI.Button (new Rect ((Screen.width/2) - 75,(Screen.height/2) + 50, 130, 50), "Quit"))
					{
						Application.Quit();	
					}
					break;

				}
			}
		}
	}
}
