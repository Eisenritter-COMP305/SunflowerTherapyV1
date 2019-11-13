using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class EnemyController : MonoBehaviour
{
    public float health = 100;

    public GameObject effect;
    public GameObject blood;

    public SpriteRenderer[] bodyParts;
    public Color hurtColor;

    public bool shakeCamera;

    public void TakeDemage(float demage)
    {
        StartCoroutine(Flash());
        FindObjectOfType<AudioManager>().Play("EnemyHit");
        EnemyMovement movement = GetComponent<EnemyMovement>();
        if (movement != null) movement.TakeDemage();


        health -= demage;
        if (health <= 0)
        {
            Die();
            return;
        }

        // shake the cemera
        if (shakeCamera)
        {
            GetComponent<CameraShake>().Shake();
        }
    }


    IEnumerator Flash()
    {
        for (int i = 0; i < bodyParts.Length; i++)
            bodyParts[i].color = hurtColor;
        yield return new WaitForSeconds(0.05f);
        for (int i = 0; i < bodyParts.Length; i++)
            bodyParts[i].color = Color.white;
    }

    void Die()
    {
        FindObjectOfType<GameController>().Hp += 5;
        FindObjectOfType<GameController>().Mp += 5;
        FindObjectOfType<AudioManager>().Play("EnemyDeath");
        Instantiate(effect, transform.position, Quaternion.identity);
        Instantiate(blood, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
