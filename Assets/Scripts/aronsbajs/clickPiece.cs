using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class clickPiece : MonoBehaviour {

	public placePiece placePiece;
	public playerTurn playerTurn;
	public manageGreens manageGreens;
	public int pieceID;
	public int piecePos;
	public bool isQueen = false;
	bool availableEnemies = false;

	public float speed = 20f;
	public Vector3 targetPos;
	public Vector3 originalPos;
	private bool mouseDown = false;

	public GameObject[] greens = new GameObject[4]; //objekten som OnMouseUp() kollar avstånd mot
	public Vector3 closestTarget;

	void Start () {
		if(LevelSerializer.IsDeserializing) {

			return;
		}

		targetPos = transform.position;   
		originalPos = transform.position; 

	}

	void Update () {

		if (Input.GetMouseButtonDown (0))
		{
			Vector3 sizeMax = transform.position, sizeMin = transform.position, mus = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			float brickaSize = renderer.bounds.size.x / 2;
			sizeMax += new Vector3(brickaSize, brickaSize, 0);
			sizeMin -= new Vector3(brickaSize, brickaSize, 0);

			if ( mus.x < sizeMax.x && mus.y < sizeMax.y && mus.x > sizeMin.x && mus.y > sizeMin.y)
			{
				if (pieceID > 12 && playerTurn.turnWhite == true || pieceID < 13 && playerTurn.turnWhite == false){
					if (placePiece.pieceMovedThisTurn == 0){
						pieceClicked();
					}
					if (placePiece.pieceMovedThisTurn == pieceID){
						moveAgain();
					}

					mouseDown = true;
				}
			}
		}

		if (mouseDown == true) {
			float distance = transform.position.z - Camera.main.transform.position.z;
			targetPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
			targetPos = Camera.main.ScreenToWorldPoint(targetPos);
		}

		transform.position = Vector3.Lerp (transform.position, targetPos, speed * Time.deltaTime);

		if (PlayerPrefs.GetInt ("effectsOff") == 1) {
			audio.mute = true;
		}
		else {
			audio.mute = false;
		}

	}

	void OnMouseUp() {
		mouseDown = false;
		checkDistances ();
		targetPos.x = closestTarget.x;
		targetPos.y = closestTarget.y;
		if (placePiece.pieceMovedThisTurn == 0){
			pieceClicked();
		}
		if (placePiece.pieceMovedThisTurn == pieceID){
			moveAgain();
		}
	}
	
	void checkDistances(){
		Vector3 tempPos = new Vector3();
		closestTarget = originalPos;
		float closestDistance = Vector3.Distance(originalPos, transform.position);
		GameObject tempGreen = null;
		for (int i = 0; i < greens.Length; i++){
			if (greens[i] != null){
				tempPos = greens[i].transform.position;
				float tempDistance = Vector3.Distance (tempPos, transform.position);
				if (tempDistance < closestDistance && tempDistance < System.Math.Abs(2.5)) {
					closestDistance = tempDistance;
					closestTarget = tempPos;
					tempGreen = greens[i];
				}
			}
		}
		if (tempGreen != null){
			tempGreen.GetComponent<clickGreen>().Clicked();
			targetPos = transform.position;
			originalPos = transform.position;
		}
	}

	public void moveAgain () {
		
		if (pieceID < 13 && playerTurn.turnWhite == false) {  //svart tur
			
			if (isQueen == true) {
				checkUp(2, false);
				checkDown(2, false);
			}
			else {
				checkDown (2, false);
			}
			if (availableEnemies == true){
				manageGreens.Run (this.gameObject);
				availableEnemies = false;
			}
			else {
				playerTurn.toggleTurn();
				placePiece.pieceMovedThisTurn = 0;
			}
		}
		
		if (pieceID > 12 && playerTurn.turnWhite == true) {  //vit tur
			if (isQueen == true) {
				checkUp(1, false);
				checkDown (1, false);
			}
			else {
				checkUp(1, false);
			}
			if (availableEnemies == true){
				manageGreens.Run (this.gameObject);
				availableEnemies = false;
			}
			else {
				playerTurn.toggleTurn();
				placePiece.pieceMovedThisTurn = 0;
			}
		}

	}

	void pieceClicked(){

		if (pieceID < 13 && playerTurn.turnWhite == false) {  //svart tur

			if (isQueen == true) {
				checkUp(2, true);
				checkDown(2, true);
			}
			else {
				checkDown (2, true);
			}
			manageGreens.Run (this.gameObject);
			availableEnemies = false;
		}

		if (pieceID > 12 && playerTurn.turnWhite == true) {  //vit tur
			if (isQueen == true) {
				checkUp(1, true);
				checkDown (1, true);
			}
			else {
				checkUp(1, true);
			}
			manageGreens.Run (this.gameObject);
			availableEnemies = false;
		}

	}

	void checkUp (int enemyColor, bool isFirstMove){

		// Kolla inte upp
		if (piecePos == 2 || piecePos == 4 || piecePos == 6  || piecePos == 8) {
			return;
		}

		// Kolla vänster upp
		if (piecePos != 9 && piecePos != 25 && piecePos != 41 && piecePos != 57) {
			if (placePiece.checkTaken (piecePos - 1 - 9) == enemyColor && piecePos != 9 && piecePos != 11 && piecePos != 13 && piecePos != 15 && piecePos != 18 && piecePos != 34 && piecePos != 50) {
				if (placePiece.checkTaken (piecePos - 1 - 18) == 0) {
					placePiece.greens.Add (piecePos - 1 - 18);
					placePiece.enemies.Add (piecePos - 9);
					availableEnemies = true;
				}
			}
			else if (placePiece.checkTaken (piecePos - 1 - 9) == 0 && isFirstMove == true) {
				placePiece.greens.Add (piecePos - 1 - 9);
				placePiece.enemies.Add (0);
			}
		}

		// Kolla höger upp
		if (piecePos != 24 && piecePos != 40 && piecePos != 56) {
			if (placePiece.checkTaken (piecePos - 1 - 7) == enemyColor && piecePos != 9 && piecePos != 11 && piecePos != 13 && piecePos != 15 && piecePos != 31 && piecePos != 47 && piecePos != 63) {
				if (placePiece.checkTaken (piecePos - 1 - 14) == 0) {
					placePiece.greens.Add (piecePos - 1 - 14);
					placePiece.enemies.Add (piecePos - 7);
					availableEnemies = true;
				}
			}
			else if (placePiece.checkTaken (piecePos - 1 - 7) == 0 && isFirstMove == true) {
				placePiece.greens.Add (piecePos - 1 - 7);
				placePiece.enemies.Add (0);
			}
		}

	}

	void checkDown (int enemyColor, bool isFirstMove){

		// Kolla inte ner
		if (piecePos == 57 || piecePos == 59 || piecePos == 61 || piecePos == 63) {
			return;
		}

		// Kolla höger ner
		if (piecePos != 8 && piecePos != 24 && piecePos != 40 && piecePos != 56) {
			if (placePiece.checkTaken (piecePos - 1 + 9) == enemyColor && piecePos != 15 && piecePos != 31 && piecePos != 47 && piecePos != 50 && piecePos != 52 && piecePos != 54 && piecePos != 56) {
				if (placePiece.checkTaken (piecePos - 1 + 18) == 0) {
					placePiece.greens.Add (piecePos - 1 + 18);
					placePiece.enemies.Add (piecePos + 9);
					availableEnemies = true;
				}
			}
			else if (placePiece.checkTaken (piecePos - 1 + 9) == 0 && isFirstMove == true) {
				placePiece.greens.Add (piecePos - 1 + 9);
				placePiece.enemies.Add (0);
			}
		}
		
		// Kolla vänster ner
		if (piecePos != 9 && piecePos != 25 && piecePos != 41 && piecePos != 57) {
			if (placePiece.checkTaken (piecePos - 1 + 7) == enemyColor && piecePos != 2 && piecePos != 18 && piecePos != 34 && piecePos != 50 && piecePos != 52 && piecePos != 54 && piecePos != 56) {
				if (placePiece.checkTaken (piecePos - 1 + 14) == 0) {
					placePiece.greens.Add (piecePos - 1 + 14);
					placePiece.enemies.Add (piecePos + 7);
					availableEnemies = true;
				}
			}
			else if (placePiece.checkTaken (piecePos - 1 + 7) == 0 && isFirstMove == true) {
				placePiece.greens.Add (piecePos - 1 + 7);
				placePiece.enemies.Add (0);
			}
		}



	}

	public void registerMove (string moveTo){
		int to;
		int.TryParse (moveTo, out to);
		placePiece.taken [piecePos - 1] = 0;
		placePiece.pos [piecePos - 1] = null;
		piecePos = to + 1;
		if (pieceID > 12){
			placePiece.taken [piecePos - 1] = 2;
		}
		else {
			placePiece.taken [piecePos - 1] = 1;
		}
		placePiece.pos [piecePos - 1] = this.gameObject;
		if (piecePos < 9 && pieceID > 12 && isQueen == false){
			audio.clip = placePiece.madeKing;
            audio.volume = 1;
			audio.Play ();
			makeQueen();
		}
		else if (piecePos > 56 && pieceID < 13 && isQueen == false){
			audio.clip = placePiece.madeKing;
            audio.volume = 1;
			audio.Play ();
			makeQueen();
		}
		else {
			audio.clip = placePiece.moveSound;
            audio.volume = 1;
			audio.Play ();
		}
		placePiece.pieceMovedThisTurn = pieceID;
	}

	void makeQueen (){
		if (isQueen == false) {
			isQueen = true;
			if (pieceID > 12){
				GetComponent<SpriteRenderer>().sprite = placePiece.whiteQueenSprite;
			}
			if (pieceID < 13){
				GetComponent<SpriteRenderer>().sprite = placePiece.blackQueenSprite;
			}
		}
	}

}
