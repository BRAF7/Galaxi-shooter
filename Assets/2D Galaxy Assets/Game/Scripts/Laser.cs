using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{   
    public float speed = 10f;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        laserMovement();
        destroyLaser();
    }

    public void laserMovement()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public void destroyLaser()
    {
        if(transform.position.y > 5.5)
        {
            if(transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
            
        }
    }
}
