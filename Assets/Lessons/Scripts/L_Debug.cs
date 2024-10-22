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
        [SerializeField] public MyScriptableObject myScriptableObject;
        private void Update()
        {
            float localVar;
            localVar = Input.GetAxis("Horizontal");
            m_privVar = localVar;
            pubVar = localVar ;
            if (myScriptableObject != null)
            {
                myScriptableObject.value = localVar;
            }
        }
    }


}

//Debug Method 1: Printing to the console
//Debug.Log("Local Variable: " + localVar);
//Debug.Log("Private Variable: " + m_privVar);
//Debug.Log("Public Variable: " + pubVar);


//Debug Method : Show in inspector
//Just look at m_privVar and pubVar in the inspector
