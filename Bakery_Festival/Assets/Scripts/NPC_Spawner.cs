using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Spawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Transform pivot;
    [SerializeField] float spawnTime;
    [SerializeField] int MaxCount;

    float timer = 0;
    int count = 0;

    private void Start()
    {
        Spawn();
    }

    private void Update()
    {
        if (count > MaxCount)
            return;

        if (count <= MaxCount)
        {
            
            Spawn();
        }
    }

    public void Spawn()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            Debug.Log("�մ� ����");
            Instantiate(prefab, pivot.position, Quaternion.identity);
            timer = 0;
            count++;
        }
    }
}
