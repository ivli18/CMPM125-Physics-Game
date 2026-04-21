using UnityEngine;

public class BallAssistController: MonoBehaviour
{
    [SerializeField] private Rigidbody ballRb;
    [SerializeField] private Transform stageTransform;

    [Header("Assist")]
    [SerializeField] private float assistAcceleration = 8f;
    [SerializeField] private float maxAssistSpeed = 12f;
    [SerializeField] private AnimationCurve assistBySpeed =
        AnimationCurve.Linear(0f, 1f, 1f, 0f);
    
    void Reset()
    {
        ballRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (ballRb == null || stageTransform == null) return;

        // Directoin of downhill movement along the stage surface
        Vector3 downhillDirection = Vector3.ProjectOnPlane(
            stageTransform.up, Vector3.down).normalized;

        if (downhillDirection.sqrMagnitude < 0.0001f) return;

        downhillDirection = downhillDirection.normalized;

        // Only calculate horizontal/surface speed for the assist logic.
        Vector3 horizontalVelocity = Vector3.ProjectOnPlane(
            ballRb.linearVelocity, stageTransform.up);
        
        // Normalized speed against assist cuttoff.
        float speedRatio = Mathf.Clamp01(horizontalVelocity.magnitude / maxAssistSpeed);

        // At low speed, stronger assist. At high speed, weaker assist.
        float assistStrength = assistBySpeed.Evaluate(speedRatio);

        ballRb.AddForce(downhillDirection * assistAcceleration * assistStrength, ForceMode.Acceleration);
    }


}