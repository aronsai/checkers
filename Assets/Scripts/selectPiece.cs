using UnityEngine;
using System.Collections;

public class selectPiece : MonoBehaviour
{
    /*public showGreen showGreen;
    public showGreen showGreen2;
    bool green = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 plats = transform.position, sizeMax = transform.position, sizeMin = transform.position, mus = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float brickaSize = renderer.bounds.size.x / 2;
        sizeMax += new Vector3(brickaSize, brickaSize, 0);
        sizeMin -= new Vector3(brickaSize, brickaSize, 0);
        if (Input.GetButton("Fire1") && mus.x < sizeMax.x && mus.y < sizeMax.y && mus.x > sizeMin.x && mus.y > sizeMin.y )
        {
            if (green == false)
            {
                showGreen.showHide(green);
                showGreen2.showHide(green);
                showGreen.moveGreen(plats);
                showGreen2.moveGreen(plats);
                green = true;
            }
            else if(green == true)
            {
                showGreen.showHide(green);
                showGreen2.showHide(green);
                green = false;
            }
        }
    }

    public void movePiece(Vector3 plats)
    {
        if (green == true)
        {
            transform.position = plats;
            showGreen.showHide(green);
            
        }

        green = false;

    }*/
}