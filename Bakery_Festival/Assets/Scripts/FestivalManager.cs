using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FestivalManager : MonoBehaviour
{
    //위 아래에서 차례대로 소환하기 위한 구분 BOOL값
    bool SpawnType = true;
    //터치 횟수에 의한 소환을 시키기위한 값
    public int NpcSpawnCounter = 1;
    //현재까지 누른 터치값
    int TouchCounter = 0;
    //축제가 열리기 위한 NPC 갯수
    public float FestivalTotalCount =0f;
    [SerializeField] float FestivalCount = 0f;
    //축제중인지 알기 위한 함수
    public bool IsFestival = false;

    //축제 타이머 
    float FestivalTime = 0;

    //게이지바를 채우기 위한 이미지
    [SerializeField]Image FilledImage;


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
        if (NpcSpawnCounter <= TouchCounter)
        {
            SpawnTheNpc();
        }
        Debug.Log("터치를 확인");
    }
    void SpawnTheNpc()
    {
        TouchCounter = 0;
        if (FestivalCount >= FestivalTotalCount)
        {
            IsFestival = true;
            FestivalTime = 0;
            StartCoroutine("FestivalFunc");
        }
        if(!IsFestival)
        {
            if (SpawnType == true)
            {
                DownSpawner.Spawn();
                FestivalCount++;  
            }
            else
            {
                UpSpawner.Spawn();
                FestivalCount++; 
            }
            float Nums = 1 / FestivalTotalCount * FestivalCount;
            FilledImage.fillAmount = Nums;
            SpawnType = !SpawnType;
        }
        
    }
    public void DeletedNpc()
    {
        FestivalCount--;

    }
    IEnumerator FestivalFunc()
    {
        yield return new WaitForSeconds(0.1f);
        FestivalTime += 0.1f;
        if (FestivalTime >= 15)
        {
            IsFestival = false;
        }
        else
        {
            StartCoroutine("FestivalFunc");
            FilledImage.fillAmount = 0;
        }

        yield return 0;
    }
     
}
