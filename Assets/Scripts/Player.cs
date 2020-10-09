using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public Rigidbody playerBody;

    private Vector3 inputVector;

    private bool jump;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * 250, playerBody.velocity.y, Input.GetAxis("Vertical") * Time.deltaTime * 250);
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }


    void FixedUpdate()
    {
        playerBody.velocity = inputVector;

        if (jump && IsGrounded())
        {
            print("Jump activated!");
            playerBody.AddForce(Vector3.up * Time.deltaTime * 200f, ForceMode.Impulse);
            jump = false;
        }
    }

    bool IsGrounded()
    {
        float distance = GetComponent<Collider>().bounds.extents.y + 0.01f;
        Ray ray = new Ray(transform.position, Vector3.down);

        return Physics.Raycast(ray, distance);
    }
}
