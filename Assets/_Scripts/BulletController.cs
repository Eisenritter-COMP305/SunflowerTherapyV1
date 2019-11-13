using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 20f;
    public int demage = 40;
    public Rigidbody2D rb;
    public GameObject effect;
    // private bool playEffect;
    // public GameObject onHitEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log(other.tag.ToString());
        if (other.gameObject.tag != "Ladder" && other.tag != "Coin")
        {
            // Instantiate(onHitEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
        }



        if (other.tag == "Enemy")
            other.GetComponent<EnemyController>().TakeDemage(demage);





    }

}
