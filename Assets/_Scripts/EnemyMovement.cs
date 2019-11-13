using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed;
    public float startDazedTime;
    private float dazedTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dazedTime <= 0)
            speed = 5;
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void TakeDemage()
    {
        dazedTime = startDazedTime;
    }
}
