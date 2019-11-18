using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeMovement : MonoBehaviour
{
    public float speed;                 // speed of moving
    public float stoppingDistance;      // higher the number, the further the enemy will stop away from the player
    public float retreatDistance;       // when the enemy should back away from the target (player)

    private Transform player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // if the ememy is too far away, move closer to the player
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        // if its near enough but not too near, simply stop moving
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            transform.position = this.transform.position;
        // too near the player, back away
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);

    }
}
