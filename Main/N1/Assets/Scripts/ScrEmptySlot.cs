using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrEmptySlot : MonoBehaviour
{

    public int emptyX;
    public int emptyY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SetEmptySlot(int x, int y)
    {
        emptyX = x;
        emptyY = y;
    }
}
