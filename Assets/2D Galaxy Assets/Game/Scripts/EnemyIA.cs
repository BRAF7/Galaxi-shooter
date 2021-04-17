using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyIA : MonoBehaviour
{
    [SerializeField]
    private float speed= 3f;
    [SerializeField]
    private GameObject animation_prefab;
    private IU_manager _uiManager;
    [SerializeField]
    private AudioClip _clip;
    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<IU_manager>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    private void movement()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y < -5)
        {   
            transform.position = new Vector3 (Random.Range(-5, 5), 5.46f, 0); 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.restantLife();
            //Destroy(this.gameObject);
        }
        else if(other.tag == "Laser")
        {
            if(transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
        Instantiate(animation_prefab, transform.position, Quaternion.identity);
        _uiManager.update_score();
        AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position);
        Destroy(this.gameObject);
    }
}
