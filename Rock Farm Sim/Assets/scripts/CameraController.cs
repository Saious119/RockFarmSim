using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform lookAt;
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        float deltaX = lookAt.position.x - transform.position.x;
        float deltaY = lookAt.position.y - transform.position.y;
        if(deltaX > boundX || deltaX < -boundX)
        {
            delta.x = 0;
        }
        if(deltaY > boundY || deltaY < -boundY)
        {
            deltaX = 0;
        }
        transform.position += new Vector3(deltaX, deltaY, 0);
    }
}
