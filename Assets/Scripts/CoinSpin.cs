using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    private Quaternion spinSpeed = new Quaternion(0, 1, 0, 0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(500 * Time.deltaTime, 0, 0);
    }
}
