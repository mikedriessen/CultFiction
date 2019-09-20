
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class LagCamera : MonoBehaviour
{    
    public float rotateSpeed = 90.0f;

    public bool usedFixedUpdate = true;

    private Transform target;
    private Vector3 startOffset;

    private void Start()
    {
        target = transform.parent;

        if (target == null)
            Debug.LogWarning(name + ": Lag Camera will not function correctly without a target.");
        if (transform.parent == null)
            Debug.LogWarning(name + ": Lag Camera will not function correctly without a parent to derive the initial offset from.");

        startOffset = transform.localPosition;
        transform.SetParent(null);
    }

    private void Update()
    {
        if (!usedFixedUpdate)
            UpdateCamera();
    }

    private void FixedUpdate()
    {
        if (usedFixedUpdate)
            UpdateCamera();
    }

    private void UpdateCamera()
    {
        if (target != null)
        {
            transform.position = target.TransformPoint(startOffset);
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, rotateSpeed * Time.deltaTime);
        }
    }
}
