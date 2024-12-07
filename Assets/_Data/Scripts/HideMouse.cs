using UnityEngine;

public class HideMouse : MonoBehaviour
{
    [SerializeField] protected bool isVisible = false;

    void Start()
    {
        this.CursorStatus(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) this.ToggleCursor();
    }

    protected virtual void ToggleCursor()
    {
        this.isVisible = !this.isVisible;
        this.CursorStatus(this.isVisible);
    }

    protected virtual void CursorStatus(bool status)
    {

        Cursor.visible = this.isVisible;
        if(this.isVisible) Cursor.lockState = CursorLockMode.None;
        else Cursor.lockState = CursorLockMode.Locked;
    }
}
