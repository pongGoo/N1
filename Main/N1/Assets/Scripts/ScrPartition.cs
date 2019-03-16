using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrPartition : MonoBehaviour
{
    GameObject body;
    GameObject border;
    ScrSlot scrSlot;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSlotPosition(float partitionWidth, float cameraWidth)
    {

    }


    public void Initiate(int columnCount, float partitionWidth, float cameraWidth, Texture2D stageImg, GameObject boxBorder, int i, int j,ScrSlot scrSlot)
    {
        
        body = new GameObject("body_" + i + "_" + j);

        body.AddComponent<ScrBody>();
        body.GetComponent<ScrBody>().SetPosition(i, j);

        SpriteRenderer renderer = body.AddComponent<SpriteRenderer>();

        renderer.sprite = Sprite.Create(stageImg, new Rect(i * partitionWidth * 100, (columnCount - 1 - j) * partitionWidth * 100, partitionWidth * 100, partitionWidth * 100), new Vector2(0.5f, 0.5f), 100.0f);
        GameObject border = Instantiate(boxBorder);
        border.transform.parent = body.transform;
        border.name = "border_" + i + "_" + j;
        SpriteRenderer borderRenderer = border.GetComponent<SpriteRenderer>();
        borderRenderer.sortingOrder = 1;
        borderRenderer.size = new Vector2(partitionWidth, partitionWidth);

        BoxCollider2D boxCollider2D = body.AddComponent<BoxCollider2D>();
        boxCollider2D.size = new Vector2(partitionWidth, partitionWidth);



        //body.transform.position = new Vector2(-1 * cameraWidth / 2 + partitionWidth / 2 + i * partitionWidth, 2 - j * partitionWidth);
        body.transform.position = scrSlot.GetSlotPosition();

    }



    public void MoveToEmptySlot(GameObject targetObject, ScrSlot emptySlot)
    {

        if (IsNearEmptySlot(targetObject,emptySlot))
        {
            Debug.Log("IsNearEmptySlot");
            Vector2 tempPosition = targetObject.transform.position;

            targetObject.transform.position = emptySlot.GetSlotPosition();
            emptySlot.SetSlotPosition(tempPosition.x, tempPosition.y);

            int tempOrderX = targetObject.GetComponent<ScrBody>().orderX;
            int tempOrderY = targetObject.GetComponent<ScrBody>().orderY;

            targetObject.GetComponent<ScrBody>().orderX = emptySlot.GetOrderX();
            targetObject.GetComponent<ScrBody>().orderY = emptySlot.GetOrderY();

            emptySlot.SetOrder(tempOrderX, tempOrderY);

        }

    }

    public bool IsNearEmptySlot(GameObject targetObject, ScrSlot emptySlot)
    {
        bool isNear = false;

         ScrBody scrBody = targetObject.GetComponent<ScrBody>();

         if (scrBody.orderX == emptySlot.GetOrderX())
         {
             int gap = scrBody.orderY - emptySlot.GetOrderY();
             if (gap == 1 || gap == -1)
             {
                 isNear = true;
             }
         }
         else if (scrBody.orderY == emptySlot.GetOrderY())
         {
             int gap = scrBody.orderX - emptySlot.GetOrderX();
             if (gap == 1 || gap == -1)
             {
                 isNear = true;
             }
         }
         else
         {
             isNear = false;
         }

        return isNear;

    }



}
