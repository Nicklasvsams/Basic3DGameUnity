using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    public Rigidbody enemyBody;

    [SerializeField]
    private Transform[] waypoints;
    
    [SerializeField]
    [Range(0f, 1f)]
    private float moveSpeed;

    private Vector3 targetPosition;

    private int waypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = waypoints[0].position;
        enemyBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (enemyBody.position.x > 9 || enemyBody.position.x < -9)
        //{
        //    movementVector *= -1;
        //}

        //enemyBody.velocity = movementVector;
        //transform.Rotate(0, 500 * Time.deltaTime, 0);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.1f + moveSpeed);

        if (Vector3.Distance(transform.position, targetPosition) < .25f)
        {
            if (waypointIndex >= waypoints.Length - 1)
            {
                waypointIndex = 0;
            }
            else
            {
                waypointIndex++;
            }
            targetPosition = waypoints[waypointIndex].position;
        }
    }
}
