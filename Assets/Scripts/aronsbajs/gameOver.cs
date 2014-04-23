using UnityEngine;
using System.Collections;

public class gameOver : MonoBehaviour {

	public Texture backgroundTexture;
	public Texture playTexture;
	public GUIStyle buttonStyle;
	
	float button1x = (Screen.width - (Screen.width * .5f)) / 2.0f;
	float button1y = (Screen.height - (Screen.height * .1f)) / 2.0f;
	float button1w = Screen.width * .5f;
	float button1h = Screen.height * .1f;
	
	void OnGUI(){
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);
		
		if (GUI.Button (new Rect (button1x, button1y, button1w, button1h), playTexture, buttonStyle)) {
			Application.LoadLevel("MainMenu");
		}
	}
}
