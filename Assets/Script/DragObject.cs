using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    Vector3 mousePosOffset;
    Vector3 pos;
    public GameObject _lighter;
    public GameObject _recycleBin;
    private bool start = false;
    private void Start()
    {
        pos = transform.position;
        _lighter = GameObject.FindGameObjectWithTag("Lighter");
        _recycleBin = GameObject.FindGameObjectWithTag("Recycle Bin");

    }

    private Vector3 GetMouseWorldPos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        mousePosOffset = gameObject.transform.position - GetMouseWorldPos();
        if(this.gameObject.tag == "Topping")
        {
            _lighter.gameObject.transform.position = new Vector3(0, 10, 0);
            _recycleBin.gameObject.SetActive(true);
            _recycleBin.gameObject.transform.position = new Vector3(0, 3, 0);
        }
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mousePosOffset;
    }
    private void OnMouseUp()
    {
        if(this.gameObject.tag== "Lighter")
        {
            this.transform.position = pos;
        }
        if (this.gameObject.tag == "Topping")
        {
            _recycleBin.gameObject.transform.position = new Vector3(0,10, 0);
            _lighter.gameObject.transform.position = new Vector3(0, 3, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(this.gameObject.tag == "Topping")
        {
            if (collision.gameObject.tag == "Recycle Bin")
            {
                Destroy(this.gameObject);
                _recycleBin.gameObject.transform.position = new Vector3(0, 10, 0);
                _lighter.gameObject.transform.position = new Vector3(0, 3, 0);
            }
        }

    }
}
