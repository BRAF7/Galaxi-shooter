using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    public bool canTripleShoot = false;

    [SerializeField]
    private GameObject laserPrefab;

    [SerializeField]
    private GameObject _triplePrefab;

    [SerializeField]
    private float speed = 5.0f;
    
    [SerializeField]
    private float fireRate = 0.25f;
    private float canFire = 0.0f;
    public int life = 3;
    private bool _shield = false;
    [SerializeField]
    private GameObject _animation_prefab;
    [SerializeField]
    private GameObject _animation_shield;
    [SerializeField]
    private GameObject[] _engine; 
    // Start is called before the first frame update
    private IU_manager _uiManager;
    private GameManager _gameManager;
    private AudioSource _audioSource;
    private int random;
    private bool flag_random;
    private Spawn_manager _spawnManager;
    void Start()
    {
      transform.position = new Vector3 (0,0,0);
      _uiManager = GameObject.Find("Canvas").GetComponent<IU_manager>();
      _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
      _audioSource = GetComponent<AudioSource>();
      flag_random = false;
      life = 3;
      _uiManager.update_live(life);
      _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_manager>();
      _spawnManager.StartCoroutine();
    }

    // Update is called once per frame
    void Update()
    {
      movement();
        if(Time.time > canFire)
        {
          fire();
        }

    }

    public void fire()
    {
      if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
      {
        if(!canTripleShoot){
          Instantiate(laserPrefab,transform.position + new Vector3(0, .88f, 0), Quaternion.identity);       
        }
        else
        {
          Instantiate(_triplePrefab, transform.position, Quaternion.identity);
        }
        canFire = Time.time + fireRate;
        _audioSource.Play();
      }
    } 

    private void movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        if (transform.position.x < -8.26)
        {
          transform.position = new Vector3(-8.26f, transform.position.y,0);
        }
        else if(transform.position.x > 8.26)
        {
          transform.position = new Vector3 (8.26f, transform.position.y,0);
        }
        if(transform.position.y < -4.35)
        {
          transform.position = new Vector3 (transform.position.x, -4.35f,0);
        }
        else if(transform.position.y > 4.2)
        {
          transform.position = new Vector3 (transform.position.x, 4.2f,0);
        }
    }

    public void powerUpOn(int power_id)
    {
      switch (power_id)
      {
        case 0:
          canTripleShoot = true;
          break;

        case 1:
          speed= speed + 5;
          break;
      }
      StartCoroutine(coldDown(power_id));
      if(power_id == 2)
      {
        _animation_shield.SetActive(true);
        _shield = true;
      }
    }

    public IEnumerator coldDown(int power_id)
    {
      yield return new WaitForSeconds(5);
      if(power_id == 0)
      {
        canTripleShoot = false;
      }
      else if(power_id == 1)
      {
        speed= speed - 5;
      }
    }

    public void restantLife()
    {
      if(_shield)
      {
        _shield = false;
        _animation_shield.SetActive(false);
      }
      else
      {
        life--;
          if(_uiManager != null)
        {
          _uiManager.update_live(life);
        }
        if(flag_random)
      {
        if(random == 1)
        {
          _engine[0].SetActive(true);
        }
        else
        {
          _engine[1].SetActive(true);
        }
      }
      else
      {
        this.random = Random.Range(0,2);
        _engine[this.random].SetActive(true);
        flag_random = true;
      }
      }
      if(life == 0)
      {
        Instantiate(_animation_prefab, transform.position, Quaternion.identity);
        _uiManager.show_main_menu();
        _gameManager.gameOver = true;
        Destroy(this.gameObject);
      }
    }
}
