using UnityEngine;
using System.Collections;

public class gameGUI : MonoBehaviour {
	
	public GUIStyle buttonStyle;
	public GameObject Level;

	public Texture menuTexture;
	public Texture newGame;
	public Texture backToMain;
	public Texture closeTexture;
	public Texture menuBackground;
	bool menuActive = false;
	
	// x: posx, y: posy, w: width, h: height
	float buttony = (Screen.height - (Screen.height * .1f));
	float buttonw = Screen.width * .7f;
	float buttonh = Screen.height * .1f;
	
	float button1x = (Screen.width - (Screen.width * .7f)) / 2.0f;
	float button1w = Screen.width * .7f;
	float button1h = Screen.height * .1f;

	float button2x = Screen.width - (Screen.width * .3f);
	float button2y = Screen.height - (Screen.height * .08f);
	float button2w = Screen.width * .25f;
	
	void OnGUI () {
		if (!menuActive) {
			if (GUI.Button (new Rect (button2x, button2y, button2w, buttonh), menuTexture, buttonStyle)) {
				menuActive = true;
				Level.gameObject.SetActive(false);
			}
		}
		else
			showMenu();
	}

	void showMenu(){
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), menuBackground, ScaleMode.ScaleAndCrop);

		if (GUI.Button (new Rect (button1x, buttony / 2f, button1w, button1h), newGame, buttonStyle)) {
			Application.LoadLevel (Application.loadedLevel);
		}
		if (GUI.Button (new Rect (button1x, buttony / 1.5f, button1w, button1h), backToMain, buttonStyle)) {
			Level.gameObject.SetActive(true);
			LevelSerializer.Checkpoint();
			Application.LoadLevel("MainMenu");
		}
		if (GUI.Button (new Rect (button1x, buttony / 1.2f, button1w, button1h), closeTexture, buttonStyle)) {
			Level.gameObject.SetActive(true);
			menuActive = false;
		}
	}
}
