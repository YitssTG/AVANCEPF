using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject objective;
    public float minXPosition;
    public float maxXPosition;
    public float minYPosition;
    public float maxYPosition;
    void Start()
    {
        
    }

    void Update()
    {
        if (objective != null)
        {
            float positionX = Mathf.Clamp(objective.transform.position.x, minXPosition,maxXPosition);
            float positionY = Mathf.Clamp(objective.transform.position.y, minYPosition, maxYPosition);
            transform.position = new Vector3(positionX, positionY, -10);
        }       
    }
}
