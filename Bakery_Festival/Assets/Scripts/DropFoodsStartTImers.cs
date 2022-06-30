using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropFoodsStartTImers : MonoBehaviour
{
    //���� �����ϱ� ���� 3�� ī��Ʈ�� �����ֱ� ���� �гΰ� �ؽ�Ʈ �׸��� ���ڿ��� �� String �� �ð��� ������ Int
    public GameObject panel;
    public GameObject[] Buttons = new GameObject[3];
    public Text TimerText;
    string TimerString;
    int StartTimer;
    //������ �Ǿ����� �Ǵ��� ����
    public bool IsStart = false;
    //1�� ����
    float sec1 = 1f;
    //������ �� �ð� 
    int GameTimer = 30;
    //������ ������ �� ����� �гΰ� ��Ʈ�� �� �ؽ�Ʈ 
    public GameObject EndPanel;
    public Text EndText;
    public string EndString;

    public Text Timer;
    public Text Point;
    private void Start()
    {

        sec1 = 1f;
       
    }

    public void StartBut()
    {
        GameTimer = 15;
        StartTimer = 3;
        StartCoroutine("StartTimerCourtine");
        for(int i = 0; i<Buttons.Length; i++)
        {
            Buttons[i].SetActive(false);
        }
    }

    IEnumerator StartTimerCourtine()
    {
        if(StartTimer>0)
        {
            if(sec1 >0)
            {
                yield return new WaitForSeconds(0.1f); 
                sec1 -= 0.1f;
            }
            else
            {
                sec1 = 1;
                StartTimer -= 1;

            }

            TimerString = StartTimer.ToString(); 
            TimerText.text = TimerString;
            StartCoroutine("StartTimerCourtine");
        }
        else
        {
            sec1 = 1f;
            IsStart = true;
            panel.SetActive(false);
            StartCoroutine("StartGameTimerCourtine");
        }

        yield return 0;
    }
    IEnumerator StartGameTimerCourtine()
    {
        if (GameTimer > 0)
        {
            if (sec1 > 0)
            {
                yield return new WaitForSeconds(0.1f);
                sec1 -= 0.1f;
            }
            else
            {
                sec1 = 1;
                GameTimer -= 1;
            }

            Timer.text = GameTimer.ToString();
            TimerString = StartTimer.ToString();
            TimerText.text = TimerString;
            StartCoroutine("StartGameTimerCourtine");
        }
        else
        {
         
            IsStart = false;

            yield return new WaitForSeconds(0.1f);
            int ResultSum = GameObject.Find("GameMng").GetComponent<DropFoodsPointMng>().PointsNum;
            EndPanel.SetActive(true);

            if (ResultSum <= 800)
            {
                DataController.Instance.Ruby += 30;
                EndString = "�̰ų� �԰�.... 30���� ��� ȹ���߽��ϴ�";
                //���� ���� ����
            }
            else if (ResultSum > 800 && ResultSum <= 950)
            {
                DataController.Instance.Ruby += 50;
                EndString = "���� �����ʳ�";

            }
            else if (ResultSum > 950 && ResultSum <= 1100)
            {
                DataController.Instance.Ruby += 150;
                EndString = "���ݸ� �� ����� ����";
            }
            else if (ResultSum > 1100 && ResultSum <= 1200)
            {
                DataController.Instance.Ruby += 200;
                EndString = "�ϸ� �����ʳ� ������";
            }
            else if (ResultSum > 1200 && ResultSum <= 1400)
            {
                DataController.Instance.Ruby += 250;
                EndString = "�������.!!";
            }
            else if (ResultSum > 1400)
            {
                DataController.Instance.Ruby += 300;
                EndString = "���ϴ� ����ΰ� �ڳ״�?";

            }
           
            EndText.text = EndString;

        }

        yield return 0;
    }

}
