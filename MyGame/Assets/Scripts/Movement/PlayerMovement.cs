
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 2f;
    public float CollisionOffset = 0.05f;
    public ContactFilter2D m_movementFilter;

    Vector2 m_movementInput;
    Rigidbody2D m_rb;

    List<RaycastHit2D> castcollisions = new List<RaycastHit2D> ();


    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D> ();
    }
    private void FixedUpdate()
    {
        if(m_movementInput != Vector2.zero)
        {
            int count = m_rb.Cast(m_movementInput, m_movementFilter, castcollisions, MoveSpeed * Time.fixedDeltaTime + CollisionOffset);
            if(count == 0)
            {
                m_rb.MovePosition(m_rb.position + m_movementInput * MoveSpeed * Time.fixedDeltaTime);
            }
        }
    }

    private void OnMove(InputValue movementValue)
    {
        m_movementInput = movementValue.Get<Vector2>();
    }
}
