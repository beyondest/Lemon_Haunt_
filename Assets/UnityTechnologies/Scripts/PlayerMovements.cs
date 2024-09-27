using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float turnSpeed;
    Animator m_Animator;
    Vector3 m_Movement;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();      // GetComponet is part of MonoBehaviour class
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();     // Ensure Diagonal movement is not faster than orthogonal movement
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVeriticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVeriticalInput;
        m_Animator.SetBool("IsWalking", isWalking);

    }


    
    

    
}
