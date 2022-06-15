using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FestivalManager : MonoBehaviour
{
    //위 아래에서 차례대로 소환하기 위한 구분 BOOL값
    bool SpawnType = true; 
    //터치 횟수에 의한 소환을 시키기위한 값
    public int NpcSpawnCounter = 1; 
    //현재까지 누른 터치값
    int TouchCounter = 0;
    //축제가 열리기 위한 NPC 갯수
    [SerializeField]int FestivalCount = 0;


    NPC_Spawner UpSpawner;
    NPC_Spawner DownSpawner;

    public void Start()
    {
        UpSpawner = GameObject.Find("NpcSpawner1").GetComponent<NPC_Spawner>();
        DownSpawner = GameObject.Find("NpcSpawner2").GetComponent<NPC_Spawner>();
    }
    public void TouchFunc()
    {
        TouchCounter++;
        if(NpcSpawnCounter<=TouchCounter)
        {
            SpawnTheNpc();
        }
        Debug.Log("터치를 확인");
    }
    void SpawnTheNpc()
    {
        TouchCounter = 0;
        FestivalCount++;
        if(FestivalCount >29)
        {

        }
        
        if (SpawnType==true)
        {
            DownSpawner.Spawn();
        }
        else
        {
            UpSpawner.Spawn();
        }
        SpawnType = !SpawnType;
    }
    public void DeletedNpc()
    {
        FestivalCount--;
        
    }
}
