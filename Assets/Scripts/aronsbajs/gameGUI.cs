using UnityEngine;
using System.Collections;

public class gameGUI : MonoBehaviour {
	
	public GUIStyle buttonStyle;
	bool menuActive = false;
	
	// x: posx, y: posy, w: width, h: height
	float buttony = (Screen.height - (Screen.height * .1f));
	float buttonw = Screen.width * .5f;
	float buttonh = Screen.height * .1f;
	
	float button1x = (Screen.width - (Screen.width * .5f)) / 2.0f;
	float button1w = Screen.width * .5f;
	float button1h = Screen.height * .1f;

	float button2x = Screen.width - (Screen.width * .25f);
	float button2y = Screen.height - (Screen.height * .1f);
	float button2w = Screen.width * .25f;
	
	void OnGUI () {
		if (!menuActive) {
			if (GUI.Button (new Rect (button2x, button2y, button2w, buttonh), "Menu", buttonStyle)) {
				menuActive = true;
			}
		}
		else
			showMenu();
	}

	void showMenu(){
		if (GUI.Button (new Rect (button1x, buttony / 3f, button1w, button1h), "New Game", buttonStyle)) {
			Application.LoadLevel (Application.loadedLevel);
		}
		if (GUI.Button (new Rect (button1x, buttony / 2f, button1w, button1h), "Back to Main Menu", buttonStyle)) {
			LevelSerializer.Checkpoint();
			Application.LoadLevel("MainMenu");
		}
		if (GUI.Button (new Rect (button1x, buttony / 1.5f, button1w, button1h), "Close", buttonStyle)) {
			menuActive = false;
		}
	}
}
