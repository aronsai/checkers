using UnityEngine;
using System.Collections;

public class manageGreens : MonoBehaviour {

	public placePiece placePiece;
	public GameObject green;
	public bool greenToggle = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

	public void Run(GameObject piece) {

		if (greenToggle == false){
			for (int i = 0; i < placePiece.greens.Count; i++)
			{
				int pos = (int) placePiece.greens[i];
				GameObject obj = Instantiate(green) as GameObject;
				obj.transform.localPosition = new Vector3(placePiece.position[0,pos], placePiece.position[1,pos], 0);
				obj.tag = "tempgreen";
				obj.GetComponent<clickGreen>().enemy = (int) placePiece.enemies[i];
				obj.GetComponent<clickGreen>().piece = piece;
				piece.GetComponent<clickPiece>().greens[i] = obj;
				obj.name = pos.ToString ();
			}

			placePiece.enemies.Clear ();
			placePiece.greens.Clear ();
			
			if (greenToggle == false)
				greenToggle = true;
			else if (greenToggle == true)
				greenToggle = false;

		} else {
			clearGreen();
		}

	}

	public void clearGreen(){
		GameObject[] names = GameObject.FindGameObjectsWithTag("tempgreen");
		
		foreach(GameObject item in names)
		{
			Destroy(item);
		}

		placePiece.greens.Clear ();
		
		if (greenToggle == false)
			greenToggle = true;
		else if (greenToggle == true)
			greenToggle = false;

	}

}
	