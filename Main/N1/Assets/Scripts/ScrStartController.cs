﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrStartController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            SceneManager.LoadScene(1);
        }
        if(Input.GetMouseButton(0))
        {
            SceneManager.LoadScene(1);
        }
    }
}
