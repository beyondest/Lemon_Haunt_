using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Lessons
{ 

    public class L_Debug : MonoBehaviour
    {
        public float pubVar = 10.0f;
        //this variable can show in the inspector but it is still private
        [SerializeField ]   private float m_privVar = 20.0f;
        private void Update()
        {
            float localVar;
            localVar = Input.GetAxis("Horizontal");
            m_privVar = localVar;
            pubVar = localVar ;

            //Debug Method 1: Printing to the console
            Debug.Log("Local Variable: " + localVar);
            Debug.Log("Private Variable: " + m_privVar);
            Debug.Log("Public Variable: " + pubVar);

            //Debug Method 2: Drawing a line in the Editor
            Vector3 start = transform.position;
            Vector3 end = start + new Vector3(localVar, 0, 0);
            Debug.DrawLine(start, end, Color.red);

            //Debug Method 3: Show in inspector
            //Just look at m_privVar and pubVar in the inspector



        }
    }
}