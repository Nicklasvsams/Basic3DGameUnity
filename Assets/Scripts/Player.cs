using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private Game gameManager;
    private ThirdPersonCharacterController charController;
    private CoinSpin coin;
    public TextMeshProUGUI text;
    public Goal goal;

    public Rigidbody playerBody;
    public int coins;
    private bool jump;
    [SerializeField]
    [Range(2, 10)]
    private float dashSpeed;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "Coins: 0";
        playerBody = GetComponent<Rigidbody>();
        charController = GetComponent<ThirdPersonCharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetKeyDown("left shift"))
        {
            charController.speed *= dashSpeed;
        }
        else if (Input.GetKeyUp("left shift"))
        {
            charController.speed /= dashSpeed;
        }
    }


    void FixedUpdate()
    {
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.ReloadLevel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Collectable":
                coin = other.gameObject.GetComponent<CoinSpin>();
                print(coin.name);
                coins++;
                text.text = string.Format("Coins: {0}", coins);
                coin.isCollected = true;
                break;
            case "Finish":
                gameManager.LoadNextLevel();
                break;
        }
    }
}
