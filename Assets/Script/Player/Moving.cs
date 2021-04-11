using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float Speed = 10;
    public Vector3 dirVector;
    public Vector3 mousePoint;
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

    void MoveToMouse()
    {
        this.transform.position += dirVector * Speed * Time.deltaTime;
    }


}
