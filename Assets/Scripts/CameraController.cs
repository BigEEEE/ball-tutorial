using System;

using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Transform pivotX;
    public float camSpeed;
    private float angleX;
    private float angleY;
    private float currentX;
    private float currentY;

    private Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - player.transform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

        float mHorizontal = Input.GetAxis("Mouse X") * camSpeed;
     
        transform.Rotate(0, mHorizontal, 0);
 

    }
}
