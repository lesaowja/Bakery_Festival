using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FestivalManager : MonoBehaviour
{
    //�� �Ʒ����� ���ʴ�� ��ȯ�ϱ� ���� ���� BOOL��
    bool SpawnType = true;
    //��ġ Ƚ���� ���� ��ȯ�� ��Ű������ ��
    [Header("��� ������ ��ȯ�ΰ�")]
    public float NpcSpawnCounter = 1;
 
    //������� ���� ��ġ��
    float TouchCounter = 0;
    [Header("����� ���;� �佺Ƽ���ΰ�")]
    //������ ������ ���� NPC ����
    public float FestivalTotalCount =0f;
    [SerializeField] float FestivalCount = 0f;
    //���������� �˱� ���� �Լ�
    public bool IsFestival = false;

    //���� Ÿ�̸� 
    [SerializeField]float FestivalTime = 0;
    //������ ����ϱ� ���� NPC ���� 
    float SpecialCount = 0;
    //�������ٸ� ä��� ���� �̹���
    [SerializeField]Image FilledImage;

    //���� ��ȯ����
    MusicMng Music;


    NPC_Spawner UpSpawner;
    NPC_Spawner DownSpawner;

    [SerializeField] float AutoTimer = 0.1f;

    [SerializeField] MainClickButton Mainclickbut;

    public void Start()
    {
        Music = GameObject.Find("BGMPlayer").GetComponent<MusicMng>();
        UpSpawner = GameObject.Find("NpcSpawner1").GetComponent<NPC_Spawner>();
        DownSpawner = GameObject.Find("NpcSpawner2").GetComponent<NPC_Spawner>();
        Mainclickbut = GameObject.Find("MainClickButton").GetComponent<MainClickButton>();
        StartCoroutine("AddSpawnCounter");
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
            Music.DefaultSong();
            IsFestival = false;
            FestivalCount = 0; 
            FestivalTime = 0;
            Mainclickbut.IsFestivalNow = false;
            StopCoroutine("FestivalFunc");

        }
        else
        {
            StartCoroutine("FestivalFunc");
            FilledImage.fillAmount = 0; 
        } 
    }
    private void Update()
    {
        if (FestivalCount == FestivalTotalCount && IsFestival == false)
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
            IsFestival = true;
            Music.FestivalSong();
            Mainclickbut.IsFestivalNow = true; 
            SpecialCount = 0;
            StartCoroutine("FestivalFunc");
            StartCoroutine("FestivalNPCSpawn"); 
        }
        if(!IsFestival)
        {
            float Nums = 1 / NpcSpawnCounter * TouchCounter;
            FilledImage.fillAmount = Nums;
        }
        
    }
    IEnumerator FestivalNPCSpawn()
    {

        yield return new WaitForSeconds(0.1f);
        SpecialCount += 0.1f;
        if (SpecialCount >11)
        {
            StopCoroutine("FestivalNPCSpawn");
        }
        else
        {
            StartCoroutine("FestivalNPCSpawn");
            if (SpawnType == true) 
                DownSpawner.Spawn();  
            else 
                UpSpawner.Spawn();  
            SpawnType = !SpawnType;
        }
     
    }

    IEnumerator AddSpawnCounter()
    {

        yield return new WaitForSeconds(0.1f);
        AutoTimer += 0.1f;
        if(AutoTimer >= 1)
        {
            AutoTimer = 0;
            if(!IsFestival)
            TouchCounter += 2;
            if (NpcSpawnCounter <= TouchCounter)
            {
                SpawnTheNpc();
            }
            StartCoroutine("AddSpawnCounter");
        }
        else
        {
            StartCoroutine("AddSpawnCounter");
        }
    }


}

