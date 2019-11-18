using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float speed;

    private Transform player;

    private Vector2 target;
    public GameObject effect;

    public bool follow;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (follow)
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        else
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log(other.tag.ToString());
        if (other.gameObject.tag != "Ladder" && other.tag != "Coin" && other.tag != "Enemy")
        {
            // Instantiate(onHitEffect, transform.position, transform.rotation);
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }

    }
}
