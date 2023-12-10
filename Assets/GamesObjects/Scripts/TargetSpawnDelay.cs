using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawnDelay : MonoBehaviour
{
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;
    public GameObject target5;
    public GameObject target6;
    public GameObject target7;
    void Start()
    {
        Invoke("SpawnDelay", 11);
    }

    void Update()
    {
        
    }

    private void SpawnDelay()
    {
        target1.SetActive(true);
        target2.SetActive(true);
        target3.SetActive(true);
        target4.SetActive(true);
        target5.SetActive(true);
        target6.SetActive(true);
        target7.SetActive(true);
    }
}
