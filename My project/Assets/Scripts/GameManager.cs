using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject player;
    private Rigidbody playerObject;
    public InputAction moveAction;
    public Transform level;
    private float tiltSpeed = 3f;
    private float maxTilt = 20f;
    private float groundForce = 10f;
    private float assistForce = 15f;
    private float normalFriction = 20f;
    private float iceFriction = 0.1f;
    public TextMeshProUGUI timerText;
    private int score = 0;
    public TextMeshProUGUI scoreText;
    private Vector2 input;

    private void Awake()
    {
        Instance = this;
    }
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
        playerObject = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        input = moveAction.ReadValue<Vector2>();
        // Update timer text
        float time = Time.timeSinceLevelLoad;
        timerText.text = time.ToString("F2") + "s";
        scoreText.text = "Score: " + score;
    }
    void FixedUpdate()
    {
        // // Material detection
        // RaycastHit hit;
        // bool grounded = Physics.Raycast(transform.position, Vector3.down, 1.2f);
        // if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.2f))
        // {
        //     if (hit.collider.sharedMaterial != null)
        //     {
        //         Debug.Log(hit.collider.sharedMaterial.name);
        //     }
        // }
        // // Material handling
        // if (grounded)
        // {
        //     if (hit.collider.sharedMaterial != null && hit.collider.sharedMaterial.name == "Ice Physics Material")
        //     {
        //         playerObject.linearDamping = iceFriction;
        //     }
        //     else
        //     {
        //         playerObject.linearDamping = normalFriction;
        //     }
        // }
        // else
        // {
        //     playerObject.linearDamping = 0f;
        // }

        // Level tilting
        float tiltX = input.y * maxTilt;
        float tiltZ = -input.x * maxTilt;
        Quaternion targetRotation = Quaternion.Euler(tiltX, 0, tiltZ);
        level.rotation = Quaternion.Slerp(level.rotation, targetRotation, Time.fixedDeltaTime * tiltSpeed);
        // Ball movement asisstance
        Vector3 tiltDir = Vector3.ProjectOnPlane(Vector3.down, level.up).normalized;
        playerObject.AddForce(Vector3.down * groundForce, ForceMode.Acceleration);
        if (input != Vector2.zero)
        {
            playerObject.AddForce(tiltDir * assistForce, ForceMode.Acceleration);
        }
    }
    public void AddScore(int amount)
    {
        score += amount;
    }

}
