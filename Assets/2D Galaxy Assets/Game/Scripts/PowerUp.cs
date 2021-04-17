using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private int power_id; // shot = 0, speed = 1, shield = 2
    [SerializeField]
    private AudioClip _clip;

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {    
            Player player = other.GetComponent<Player>();       
            if (player != null)
            {
                player.powerUpOn(power_id);
                AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position);
                Destroy(this.gameObject); 
            }
        }
       
    }

    private void movement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if(transform.position.y < -5)
        {   
            Destroy(this.gameObject);
        }
    }
}
