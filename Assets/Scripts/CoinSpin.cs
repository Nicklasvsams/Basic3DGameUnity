using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    [SerializeField]
    private Transform waypoint;

    [SerializeField]
    [Range(0, 10)]
    private float moveSpeed;

    [SerializeField]
    [Range(0, 1000)]
    private float spinSpeed;

    public bool isCollected;

    // Update is called once per frame
    void Update()
    {
        if (isCollected)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoint.position, (0.1f + moveSpeed) * Time.deltaTime);

            
        }
        else
        {
            if (tag == "Finish")
            {
                transform.Rotate(spinSpeed * Time.deltaTime, spinSpeed * Time.deltaTime, spinSpeed * Time.deltaTime);
            }
            else
            {
                transform.Rotate(spinSpeed * Time.deltaTime, 0, 0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CoinPoint"))
        {
            Destroy(this.gameObject);
        }
    }
}
