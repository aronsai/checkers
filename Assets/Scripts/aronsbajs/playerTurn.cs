using UnityEngine;
using System.Collections;

public class playerTurn : MonoBehaviour {

	public bool turnWhite = true;
	public GameObject whiteTurn;
	public GameObject blackTurn;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		if (turnWhite == true){

			whiteTurn.renderer.material.color = Color.white;
			blackTurn.renderer.material.color = Color.black;

		}

		else {

			whiteTurn.renderer.material.color = Color.black;
			blackTurn.renderer.material.color = Color.white;

		}
	
	}

	public void toggleTurn(){
		StartCoroutine (toggleRoutine ());
	}

	IEnumerator toggleRoutine() {
		if (turnWhite == true){
			turnWhite = false;
		}
		else {
			turnWhite = true;
		}
		yield return new WaitForSeconds (0.1f);
		LevelSerializer.Checkpoint ();
	}

}
