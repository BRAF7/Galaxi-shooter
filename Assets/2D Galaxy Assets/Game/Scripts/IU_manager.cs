using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IU_manager : MonoBehaviour
{
    public Sprite[] lives;
    public Image image_lives;
    public int score;
    public Text scoreText;
    public GameObject main_menu;
    public bool menu;
    private Spawn_manager spawn_manager;

    public void update_live(int current_lives)
    {   
        image_lives.sprite = lives[current_lives];
    }

    public void update_score()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }

    public void hide_main_menu()
    {
        main_menu.SetActive(false);
    }

    public void show_main_menu()
    {
        main_menu.SetActive(true);
        scoreText.text = "Score: ";
        spawn_manager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_manager>(); 
        score = 0;
    }
}
