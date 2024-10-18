using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float turnSpeed = 20f;       // radius
    public float moveSpeed = 10f;
    public readonly int t = 10;
    Animator m_Animator;
    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    AudioSource m_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();      // GetComponet is part of MonoBehaviour class
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()  // default called 50 times per second
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();     // Ensure Diagonal movement is not faster than orthogonal movement
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVeriticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVeriticalInput;
        m_Animator.SetBool("IsWalking", isWalking);
        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }
        //radians delta means the angle between the current forward vector and the desired forward vector
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);

    }
    void OnAnimatorMove()           //
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }

    
    

    
}
