using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrSlot : MonoBehaviour
{
    Vector2 position = new Vector2();
    int orderX;
    int orderY;

    public void SetSlotPosition(float x, float y)
    {
        position = new Vector2(x, y);
    }

    public Vector2 GetSlotPosition()
    {
        return position;
    }

    public void SetOrder(int x, int y)
    {
        orderX = x;
        orderY = y;
    }

    public int GetOrderX()
    {
        return orderX;
    }

    public int GetOrderY()
    {
        return orderY;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
