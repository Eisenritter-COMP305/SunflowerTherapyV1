using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class MoveablePlatform : MonoBehaviour
{
    [CanBeNull] public Transform destinationT;
    public Vector2 destPosition;
    public float speedmult;

    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position,destPosition,Time.deltaTime*speedmult);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

        }
    }


}
