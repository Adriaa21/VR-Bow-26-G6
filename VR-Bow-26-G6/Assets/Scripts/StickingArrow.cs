using System;
using UnityEngine;

public class StickingArrow : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private SphereCollider sc;

    [SerializeField] private GameObject stickingPrefab;

    private void OnCollisionEnter(Collision other)
    {
        rb.isKinematic = true;
        sc.isTrigger = true;
        
        GameObject sticking = Instantiate(stickingPrefab, transform.position, transform.rotation);

        if (other.rigidbody)
        {
            sticking.transform.SetParent(other.rigidbody.transform);
            sticking.transform.localScale = Vector3.one;
        }

        other.collider.GetComponent<IHittable>()?.GetHit();
        Destroy(gameObject);
    }
}
