using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrMain : MonoBehaviour
{

    public int partitionColumnCount;
    public ScrPartition[,] partitions = new ScrPartition[4, 4];
    // public GameObject[,] partitions = new GameObject[4,4];    
    public Texture2D stageImage;    
    public GameObject boxBorder;

    ScrEmptySlot emptySlot= new ScrEmptySlot();



    // Start is called before the first frame update
    void Start()
    {
        CreatePartition(partitionColumnCount);
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
                Debug.Log("I'm hitting " + hit.collider.name);

            }
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(Screen.width + ", " + Screen.height);
            Debug.Log((Camera.main.orthographicSize * 2 / Screen.height * Screen.width) );
        }
    }

    void CreatePartition (int ColumnCount)
    {
        float partitionWidth = (Camera.main.orthographicSize * 2 / Screen.height * Screen.width) / ColumnCount;
        float cameraWidth = (Camera.main.orthographicSize * 2 / Screen.height * Screen.width);

        for (int i=0; i < ColumnCount; i++)
        {
            for (int j = 0; j < ColumnCount; j++)
            {
                //partitions[i, j] = new GameObject("partition" + i + "_" + j);
                //partitions[i, j].gameObject = new GameObject("partition" + i + "_" + j);
                partitions[i,j].ab
                partitions[i, j].abcX = new GameObject("partition" + i + "_" + j);
                SpriteRenderer renderer = partitions[i, j].AddComponent<SpriteRenderer>();
                renderer.sprite = Sprite.Create(stageImage, new Rect(i * partitionWidth * 100, (ColumnCount -1 - j) * partitionWidth * 100, partitionWidth*100, partitionWidth*100), new Vector2(0.5f, 0.5f), 100.0f);
                    GameObject border = Instantiate(boxBorder);
                    border.transform.parent = partitions[i,j].transform;
                    SpriteRenderer borderRenderer = border.GetComponent<SpriteRenderer>();
                    borderRenderer.sortingOrder = 1;
                    borderRenderer.size = new Vector2(partitionWidth, partitionWidth);

                BoxCollider2D boxCollider2D = partitions[i, j].AddComponent<BoxCollider2D>();
                boxCollider2D.size = new Vector2(partitionWidth, partitionWidth);



                // SpriteRenderer rendererBorder = partitions[i, j].AddComponent<SpriteRenderer>();
                // renderer.sprite = Sprite.Create(borderImage, new Rect(0, 0, borderImage.width, borderImage.width), new Vector2(0.5f, 0.5f), 100.0f);
                partitions[i, j].transform.position = new Vector2(-1*cameraWidth/2  + partitionWidth/2+ i * partitionWidth, 2  - j* partitionWidth);

            }
        }
        Destroy(partitions[ColumnCount-1, ColumnCount-1]);

        // 확인 필요
        /*
        emptySlot.emptyX = ColumnCount - 1;
        emptySlot.emptyY = ColumnCount - 1;
        */
        emptySlot.SetEmptySlot(ColumnCount - 1, ColumnCount - 1);

    }



}
