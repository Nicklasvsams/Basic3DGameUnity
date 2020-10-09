using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    private Vector3 camOffset = new Vector3(0, 3f, -4);

    // Update is called once per frame
    void Update()
    {
        transform.position = rb.position + camOffset;
    }
}
