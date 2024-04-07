using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
    }
}
