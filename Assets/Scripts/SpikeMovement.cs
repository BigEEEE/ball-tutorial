
using UnityEngine;
using System.Collections;

public class SpikeMovement : MonoBehaviour
{
    public float speed;
    private Vector3 startPos;
    private Vector3 endPos;

    void Start()
    {
        startPos = transform.position;
        endPos = new Vector3(startPos.x, startPos.y + 0.2f, startPos.z);

    }
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
    }
}
