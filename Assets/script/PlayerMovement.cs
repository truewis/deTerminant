using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    [Range(0f, 10f)] [SerializeField] private float m_TurnSpeed = 1.5f;   // How fast the rig will rotate from user input.
    [SerializeField] private float m_TurnSmoothing = 0.0f;     // How much smoothing to apply to the turn input, to reduce mouse-turn jerkiness
    [SerializeField] private float m_PhiMax = 50f;                       // The maximum value of the y axis rotation of the rig.
    private GameObject FPcamera;
    private Animator A1;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        A1 = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        FPcamera = GameObject.Find("PlayerPointCameraRig");

    }
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Turning();



        Move(h, v);
    }

    void Move(float h, float v)
    {
        Vector3 movement = new Vector3(h, 0f, v);
        Quaternion forw = Quaternion.LookRotation(transform.forward);
        movement = forw * movement;
        movement = movement.normalized * speed * Time.deltaTime;
        Debug.Log(movement);
        playerRigidbody.MovePosition(transform.position + movement);
        if (v >= 0)
        {
            A1.SetFloat("Speed", (h == 0 && v == 0) ? 0 : speed);
            A1.SetFloat("Direction",h);
        }
        if (v < 0)
        {
            A1.SetFloat("Speed",  -speed);
            A1.SetFloat("Direction", 0);
        }

    }

    void Turning()
    {
        Quaternion rot = Quaternion.LookRotation(FPcamera.transform.forward);
        playerRigidbody.rotation = Quaternion.Euler(0, rot.eulerAngles.y, 0);
       
    }


}
