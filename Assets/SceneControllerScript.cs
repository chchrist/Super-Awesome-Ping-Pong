﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControllerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {

        new GameSparks.Api.Requests.DeviceAuthenticationRequest()
        .SetDisplayName("Tolis")
        .Send((response) =>
        {
            if(!response.HasErrors)
            {
                SceneManager.LoadScene("GameScene");
            }
        });

    }
}
