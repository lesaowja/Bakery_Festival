using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FestivalManager : MonoBehaviour
{
    //�� �Ʒ����� ���ʴ�� ��ȯ�ϱ� ���� ���� BOOL��
    bool SpawnType = true;
    //��ġ Ƚ���� ���� ��ȯ�� ��Ű������ ��
    public int NpcSpawnCounter = 1;
    //������� ���� ��ġ��
    int TouchCounter = 0;
    //������ ������ ���� NPC ����
    [SerializeField] int FestivalCount = 0;
    //���������� �˱� ���� �Լ�
    public bool IsFestival = false;

    //���� Ÿ�̸� 
    float FestivalTime = 0;

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
        Debug.Log("��ġ�� Ȯ��");
    }
    void SpawnTheNpc()
    {
        TouchCounter = 0;
        if (FestivalCount == 10)
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
        }

        yield return 0;
    }
}
