using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public InputAction moveAction;
    public Transform level;
    public float tiltSpeed = 5f;
    // Public for testing, doesn't need to be public in final version
    public float maxTilt = 20f;
    public TextMeshProUGUI timerText;

    private Vector2 moveInput;
    void OnEnable()
    {
        moveAction.Enable();
    }
    void OnDisable()
    {
        moveAction.Disable();
    }
// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnEnable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        float tiltX = input.y * maxTilt;
        float tiltZ = -input.x * maxTilt;
        Quaternion targetRotation = Quaternion.Euler(tiltX, 0, tiltZ);
        level.rotation = Quaternion.Slerp(level.rotation, targetRotation, Time.deltaTime * tiltSpeed);
        // Update timer text
        float time = Time.timeSinceLevelLoad;
        timerText.text = "Time: " + time.ToString("F2") + "s";
        
    }
}
