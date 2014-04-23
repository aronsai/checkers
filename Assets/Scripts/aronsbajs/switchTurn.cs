using UnityEngine;
using System.Collections;

public class switchTurn : MonoBehaviour {

	public playerTurn playerTurn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown (0))
		{
			Vector3 sizeMax = transform.position, sizeMin = transform.position, mus = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			float brickaSize = renderer.bounds.size.x / 2;
			sizeMax += new Vector3(brickaSize, brickaSize, 0);
			sizeMin -= new Vector3(brickaSize, brickaSize, 0);
			
			if ( mus.x < sizeMax.x && mus.y < sizeMax.y && mus.x > sizeMin.x && mus.y > sizeMin.y )
			{
				playerTurn.toggleTurn();
			}
		}

	}
}
