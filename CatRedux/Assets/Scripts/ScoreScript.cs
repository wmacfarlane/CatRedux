using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	public GameObject player;
	//for our GUIText object and our score
	public GUIElement gui;
	float playerScore = 0;

	//this function updates our guitext object
	void OnGUI(){
		gui.guiText.text = "Score: " + ((int)(playerScore * 10)).ToString ();
	}
	//this is generic function we can call to increase the score by an amount
	public void increaseScore(int amount){
		playerScore += amount;
	}

	// Update is called once per frame
	void Update () {
	
	//if player is alive, then update time
	if(player){	
	//update our score every tick of the clock
		playerScore += Time.deltaTime;
	}
		
	}
}