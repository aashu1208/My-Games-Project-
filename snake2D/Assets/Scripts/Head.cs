using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Head : MonoBehaviour
{

    public float speed = 3f;
    
    public Vector2 direction; //= Vector2.right;

    public GameObject tail;

    public List<Transform> tailPositions;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        //sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ChangeDirection();
    }

    public void Move()
    {
        Vector2 lastPos = transform.position;



        
        transform.Translate(direction * speed * Time.deltaTime);


        if (tailPositions.Count >= 1)
        {
            tailPositions.Last().position = lastPos;
            tailPositions.Insert(0, tailPositions.Last());
            tailPositions.RemoveAt(tailPositions.Count - 1);
        }
        

        
    }

    public void ChangeDirection()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector2.up;
            sr.transform.eulerAngles = new Vector3(0, 0, -270);
            
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector2.down;

            sr.transform.eulerAngles = new Vector3(0, 0, -90);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector2.left;

            sr.transform.eulerAngles = new Vector3(0, 0, -180);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector2.right;

            sr.transform.eulerAngles = new Vector3(0, 0, 0);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 spawnPos = new Vector2(10, 10);
        if (collision.tag == "Food")
        {
            GameObject newTail = Instantiate(tail, spawnPos, Quaternion.identity) as GameObject;
            newTail.transform.parent = GameObject.Find("Tail Holder").transform;
            tailPositions.Add(newTail.transform);
        }
    }
}
