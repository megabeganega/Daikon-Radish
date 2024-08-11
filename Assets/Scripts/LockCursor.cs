using UnityEngine;

public class LockCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Hides Cursor and Locks Mouse
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
