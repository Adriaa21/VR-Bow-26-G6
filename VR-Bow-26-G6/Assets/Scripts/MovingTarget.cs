using System;
using UnityEngine;


public interface IHittable
{
    public void GetHit();
}

[RequireComponent(typeof(Rigidbody))]
public class MovingTarget : MonoBehaviour, IHittable
{
    [SerializeField] private int health = 1;
    [SerializeField] private float ArriveThreshold, MovementRadius = 2, Speed = 1;
    [SerializeField] private BoxCollider _movementArea;

    private Rigidbody _rb;
    private bool _stopped;
    private Vector3 _origin, _nextPos;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        
        _origin = _rb.transform.position;
        _nextPos = GetNextPos();

        if (ArriveThreshold == 0)
        {
            ArriveThreshold = Time.deltaTime * Speed;
        }
    }

    private Vector3 GetNextPos()
    {
        if (!_movementArea) return _origin + (Vector3)UnityEngine.Random.insideUnitCircle * MovementRadius;
        Bounds b = _movementArea.bounds;

        return new Vector3(
            UnityEngine.Random.Range(b.min.x, b.max.x),
            UnityEngine.Random.Range(b.min.y, b.max.y),
            UnityEngine.Random.Range(b.min.z, b.max.z)
        );
    }

    public void GetHit()
    {
        health--;
        if (health <=0)
        {
            _rb.isKinematic = false;
            _stopped = true;
            
            
        }
    }

    private void ResetTarget()
    {
        if (_stopped == true)
        {
            
        }
    }

    private void FixedUpdate()
    {
        if (_stopped) return;
        var pos = transform.position;
        if (Vector3.Distance(pos, _nextPos) < ArriveThreshold)
        {
            _nextPos = GetNextPos();
        }

        Vector3 dir = _nextPos - pos;
        _rb.MovePosition(pos + Speed * Time.deltaTime * dir.normalized);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        if (!_movementArea)
        {
            Gizmos.DrawWireSphere(_origin, MovementRadius);
        }
        else
        {
            Gizmos.DrawWireCube(_movementArea.bounds.center, _movementArea.bounds.size);
        }

        if (_nextPos != Vector3.zero)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, _nextPos);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_nextPos, 1f);
                
        }
    }
}
