using UnityEngine;
using System.Collections;

public class showGreen : MonoBehaviour
{
    /*public int hv; //hv = högra eller vänstra plutten, höger har värde 1 och vänster har 0
    bool green;
    public selectPiece moveIt;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 sizeMax = transform.position, sizeMin = transform.position, mus = Camera.main.ScreenToWorldPoint(Input.mousePosition), plats = transform.position;
        float brickaSize = renderer.bounds.size.x / 2;
        sizeMax += new Vector3(brickaSize, brickaSize, 0);
        sizeMin -= new Vector3(brickaSize, brickaSize, 0);
        if (Input.GetButton("Fire1") && mus.x < sizeMax.x && mus.y < sizeMax.y && mus.x > sizeMin.x && mus.y > sizeMin.y)
        {
            moveIt.movePiece(plats);
            renderer.enabled = false;
        }

    }
    public void showHide(bool sh)
    {
        green = sh;
        if (sh == true)
        {
            renderer.enabled = false;
            System.Threading.Thread.Sleep(100);
        }
        else if (sh == false)
        {
            renderer.enabled = true;
            System.Threading.Thread.Sleep(100);
        }
    }

    public void moveGreen(Vector3 brickaPlats)
    {
        if (green == false)
        {
            if (hv == 1)
            {
                transform.position = brickaPlats;
                transform.position += new Vector3(1.25f, -1.25f, 0);
            }
            else if (hv == 0)
            {
                transform.position = brickaPlats;
                transform.position += new Vector3(-1.25f, -1.25f, 0);
            }
        }
    }*/

}