using UnityEngine;
using System.Collections;

public class clickGreen : MonoBehaviour {
    
	GameObject Foreground;
	GameObject Level;
	GameObject Middleground;
	playerTurn playerTurn;
	placePiece placePiece;
	manageGreens manageGreens;
	public GameObject piece;
	public int enemy;

	// Use this for initialization
	void Start () {
		Foreground = GameObject.Find("Foreground");
		Middleground = GameObject.Find("Middleground");
		Level = GameObject.Find("Level");
		playerTurn = Level.GetComponent<playerTurn> ();
		placePiece = Foreground.GetComponent<placePiece> ();
		manageGreens = Middleground.GetComponent<manageGreens> ();
	}
	
	// Update is called once per frame
	/*void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 sizeMax = transform.position, sizeMin = transform.position, mus = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float brickaSize = 0.55f;
            sizeMax += new Vector3(brickaSize, brickaSize, 0);
            sizeMin -= new Vector3(brickaSize, brickaSize, 0);

            if (mus.x < sizeMax.x && mus.y < sizeMax.y && mus.x > sizeMin.x && mus.y > sizeMin.y)
            {
				Clicked();
            }
        }
	}*/

	public void Clicked(){
		placePiece.movePiece(piece, this.gameObject);
		manageGreens.clearGreen();
		if (enemy != 0){
			placePiece.destroyEnemy(enemy);
			piece.GetComponent<clickPiece>().moveAgain();
		}
		else {
			playerTurn.toggleTurn();
			placePiece.pieceMovedThisTurn = 0;
		}
	}

}
