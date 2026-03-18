using UnityEngine;
using UnityEngine.Splines;

public class XRSplineMover : MonoBehaviour
{
    public SplineContainer spline;

    [Range(0f, 1f)]
    public float spotOnSpline; // position on spline (0 → 1)

    public float speed = 0.1f;
    public float heightOffset = 0.1f;

    void LateUpdate()
    {
        // Input (W/S or joystick based on the input action map)
        float input = Input.GetAxis("Vertical");
        float currentSpeed = Mathf.Lerp(0, speed, Mathf.Abs(input));
        spotOnSpline += Mathf.Sign(input) * currentSpeed * Time.deltaTime;
        spotOnSpline = Mathf.Clamp01(spotOnSpline);

        // Get position from spline
        Vector3 position = spline.EvaluatePosition(spotOnSpline);

        // Apply position only — rotation is left untouched
        transform.position = position + Vector3.up * heightOffset;


    }
}