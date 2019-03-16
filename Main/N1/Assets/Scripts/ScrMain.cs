using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrMain : MonoBehaviour
{

    public int partitionColumnCount;
    public ScrPartition scrPartition = new ScrPartition();
    //public GameObject[,] partitions = new GameObject[4,4];    
    public Texture2D stageImage;    
    public GameObject boxBorder;

    public ScrSlot[,] scrSlots = new ScrSlot[4,4];
    ScrEmptySlot emptySlot= new ScrEmptySlot();
    float partitionWidth;
    float cameraWidth;



    // Start is called before the first frame update
    void Start()
    {
        SetSlotPosition();
        CreatePartition(partitionColumnCount);
    }


    void SetSlotPosition()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit != null && hit.collider != null)
            {
                //Debug.Log("I'm hitting " + hit.collider.name);
                GameObject hittedObject = hit.transform.gameObject;
                //Debug.Log("hitted object " + hittedObject.transform.root.name);
                scrPartition.MoveToEmptySlot(hittedObject, emptySlot);

                
            }


        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            //Debug.Log(Screen.width + ", " + Screen.height);
            //Debug.Log((Camera.main.orthographicSize * 2 / Screen.height * Screen.width) );

        }
    }


    void SetCameraWidth()
    {
        cameraWidth = (Camera.main.orthographicSize * 2 / Screen.height * Screen.width);
    }

    void SetPartitionWidth(int columnCount)
    {
        partitionWidth = cameraWidth / columnCount;
    }

    void CreatePartition (int ColumnCount)
    {

        SetCameraWidth();
        SetPartitionWidth(ColumnCount);

        for (int i=0; i < ColumnCount; i++)
        {
            for (int j = 0; j < ColumnCount; j++)
            {
                scrPartition = new ScrPartition();
                scrPartition.Initiate(ColumnCount, partitionWidth, cameraWidth, stageImage, boxBorder, i, j);

       

                if (i==ColumnCount-1 && j== ColumnCount-1-1)
                {
                    break;
                }

            }
        }

        emptySlot.SetEmptySlot(ColumnCount - 1, ColumnCount - 1);

    }



}
