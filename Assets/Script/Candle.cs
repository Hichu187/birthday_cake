using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    Vector3 mousePosOffset;
    Vector3 pos;
    public bool burn = false;
    public bool canAdd = true;

    public void Update()
    {
        if(burn == true)
        {
            canAdd = false;
        }
        else
        {
            canAdd = true;
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        mousePosOffset = gameObject.transform.position - GetMouseWorldPos();
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        
    }
    private void OnMouseUp()
    {
        //GameController.Instance.matchStick.transform.position = new Vector3(0, 3, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fire"))
        {
            burn = true;
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
