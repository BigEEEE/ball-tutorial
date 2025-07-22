using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    private int count;

    private Rigidbody rb;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public Camera mainCam;

    private float movementX;
    private float movementY;
    void Start()
    {

        count = 0;

        rb = GetComponent<Rigidbody>();

        winTextObject.SetActive(false);
        SetCountText();
    }

    private void FixedUpdate()
    {
        Vector3 camForward = mainCam.transform.forward;
        Vector3 camRight = mainCam.transform.right;


        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        //project forward and right vectors on the horizontal plane (y = 0)
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();


        Vector3 desiredMoveDirection = camForward * verticalAxis + camRight * horizontalAxis;


        rb.AddForce(desiredMoveDirection * speed);
    }
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("PickUp"))
            {
                other.gameObject.SetActive(false);
                count = count + 1;
                SetCountText();
            }
        }
    


    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 14) 
        {
            winTextObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
    }
}
