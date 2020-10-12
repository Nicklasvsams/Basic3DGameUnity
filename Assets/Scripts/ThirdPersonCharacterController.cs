using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor * speed * Time.deltaTime, 0f, ver * speed * Time.deltaTime) ;
        transform.Translate(playerMovement, Space.Self);
    }
}
