using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_manager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy_prefab;
    [SerializeField]
    private GameObject [] _power_ups;
    private GameManager _gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }


    public void StartCoroutine()
    {
        StartCoroutine(generateEnemy());
        StartCoroutine(generatePowerUp());
    }
    public IEnumerator generateEnemy()
    {
        while(_gameManager.gameOver == false)
        {
            Instantiate(_enemy_prefab, new Vector3 (Random.Range(-5, 5), 5.46f, 0), Quaternion.identity);
            yield return new WaitForSeconds(7);
        }
    }

    public IEnumerator generatePowerUp()
    {
        while(_gameManager.gameOver == false)
        {
            int randomPower = Random.Range(0,3);
            Instantiate(_power_ups[randomPower], new Vector3(Random.Range(-5, 5), 5.46f, 0), Quaternion.identity);
            yield return new WaitForSeconds(15);
        }
    }

}
