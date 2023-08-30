using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollowPlayer : MonoBehaviour
{
    public Transform camPos;
    public Transform background;

    void Update()
    {
        Vector3 newPosition = background.position;
        newPosition.x = camPos.position.x;
        newPosition.y = camPos.position.y;
        background.position = newPosition;
    }
}
