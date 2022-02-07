using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Head")
        {
            Destroy(gameObject);
        }
    }*/


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Head")
        {
            //Destroy(gameObject);
            MoveFood();
        }
    }

    public void MoveFood()
    {

        transform.position = new Vector2(-2, 3);
    }



}
