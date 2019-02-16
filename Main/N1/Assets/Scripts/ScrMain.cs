﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrMain : MonoBehaviour
{

    public int partitionColumnCount;
    public GameObject[,] partitions = new GameObject[4,4];    
    public Texture2D stageImage;


    private void Awake()
    {
        //Screen.SetResolution(900, 1600, false);
    }

    // Start is called before the first frame update
    void Start()
    {

        //Camera.main.orthographicSize = Screen.height / (100.0f * 2.0f);
        partitionColumnCount = 4;        
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
            Debug.Log(Screen.currentResolution);
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
        float partitionWidth = (Camera.main.orthographicSize * 2 / Screen.height * Screen.width)*100 / ColumnCount;
        float cameraWidth = (Camera.main.orthographicSize * 2 / Screen.height * Screen.width);

        for (int i=0; i < ColumnCount; i++)
        {
            for (int j = 0; j < ColumnCount; j++)
            {
                partitions[i, j] = new GameObject("partition" + i + "_" + j);
                SpriteRenderer renderer = partitions[i, j].AddComponent<SpriteRenderer>();
                renderer.sprite = Sprite.Create(stageImage, new Rect(0,0, partitionWidth, partitionWidth), new Vector2(0.5f, 0.5f), 100.0f);
                //partitions[i, j].transform.position = new Vector2(-1 * ColumnCount / 2 * partitionWidth + partitionWidth / 2 + i * partitionWidth, +1 * ColumnCount / 2 * partitionWidth - partitionWidth / 2 - j * partitionWidth);
                partitions[i, j].transform.position = new Vector2(-1*cameraWidth/2  +  i * partitionWidth, 1  - j* partitionWidth);

            }
        }

    }



}
