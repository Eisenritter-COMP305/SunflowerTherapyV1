using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public float demage = 0.1f;

    // public GameObject impactEffect;
    public LineRenderer lineRenderer;
    private bool hit = false;

    // private Vector3 targetPosition;
    public GameController gameController;




    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) Shoot();
        else if (Input.GetButton("Fire2"))
        {
            if (gameController.Mp < 1) return;
            lineRenderer.enabled = true;
            // Render();
            // FastShoot();
            StartCoroutine(ShootFast());

        }
        else
        {
            lineRenderer.enabled = false;
        }

    }

    void Shoot ()
    {
        if (gameController.Mp < 10) return;

        gameController.Mp -= 10;
        Instantiate(bullet, firePoint.position, firePoint.rotation);



    }

    void FastShoot()
    {
        RaycastHit2D target = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (target)
        {

        }
    }

    IEnumerator ShootFast()
    {

        RaycastHit2D target = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (target)
        {
            // avoid hitting ladder
            if (target.transform.GetComponent<LadderController>())
                hit = false;
            else
                hit = true;

            EnemyController enemy = target.transform.GetComponent<EnemyController>();
            if (enemy)
            {
                enemy.TakeDemage(demage);
            }

            // create on-hit effect                     rotation
            // Instantiate(impactEffect, target.point, Quaternion.identity);

            
        }
        // render the line
        RenderLine(target);
        gameController.Mp -= 1;

        // lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.02f);

        // lineRenderer.enabled = false;





    }

    void RenderLine(RaycastHit2D target)
    {
        lineRenderer.SetPosition(0, firePoint.position);
        if (hit) lineRenderer.SetPosition(1, target.point);
        else lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
        hit = false;
    }

    //void Render()
    //{
    //    lineRenderer.SetPosition(0, firePoint.position);
    //    lineRenderer.SetPosition(1, targetPosition);
    //}
}
