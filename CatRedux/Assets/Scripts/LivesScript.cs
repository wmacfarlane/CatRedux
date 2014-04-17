using UnityEngine;
using System.Collections;

public class LivesScript : MonoBehaviour {

	//for our GUIText object and our score
	public GUIElement gui;
	int livesLeft = 9;//this value does not seem to matter

	//this function updates our guitext object
	void OnGUI(){
		gui.guiText.text = "Lives: " + ((int)(livesLeft)).ToString ();
	}

	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.Find("Player");
		
	//if player is alive, then update time
	if(player){	
	//update our score every tick of the clock
		HealthScript hs = player.GetComponent<HealthScript>();
		livesLeft = hs.hp;
	}
	else{
		livesLeft = 0;
	}
		
	}
}