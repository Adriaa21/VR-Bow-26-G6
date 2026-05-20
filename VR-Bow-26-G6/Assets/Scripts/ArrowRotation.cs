using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ArrowRotation : MonoBehaviour
{
    [SerializeField] private float rotSpeed = 1f;
    [SerializeField] private Rigidbody rb;

    private void FixedUpdate()
    {
        transform.forward = Vector3.Slerp(transform.forward, rb.linearVelocity.normalized, Time.deltaTime*rotSpeed);
    }

}
