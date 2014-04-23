using UnityEngine;
using System.Collections;

public class drawBoard : MonoBehaviour {

	public GameObject background;
	public GameObject black;
	public GameObject white;

	public float boardSize;

	void OnGUI(){

		if (Screen.width >= Screen.height) {
			boardSize = Screen.height - Screen.width * .1f;
		} else {
			boardSize = Screen.width - Screen.width * .1f;
		}

		//GUI.DrawTexture (new Rect ((Screen.width - boardSize) / 2.0f, (Screen.height - boardSize) / 2.0f, boardSize, boardSize), backgroundTexture);



	}

	void Start(){

		GameObject background1 = Instantiate (background, new Vector3 (0, 0, 0.32f), Quaternion.identity) as GameObject;

		GameObject black1 = Instantiate (black, new Vector3(0,0,0.31f), Quaternion.identity) as GameObject;
		black1.transform.localScale = new Vector3 (1, 1, 1);

	}

}
