using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrMain : MonoBehaviour
{

    public int partitionColumnCount;
    public GameObject[,] partitions = new GameObject[4,4];    
    public Texture2D stageImage;


    // Start is called before the first frame update
    void Start()
    {
        partitionColumnCount = 4;        
        CreatePartition(partitionColumnCount);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreatePartition (int ColumnCount)
    {
        int partitionWidth = Screen.width / ColumnCount;
        

        for (int i=0; i < ColumnCount; i++)
        {
            for (int j = 0; j < ColumnCount; j++)
            {
                partitions[i, j] = new GameObject("partition" + i + "_" + j);
                SpriteRenderer renderer = partitions[i, j].AddComponent<SpriteRenderer>();
                renderer.sprite = Sprite.Create(stageImage, new Rect(0,0,partitionWidth, partitionWidth), new Vector2(0.5f, 0.5f), 100.0f);
                //partitions[i, j].transform.position = new Vector2(-1 * ColumnCount / 2 * partitionWidth + partitionWidth / 2 + i * partitionWidth, +1 * ColumnCount / 2 * partitionWidth - partitionWidth / 2 - j * partitionWidth);
                partitions[i, j].transform.position = new Vector2(-1  +  i  , 1  - j);

            }
        }

    }



}
