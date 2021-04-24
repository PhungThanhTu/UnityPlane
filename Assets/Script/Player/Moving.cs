using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Moving : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public float Speed = 10;
    public Vector3 dirVector;
    public Vector3 mousePoint;
    public Vector3 touchPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LeadToMouse();
        if(Input.GetMouseButton(1))
        {
            MoveToMouse();
        }
        
        if(Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                LeadToTouch();
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                LeadToTouch();
                MoveToMouse();
            }
            if (Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                LeadToTouch();
                MoveToMouse();
            }
            if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                dirVector = Vector3.zero;
            }
        }
    }

    void LeadToMouse()
    {
        
        Vector3 playerPoint = transform.position;
        mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePoint.z = 0;
        playerPoint.z = 0;

        dirVector = (mousePoint - playerPoint);
        Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);
        if (!screenRect.Contains(Input.mousePosition))
        {
            dirVector = new Vector3(0, 0, 0);
        }

    }

    void LeadToTouch()
    {
        Vector3 playerPoint = transform.position;
        touchPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        touchPoint.z = 0;
        playerPoint.z = 0;

        dirVector = (touchPoint - playerPoint);

    }

    void MoveToMouse()
    {
        this.transform.position += dirVector * Speed * Time.deltaTime;
    }



    public void OnBeginDrag(PointerEventData eventData)
    {
       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       
    }

    public void OnDrag(PointerEventData eventData)
    {
    }
}
