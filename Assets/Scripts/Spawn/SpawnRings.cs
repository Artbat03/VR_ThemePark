using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRings : MonoBehaviour
{
    // Variables
    [SerializeField] private int ringsInScene;
    [SerializeField] private int maxSpawnRing = 3;
    [SerializeField] private GameObject ringPrefab;
    [SerializeField] private Vector3 ringPos;
    [SerializeField] private bool allSpawned;

    #region GETTERS && SETTERS

    public int RingsInScene
    {
        get => ringsInScene;
        set => ringsInScene = value;
    }
    
    public bool AllSpawned
    {
        get => allSpawned;
        set => allSpawned = value;
    }

    #endregion

    private void Update()
    {
        if (ringsInScene < maxSpawnRing && !allSpawned)
        {
            Invoke("SpawnRing", 1);
        }
    }

    private void SpawnRing()
    {
        if (ringsInScene < maxSpawnRing && !allSpawned)
        {
            ringsInScene++;
            Instantiate(ringPrefab, ringPos, Quaternion.identity);
        }

        if (ringsInScene == maxSpawnRing)
        {
            allSpawned = true;
        }
    }
}
