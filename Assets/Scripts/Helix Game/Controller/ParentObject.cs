using UnityEngine;

public class ParentObject : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private float speed;
    [SerializeField] private float touchSpeed;
    
    private float moveX;
    private void FixedUpdate() 
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            KeyboardControl();
            
        TouchController();
    }
    void KeyboardControl()
    {
        moveX = Input.GetAxis("Mouse X");

        transform.Rotate(0,moveX * Time.deltaTime * speed,0);
    }
    void TouchController()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                float dpiFactor = Screen.dpi / 160f;
                float normalizedDelta = (touch.deltaPosition.x / Screen.width) * dpiFactor * 100f; 
                float xRotation = normalizedDelta * touchSpeed * Time.unscaledDeltaTime;
                transform.Rotate(0,xRotation,0, Space.Self);
            }
        }
    }
}
