using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinScript : MonoBehaviour
{
    public AudioClip coinSound ; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(180*Time.deltaTime,0,0);
    }

    
    private void OnTriggerEnter (Collider other)

    {
       AudioSource.PlayClipAtPoint(coinSound , transform.position);
        Destroy(gameObject) ; 
            ScoreManger.instance.AddPoint();
            
    }
}
