using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver = true;
    public GameObject player;
    private IU_manager ui_manager;

    private void Start()
    {
        ui_manager = GameObject.Find("Canvas").GetComponent<IU_manager>();
    }

    void Update()
    {
        if(gameOver)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(player, Vector3.zero, Quaternion.identity); 
                gameOver = false;   
                ui_manager.hide_main_menu();
            }
        }
    }
}
