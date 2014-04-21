

using UnityEngine;


public class MenuScript : MonoBehaviour
{
	private GUISkin skin;
	private GUISkin skin2;
	
	void Start()
	{
		// Load a skin for the buttons
		skin = Resources.Load("StartBox") as GUISkin;
		skin2 = Resources.Load ("OptionsBox") as GUISkin;
	}
	
	void OnGUI()
	{
		const int buttonWidth = 128;
		const int buttonHeight = 60;
		
		// Set the skin to use
		GUI.skin = skin;
		
		// Draw a button to start the game
		if (GUI.Button(
			new Rect(
			(Screen.width / 8) - (buttonHeight / 2),
			(7 * Screen.height / 8) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			""
			))
		{
			// On Click, load the first level.
			Application.LoadLevel("catastrophe1"); 
		}

		GUI.skin = skin2;


		if (GUI.Button(

			new Rect(
			(2 * Screen.width / 8) + (buttonHeight/2),
			(7 * Screen.height / 8) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			""
			))
		{

			Application.LoadLevel("catastrophe1"); 
		}


	}
	
}