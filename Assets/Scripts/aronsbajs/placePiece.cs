using UnityEngine;
using System.Collections;

public class placePiece : MonoBehaviour {

	public bool firstStart = true;

	public playerTurn playerTurn;
	public ArrayList greens = new ArrayList();
	public ArrayList enemies = new ArrayList();
	public int pieceMovedThisTurn = 0;
	public int whitesRemaining = 12;
	public int blacksRemaining = 12;

	public Sprite whiteQueenSprite;
	public Sprite blackQueenSprite;
	public AudioClip moveSound;
	public AudioClip madeKing;
	public AudioClip destroySound;

	public GameObject tempPiece;
	public GameObject tempGreen;

	public GameObject black1;
	public GameObject black2;
	public GameObject black3;
	public GameObject black4;

	public GameObject black5;
	public GameObject black6;
	public GameObject black7;
	public GameObject black8;

	public GameObject black9;
	public GameObject black10;
	public GameObject black11;
	public GameObject black12;

	public GameObject white1;
	public GameObject white2;
	public GameObject white3;
	public GameObject white4;
	
	public GameObject white5;
	public GameObject white6;
	public GameObject white7;
	public GameObject white8;
	
	public GameObject white9;
	public GameObject white10;
	public GameObject white11;
	public GameObject white12;

	public float[,] position = new float[2,64] {
		{
			0, -3.13f, 0, -0.63f, 0, 1.87f, 0, 4.37f, 
			-4.38f, 0, -1.88f, 0, 0.62f, 0, 3.12f, 0,
			0, -3.13f, 0, -0.63f, 0, 1.87f, 0, 4.37f, 
			-4.38f, 0, -1.88f, 0, 0.62f, 0, 3.12f, 0, 
			0, -3.13f, 0, -0.63f, 0, 1.87f, 0, 4.37f, 
			-4.38f, 0, -1.88f, 0, 0.62f, 0, 3.12f, 0,
			0, -3.13f, 0, -0.63f, 0, 1.87f, 0, 4.37f, 
			-4.38f, 0, -1.88f, 0, 0.62f, 0, 3.12f, 0
		},{
			0, 4.38f, 0, 4.38f, 0, 4.38f, 0, 4.38f,
			3.12f, 0, 3.12f, 0, 3.12f, 0, 3.12f, 0, 
			0, 1.88f, 0, 1.88f, 0, 1.88f, 0, 1.88f, 
			0.62f, 0, 0.62f, 0, 0.62f, 0, 0.62f, 0, 
			0, -0.62f, 0, -0.62f, 0, -0.62f, 0, -0.62f,
			-1.88f, 0, -1.88f, 0, -1.88f, 0, -1.88f, 0, 
			0, -3.12f, 0, -3.12f, 0, -3.12f, 0, -3.12f,
			-4.38f, 0, -4.38f, 0, -4.38f, 0, -4.38f, 0
		}
	};

	public int[] taken = new int[32] {
		1, 1, 1, 1,
		1, 1, 1, 1,
		1, 1, 1, 1,
		0, 0, 0, 0,
		0, 0, 0, 0,
		2, 2, 2, 2,
		2, 2, 2, 2,
		2, 2, 2, 2
	};

	public GameObject[] pieces = new GameObject[24];
	public GameObject[] pos = new GameObject[64];

	// Use this for initialization
	void Start () {

		Debug.Log (LevelSerializer.CanResume);

		if (firstStart) {
			black1.transform.localPosition = new Vector3 (position [0, 1], position [1, 1], 0);
			black2.transform.localPosition = new Vector3 (position [0, 3], position [1, 3], 0);
			black3.transform.localPosition = new Vector3 (position [0, 5], position [1, 5], 0);
			black4.transform.localPosition = new Vector3 (position [0, 7], position [1, 7], 0);

			black5.transform.localPosition = new Vector3 (position [0, 8], position [1, 8], 0);
			black6.transform.localPosition = new Vector3 (position [0, 10], position [1, 10], 0);
			black7.transform.localPosition = new Vector3 (position [0, 12], position [1, 12], 0);
			black8.transform.localPosition = new Vector3 (position [0, 14], position [1, 14], 0);

			black9.transform.localPosition = new Vector3 (position [0, 17], position [1, 17], 0);
			black10.transform.localPosition = new Vector3 (position [0, 19], position [1, 19], 0);
			black11.transform.localPosition = new Vector3 (position [0, 21], position [1, 21], 0);
			black12.transform.localPosition = new Vector3 (position [0, 23], position [1, 23], 0);

			white1.transform.localPosition = new Vector3 (position [0, 40], position [1, 40], 0);
			white2.transform.localPosition = new Vector3 (position [0, 42], position [1, 42], 0);
			white3.transform.localPosition = new Vector3 (position [0, 44], position [1, 44], 0);
			white4.transform.localPosition = new Vector3 (position [0, 46], position [1, 46], 0);

			white5.transform.localPosition = new Vector3 (position [0, 49], position [1, 49], 0);
			white6.transform.localPosition = new Vector3 (position [0, 51], position [1, 51], 0);
			white7.transform.localPosition = new Vector3 (position [0, 53], position [1, 53], 0);
			white8.transform.localPosition = new Vector3 (position [0, 55], position [1, 55], 0);

			white9.transform.localPosition = new Vector3 (position [0, 56], position [1, 56], 0);
			white10.transform.localPosition = new Vector3 (position [0, 58], position [1, 58], 0);
			white11.transform.localPosition = new Vector3 (position [0, 60], position [1, 60], 0);
			white12.transform.localPosition = new Vector3 (position [0, 62], position [1, 62], 0);

			firstStart = false;
		}

		


	}
	
	// Update is called once per frame
	void Update () {

		if (PlayerPrefs.GetInt ("effectsOff") == 1) {
			audio.mute = true;
		}
		else {
			audio.mute = false;
		}

	}

	public int checkTaken (int pos) {
        if (taken[pos] == 1)
            return 1;
        else if (taken[pos] == 2)
            return 2;
        else
            return 0;
	}

	public void movePiece(GameObject piece, GameObject green){
		tempPiece = piece;
		tempGreen = green;
		moveResume ();
	}

	public void moveResume () {
		tempPiece.transform.position = tempGreen.transform.position;
		tempPiece.transform.localPosition = new Vector3(tempPiece.transform.localPosition.x,tempPiece.transform.localPosition.y,-0.1f);
		tempPiece.GetComponent<clickPiece>().registerMove (tempGreen.name);
	}

	public void destroyEnemy(int enemy) {
		int toDestroy = System.Array.IndexOf (pieces, pos [enemy - 1]);
		Destroy (pieces[toDestroy]);
		audio.clip = destroySound;
        audio.volume = 1;
		audio.Play ();
		if (taken [enemy - 1] == 1){
			blacksRemaining--;
			if (blacksRemaining == 0){
				PlayerPrefs.SetString("__RESUME__", null);
				Application.LoadLevel("WhiteWins");
			}
		}
		if (taken [enemy - 1] == 2){
			whitesRemaining--;
			if (whitesRemaining == 0){
				PlayerPrefs.SetString("__RESUME__", null);
				Application.LoadLevel("BlackWins");
			}
		}
        taken[enemy - 1] = 0;
		pos [enemy - 1] = null;
	}

}
