using UnityEngine;

public class MoveWall : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    [Range(0, 100)]
    private float doorSpeed;
    private float targetPosition;

    private void Start()
    {
        targetPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.coins == 10)
        {
            print(transform.position.y);
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(transform.position.x, targetPosition + 4f, transform.position.z), 0.1f + doorSpeed);
        }
    }
}
