using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrPartition : MonoBehaviour
{
    GameObject body;
    GameObject border;

    int coordinateX;
    int coordinateY;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initiate(int columnCount, float partitionWidth, float cameraWidth, Texture2D stageImg, GameObject boxBorder, int i, int j  )
    {
        body = new GameObject("body" + i + "_" + j);
        SpriteRenderer renderer = body.AddComponent<SpriteRenderer>();

        renderer.sprite = Sprite.Create(stageImg, new Rect(i * partitionWidth * 100, (columnCount - 1 - j) * partitionWidth * 100, partitionWidth * 100, partitionWidth * 100), new Vector2(0.5f, 0.5f), 100.0f);
        GameObject border = Instantiate(boxBorder);
        border.transform.parent = body.transform;
        SpriteRenderer borderRenderer = border.GetComponent<SpriteRenderer>();
        borderRenderer.sortingOrder = 1;
        borderRenderer.size = new Vector2(partitionWidth, partitionWidth);

        BoxCollider2D boxCollider2D = body.AddComponent<BoxCollider2D>();
        boxCollider2D.size = new Vector2(partitionWidth, partitionWidth);

        body.transform.position = new Vector2(-1 * cameraWidth / 2 + partitionWidth / 2 + i * partitionWidth, 2 - j * partitionWidth);





        coordinateX = i;
        coordinateY = j;

    }

    void MoveToEmptySlot()
    {

    }

    bool IsNearEmptySlot(int x, int y)
    {

    }



}
