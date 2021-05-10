using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ; 


public class DestroyObject : MonoBehaviour
{
      private Animator m_Animator ; 

    void Start()
    {

    }

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle") {
           Die() ;  
        }
    }

    private void Die() {
        SceneManager.LoadScene("GameOver") ; 
    }

   
}
