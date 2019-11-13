using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AStarBirdController : MonoBehaviour
{

    public AIPath aiPath;

    // Update is called once per frame
    void Update()
    {
        // the velocity that the enemy bird would like the travel with
        if (aiPath.desiredVelocity.x >= 0.01f)
            // transform.eulerAngles = new Vector3(transform.position.x, 180, transform.position.z);
            transform.eulerAngles = new Vector3(0, 180, 0);
        else if (aiPath.desiredVelocity.x <= -0.01f)
            transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
