using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrSlot : MonoBehaviour
{



    float positionX;
    float positionY;

    void SetSlotPosition(float x, float y)
    {
        positionX = x;
        positionY = y;
    }

    public float GetSlotPositionX()
    {
        return positionX;
    }


    public float GetSlotPositionY()
    {
        return positionY;
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
