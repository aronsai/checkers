using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GUIStyle buttonStyle1;
	public GUIStyle buttonStyle2;
	public Texture backgroundTexture;
	bool showCredits = false;
	bool showOptions = false;

	string muteText = "Music off";
	string effectsText = "Sounds off";
	
	public Texture playTexture;
	public Texture resumeTexture;
	public Texture optionsTexture;
	public Texture creditsTexture;
	public Texture backTexture;

	// x: posx, y: posy, w: width, h: height
	float buttonx = (Screen.width - (Screen.width * .7f));
	float buttony = (Screen.height - (Screen.height * .1f));
	float buttonw = Screen.width * .7f;
	float buttonh = Screen.height * .1f;
	
	float button1x = (Screen.width - (Screen.width * .7f)) / 2.0f;
	float button1w = Screen.width * .7f;
	float button1h = Screen.height * .1f;


	void OnGUI(){
	
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture, ScaleMode.ScaleAndCrop);

		if ( showCredits ) {
			drawCredits();
		}
		else if ( showOptions ) {
			drawOptions();
		}
		else {
			drawMain ();
		}

		if (PlayerPrefs.GetInt ("musicOff") == 1) {
			muteText = "Music off";
		}
		else {
			muteText = "Music on";
		}

		if (PlayerPrefs.GetInt ("effectsOff") == 1) {
			effectsText = "Sounds off";
		}
		else {
			effectsText = "Sounds on";
		}



	}

	void drawMain () {

		if (LevelSerializer.CanResume) {
			if (GUI.Button (new Rect (button1x, buttony / 2.0f, button1w, button1h), resumeTexture, buttonStyle1)) {
				if (LevelSerializer.CanResume ) {
					LevelSerializer.Resume();
				}
			}
		}
		else {
			if (GUI.Button (new Rect (button1x, buttony / 2.0f, button1w, button1h), playTexture, buttonStyle1)) {
				Application.LoadLevel("Scene");
			}
		}
		
		if (GUI.Button (new Rect (button1x, buttony / 1.5f, button1w, button1h), optionsTexture, buttonStyle1)) {
			showOptions = true;		
		}
		
		if (GUI.Button (new Rect (button1x, buttony / 1.2f, button1w, button1h), creditsTexture, buttonStyle1)) {
			showCredits = true;	
		}
	}

	void drawCredits() {

		if (GUI.Button (new Rect (button1x, buttony / 6.0f, button1w, button1h), "Night Owl - Broke For Free", buttonStyle2)) {
			Application.OpenURL("http://freemusicarchive.org/music/Broke_For_Free/Directionless_EP/Broke_For_Free_-_Directionless_EP_-_01_Night_Owl");
		}
		if (GUI.Button (new Rect (button1x, buttony / 4.0f, button1w, button1h), "Bone Breaking", buttonStyle2)) {
			Application.OpenURL("http://soundbible.com/46-Bone-Breaking.html");
		}
		if (GUI.Button (new Rect (button1x, buttony / 3.0f, button1w, button1h), "CrunchingChips", buttonStyle2)) {
			Application.OpenURL("https://www.freesound.org/people/jppi_Stu/sounds/131311/");
		}
		if (GUI.Button (new Rect (button1x, buttony / 2.4f, button1w, button1h), "Fanfare 2", buttonStyle2)) {
			Application.OpenURL("https://www.freesound.org/people/primordiality/sounds/78823/");
		}
		if (GUI.Button (new Rect (button1x, buttony / 1.2f, button1w, button1h), backTexture, buttonStyle1)) {
			showCredits = false;
		}
	}

	void drawOptions() {
		if (GUI.Button (new Rect (button1x, buttony / 2f, button1w, button1h), muteText, buttonStyle1)) {
			if (PlayerPrefs.GetInt ("musicOff") == 1) {
				PlayerPrefs.SetInt ("musicOff", 0);
				muteText = "Music off";
			}
			else {
				PlayerPrefs.SetInt ("musicOff", 1);
				muteText = "Music on";
			}
			
		}
		if (GUI.Button (new Rect (button1x, buttony / 1.5f, button1w, button1h), effectsText, buttonStyle1)) {
			if (PlayerPrefs.GetInt ("effectsOff") == 1) {
				PlayerPrefs.SetInt ("effectsOff", 0);
				effectsText = "Sounds off";
			}
			else {
				PlayerPrefs.SetInt ("effectsOff", 1);
				effectsText = "Sounds on";
			}
			
		}
		if (GUI.Button (new Rect (button1x, buttony / 1.2f, button1w, button1h), backTexture, buttonStyle1)) {
			showOptions = false;
		}
	}
	
}
