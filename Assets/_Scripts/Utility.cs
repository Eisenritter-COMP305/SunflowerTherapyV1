/*****************************
* CREATED BY: George Zhou   *
* LAST MODIFIED: 11/11/2019 *
*****************************/

//This script contains common utility properties
using UnityEngine;

namespace Util
{
    [System.Serializable]
    public class Speed
    {
        [Header("X")]
        [Range(-10f,10.0f)]
        public float xmin=0;
        [Range(-10f, 10.0f)]
        public float xmax=0;
        [Header("Y")]
        [Range(-10f, 10.0f)]
        public float ymin = 0;
        [Range(-10f, 10.0f)]
        public float ymax = 0;

        public bool randomized;
        public float XSpeed
        {
            get
            {
                return randomized ? Random.Range(xmin, xmax) : xmin;
            }
        }
        public float YSpeed
        {
            get
            {
                return randomized ? Random.Range(ymin, ymax) : ymin;
            }
        }
    }
    public enum Direction
    {
        ZERO,
        LEFT,
        RIGHT,
        UP,
        DOWN
    }
}

