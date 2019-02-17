using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrMain : MonoBehaviour
{

    public int partitionColumnCount;
    public GameObject[,] partitions = new GameObject[4,4];    
    public Texture2D stageImage;    
    public GameObject boxBorder;   


    private void Awake()
    {
        //Screen.SetResolution(900, 1600, false);
    }

    // Start is called before the first frame update
    void Start()
    {

        //Camera.main.orthographicSize = Screen.height / (100.0f * 2.0f);
        //partitionColumnCount = 4;        
        CreatePartition(partitionColumnCount);
        Debug.Log(Screen.width + ", " + Screen.height);
        Debug.Log(Screen.currentResolution);


    }

    void ChangeResolution()
    {
        Screen.SetResolution(600, 1200, true);
        Debug.Log("Changed Resolution");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(Screen.width + ", " + Screen.height);
            Debug.Log((Camera.main.orthographicSize * 2 / Screen.height * Screen.width) );
        }
        /*
        if (Input.GetKeyDown(KeyCode.B))
        {
            ChangeResolution();

        }
        */       

    }

    void CreatePartition (int ColumnCount)
    {
        float partitionWidth = (Camera.main.orthographicSize * 2 / Screen.height * Screen.width) / ColumnCount;
        float cameraWidth = (Camera.main.orthographicSize * 2 / Screen.height * Screen.width);

        for (int i=0; i < ColumnCount; i++)
        {
            for (int j = 0; j < ColumnCount; j++)
            {
                partitions[i, j] = new GameObject("partition" + i + "_" + j);
                SpriteRenderer renderer = partitions[i, j].AddComponent<SpriteRenderer>();
                renderer.sprite = Sprite.Create(stageImage, new Rect(i * partitionWidth * 100, (ColumnCount -1 - j) * partitionWidth * 100, partitionWidth*100, partitionWidth*100), new Vector2(0.5f, 0.5f), 100.0f);
                    GameObject border = Instantiate(boxBorder);
                    border.transform.parent = partitions[i,j].transform;
                    SpriteRenderer borderRenderer = border.GetComponent<SpriteRenderer>();
                    borderRenderer.size = new Vector2(partitionWidth, partitionWidth);



                // SpriteRenderer rendererBorder = partitions[i, j].AddComponent<SpriteRenderer>();
                // renderer.sprite = Sprite.Create(borderImage, new Rect(0, 0, borderImage.width, borderImage.width), new Vector2(0.5f, 0.5f), 100.0f);
                partitions[i, j].transform.position = new Vector2(-1*cameraWidth/2  + partitionWidth/2+ i * partitionWidth, 2  - j* partitionWidth);

            }
        }
        Destroy(partitions[ColumnCount-1, ColumnCount-1]);

        // 확인 필요
        // ScrEmptySlot.SetEmptySlot(ColumnCount - 1, ColumnCount - 1);

    }



}
