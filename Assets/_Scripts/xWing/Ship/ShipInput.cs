
using UnityEngine;
/// Class specifically to deal with input.
public class ShipInput : MonoBehaviour
{
    public bool useMouseInput = true;
    public bool addRoll = true;

    [Space]

    [Range(-1, 1)]
    public float pitch;
    [Range(-1, 1)]
    public float yaw;
    [Range(-1, 1)]
    public float roll;
    [Range(-1, 1)]
    public float strafe;
    [Range(0, 1)]
    public float throttle;
    [Range(-1, 1)]

    private const float THROTTLE_SPEED = 0.5f;

    private Ship ship;

    private void Awake()
    {
        ship = GetComponent<Ship>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            this.transform.Rotate(0,0,3 ); 
           
        }

        if (Input.GetKey(KeyCode.E))
        {
            this.transform.Rotate(0,0,-3 ); 
        }
        if (useMouseInput)
        {
            strafe = Input.GetAxis("Horizontal");
            SetStickCommandsUsingMouse();
            UpdateMouseWheelThrottle();
            UpdateKeyboardThrottle(KeyCode.W, KeyCode.S);
        }
        else
        {            
            pitch = Input.GetAxis("Vertical");
            yaw = Input.GetAxis("Horizontal");

            if (addRoll)
                roll = -Input.GetAxis("Horizontal") * 0.5f;

            strafe = 0.0f;
            UpdateKeyboardThrottle(KeyCode.R, KeyCode.F);
        }
    }

    private void SetStickCommandsUsingMouse()
    {
        Vector3 mousePos = Input.mousePosition;
     
        pitch = (mousePos.y - (Screen.height * 0.5f)) / (Screen.height* 0.5f);
        yaw = (mousePos.x - (Screen.width * 0.5f)) / (Screen.width * 0.5f);

        pitch = -Mathf.Clamp(pitch, -1.0f, 1.0f);
        yaw = Mathf.Clamp(yaw, -1.0f, 1.0f);
    }

    private void UpdateKeyboardThrottle(KeyCode increaseKey, KeyCode decreaseKey)
    {
        float target = throttle;

        if (Input.GetKey(increaseKey))
            target = 1.0f;
        else if (Input.GetKey(decreaseKey))
            target = 0.0f;

        throttle = Mathf.MoveTowards(throttle, target, Time.deltaTime * THROTTLE_SPEED);
    }
 
    private void UpdateMouseWheelThrottle()
    {
        throttle += Input.GetAxis("Mouse ScrollWheel");
        throttle = Mathf.Clamp(throttle, 0.0f, 1.0f);
    }
}