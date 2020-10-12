using UnityEngine;

public class GameMenu : MonoBehaviour
{
    private GameObject menu;
    [SerializeField]
    private GameObject camera;
    private ThirdPersonCameraController cameraComponent;
    private bool lockCursor;

    // Start is called before the first frame update
    void Start()
    {
        lockCursor = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        menu = transform.GetChild(0).gameObject;
        cameraComponent = camera.GetComponent<ThirdPersonCameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            ToggleMenu();
        }        
    }

    public void ToggleMenu()
    {
        menu.SetActive(!menu.activeSelf);
        cameraComponent.enabled = !cameraComponent.enabled;
        lockCursor = !lockCursor;
        Cursor.lockState = lockCursor ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = lockCursor;
    }
}
