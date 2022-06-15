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
        Debug.Log("��ġ�� Ȯ��");
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
