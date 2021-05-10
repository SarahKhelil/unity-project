using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManger : MonoBehaviour
{
    public GameObject[] tilePrefab ; 
    private Transform playerTransform ; 
    private float spawnZ = -92.7f;
    private float tileLength = 185.4f ; // l point ali chinhotou fyha tile thenia 
    private int amnTilesOnScreen = 5 ;   
    private float safeZone = 188f ; 

    private int lastPrefabIndex = 0 ; 
    private List<GameObject> activeTiles; 


    private void Start()
    {
        activeTiles = new List<GameObject>() ; 
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform ; 
        for (int i = 0 ; i<amnTilesOnScreen; i++ ) {
           if ( i <2 )
            SpawnTile(0) ; 
            else 
            SpawnTile() ; 
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength)) {
            SpawnTile() ; 
            DeleteTile() ; 
        }
    }

    private void SpawnTile (int prefabIndex = -1)
    {
        GameObject go ;
        if (prefabIndex == -1)  
        go = Instantiate (tilePrefab[RandomPrefabIndex()] as GameObject) ; 

        else 
        go = Instantiate(tilePrefab[prefabIndex]) as GameObject ; 
        go.transform.SetParent (transform) ; 
        go.transform.position = Vector3.forward * spawnZ ; 
        spawnZ += tileLength ; 
        activeTiles.Add(go) ; 

    }

    private void DeleteTile() {
        Destroy (activeTiles [0]) ; 
        activeTiles.RemoveAt(0) ; 
    }

    private int RandomPrefabIndex () {
        if (tilePrefab.Length <=1) 
        return 0 ; 

        int randomIndex = lastPrefabIndex ; 
        while (randomIndex == lastPrefabIndex) 
        {
            randomIndex = Random.Range (0 , tilePrefab.Length) ; 
            
        }
        lastPrefabIndex = randomIndex ;
        return randomIndex ; 
    }
}
