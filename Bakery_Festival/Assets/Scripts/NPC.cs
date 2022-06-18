using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] float Destorytimer;
    //������ ������ NPC�� ���ư������� Y��ǥ�� �ޱ����� transform

    [SerializeField] float percent; // ĳ���� �̵� ���� �ۼ�Ʈ
    Transform UpNpcPos;

    Transform EndPos;
    public bool HaveTarget = false;
    [SerializeField] Vector3 TargetPos;

    Rigidbody2D rigid;

    float lifeTimer;
    float moveSpeed;

    int width = Screen.width;       // ���� �ػ�

    [SerializeField] int NpcType = 0;

    //������ �ٰ����� �ٽ� �����ִ� ���̶�� ���� ��Ÿ���� ���� �Լ�
    int ReturnToNew = 99999;
    int ReturnTempNum = 99991;

    //Festival�� ��Ʈ�� �ϱ����� ��ȯ
    FestivalManager festivalMng;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        festivalMng = GameObject.Find("DataController").GetComponent<FestivalManager>();
        //EndPos �ȿ� �������� ������ Transform �� ����ִ´�
        EndPos = GameObject.FindGameObjectWithTag("L_End").GetComponent<Transform>();
        //R_end�� tag�߿� ���ȵǰ� ���� ��Ȳ�� �Ǿ� ����� ���
        UpNpcPos = GameObject.FindGameObjectWithTag("R_End").GetComponent<Transform>();

        moveSpeed = (width * percent) / 100;
    }

    void Update()
    {

        //���� Ÿ���� ������ �ʾҴٸ� EndPos��ġ�� Ÿ���� ����
        if (!HaveTarget)
            SetTarget(EndPos.transform.position);
        //
        MoveToTarget(TargetPos);

        lifeTimer += Time.deltaTime;
        if (NpcType == 2)
        {
            if (this.transform.position.y == EndPos.transform.position.y)
            {
                SetTarget(EndPos.transform.position);
            }
        }
        else
        {
            if (this.transform.position.y == UpNpcPos.transform.position.y)
            {
                SetTarget(EndPos.transform.position);
            }
        }

    }
    // �ش� Vector3 ��ġ�� Ÿ���� ������ �ִ� ��Ȱ
    void SetTarget(Vector3 N)
    {
        HaveTarget = true;
        TargetPos = N;
    }

    //���� ��ǥ ��ġ�� �̵������ִ� �Լ�
    void MoveToTarget(Vector3 N)
    {
        if (Vector2.Distance(transform.position, N) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, N, moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("L_End"))
        {
            festivalMng.DeletedNpc();
            Destroy(this.gameObject);
        }

    }

    //���� 1 ��Ű 2 ����ũ 3 ���� 4 ��� 5
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�Ʒ��ٿ��� ��ȯ�Ǵ��� ������ ��ȯ�Ǵ����� �����ϱ� ���� NpcType
        if (collision.gameObject.name == "NpcSpawner1")
        {
            NpcType = 1;
        }
        if (collision.gameObject.name == "NpcSpawner2")
        {
            NpcType = 2;
        }
        /*
        �Ʒ��� �ڵ�� ������ȣ�� ���̸���� �Ȱ��� �ڵ��̱⿡ ������ ���̻����� �ڵ忡 �� �ڵ带 ����س��ҽ��ϴ�. 
        */

        //���̻����� ���� �ڽ�Ʈ���ſ� �¾����� �׸��� �̹� �� ���Ը� ���� NPC�� �ƴ϶�� �ش� IF�� ���� 
        if (collision.gameObject.name == "PieShopBox" && ReturnTempNum != 1)
        {
            //�� ������ ������ȣ �� ��ȣ�� ������ �־�� �ö󰬴� ������ �ٽ� ���� �ʰ� �Ѵ� 
            ReturnTempNum = 1;
            //�� ���Ը� ���� ���� ���ϴ� Ȯ�� (1,2)�϶� 1�̸� ���� 2�϶� ���� �ʴ´�
            int RandN = Random.Range(1, 2);
            //�������� ������ġ �� Transform ���·� �ޱ� ���� �Լ�
            Transform T1;
            if (RandN == 1)
            {
                //�ش� ���Կ� ����ִ� ������ �ִ����� ����� �Լ����� �� return �Ǿ� ���� ���ڰ� �ִٸ� Switch������ �Ѿ��
                int ShopTargetNum = CheckEmptyPlace("PieShop");
                switch (ShopTargetNum)
                {
                    case 0:
                        //T1�̶�� �Լ��� �����ִ� �ڸ��� ��ġ�� �޾ƿ´�.
                        T1 = GameObject.FindGameObjectWithTag("PieShopStay3").GetComponent<Transform>();
                        //Target�� T1�̶�� �Լ��� �ٲ۴�
                        SetTarget(T1.transform.position);
                        //�� �ڸ��� ���� ���� ��ȣ 
                        ReturnToNew = 1;
                        break;
                    case 1:
                        //T1�̶�� �Լ��� �����ִ� �ڸ��� ��ġ�� �޾ƿ´�.
                        T1 = GameObject.FindGameObjectWithTag("PieShopStay4").GetComponent<Transform>();
                        //Target�� T1�̶�� �Լ��� �ٲ۴�
                        SetTarget(T1.transform.position);
                        //�� �ڸ��� ���� ���� ��ȣ 
                        ReturnToNew = 2;
                        break;
                    case 99:
                        break;
                    default:
                        break;
                }
            }
            else if (RandN == 0)
            {
            }
        }
        //��Ű������ ���� �ڽ�Ʈ���ſ� �¾����� �׸��� �̹� �� ���Ը� ���� NPC�� �ƴ϶�� �ش� IF�� ���� 
        if (collision.gameObject.name == "CookieShopBox" && ReturnTempNum != 2)
        {
            ReturnTempNum = 2;
            int RandN = Random.Range(1, 2);
            Transform T1;
            if (RandN == 1)
            {
                int ShopTargetNum = CheckEmptyPlace("CookieShop");
                switch (ShopTargetNum)
                {
                    case 0:
                        T1 = GameObject.FindGameObjectWithTag("CookieShopStay3").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 3;
                        break;
                    case 1:
                        T1 = GameObject.FindGameObjectWithTag("CookieShopStay4").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 4;
                        break;
                    default:
                        break;
                }
            }
            else if (RandN == 0)
            {
            }

        }
        //����ũ������ ���� �ڽ�Ʈ���ſ� �¾����� �׸��� �̹� �� ���Ը� ���� NPC�� �ƴ϶�� �ش� IF�� ���� 
        if (collision.gameObject.name == "CakeShopBox" && ReturnTempNum != 3)
        {
            ReturnTempNum = 3;
            int RandN = Random.Range(1, 2);
            Transform T1;
            if (RandN == 1)
            {
                int ShopTargetNum = CheckEmptyPlace("CakeShop");
                switch (ShopTargetNum)
                {
                    case 0:
                        T1 = GameObject.FindGameObjectWithTag("CakeShopStay3").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 5;
                        break;
                    case 1:
                        T1 = GameObject.FindGameObjectWithTag("CakeShopStay4").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 6;
                        break;
                    default:
                        break;
                }
            }
            else if (RandN == 0)
            {
            }

        }
        //���ӻ����� ���� �ڽ�Ʈ���ſ� �¾����� �׸��� �̹� �� ���Ը� ���� NPC�� �ƴ϶�� �ش� IF�� ���� 
        if (collision.gameObject.name == "DonutShopBox" && ReturnTempNum != 4)
        {
            ReturnTempNum = 4;
            int RandN = Random.Range(1, 2);
            Transform T1;
            if (RandN == 1)
            {
                int ShopTargetNum = CheckEmptyPlace("DonutShop");
                switch (ShopTargetNum)
                {
                    case 0:
                        T1 = GameObject.FindGameObjectWithTag("DonutShopStay3").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 7;
                        break;
                    case 1:
                        T1 = GameObject.FindGameObjectWithTag("DonutShopStay4").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 8;
                        break;
                    default:
                        break;
                }
            }
            else if (RandN == 0)
            {
            }

        }
        //��л����� ���� �ڽ�Ʈ���ſ� �¾����� �׸��� �̹� �� ���Ը� ���� NPC�� �ƴ϶�� �ش� IF�� ���� 
        if (collision.gameObject.name == "MelonShopBox" && ReturnTempNum != 5)
        {
            ReturnTempNum = 5;
            int RandN = Random.Range(1, 2);
            Transform T1;
            if (RandN == 1)
            {
                int ShopTargetNum = CheckEmptyPlace("MelonShop");
                switch (ShopTargetNum)
                {
                    case 0:
                        T1 = GameObject.FindGameObjectWithTag("MelonShopStay3").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 9;
                        break;
                    case 1:
                        T1 = GameObject.FindGameObjectWithTag("MelonShopStay4").GetComponent<Transform>();
                        SetTarget(T1.transform.position);
                        ReturnToNew = 10;
                        break;
                    default:
                        break;
                }
            }
            else if (RandN == 0)
            {
            }

        }

        //������ �� �� ī��Ʈ ���� �ڷ�ƾ ����
        if (collision.gameObject.CompareTag("StartTimer"))
        {
            StartCoroutine("ReturnTimer");
        }
    }

    int CheckEmptyPlace(string name)
    {
        /*
        �Ʒ��� �ڵ�� ������ȣ�� ���̸���� �Ȱ��� �ڵ��̱⿡ ������ ���̻����� �ڵ忡 �� �ڵ带 ����س��ҽ��ϴ�. 
        */

        //�޾ƿ� string�� ���̻����̶�� 
        if (name == "PieShop")
        {
            //����ִ� �ڸ��� �ִ����� Ȯ���ϰ�
            if (GameObject.Find("PieShopStay3").GetComponent<EmptyPlace>().IsEmpty)
            {
                //�ִٸ� ���� ��������ʴٶ�� ������
                GameObject.Find("PieShopStay3").GetComponent<EmptyPlace>().IsEmpty = false;
                //0�� ���Ͻ����ش� ���� ����ġ������ ���
                return 0;
            }
            else if (GameObject.Find("PieShopStay4").GetComponent<EmptyPlace>().IsEmpty)
            {
                //�ִٸ� ���� ��������ʴٶ�� ������
                GameObject.Find("PieShopStay4").GetComponent<EmptyPlace>().IsEmpty = false;
                //1�� ���Ͻ����ش� ���� ����ġ������ ���
                return 1;
            }
            //��������ʴٸ� 1111����
            else
            {
                return 1111;
            }
        }
        //�޾ƿ� string�� ��Ű�����̶�� 
        if (name == "CookieShop")
        {
            if (GameObject.Find("CookieShopStay3").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("CookieShopStay3").GetComponent<EmptyPlace>().IsEmpty = false;
                return 0;
            }
            else if (GameObject.Find("CookieShopStay4").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("CookieShopStay4").GetComponent<EmptyPlace>().IsEmpty = false;
                return 1;
            }

            else
            {
                return 1111;
            }
        }
        //�޾ƿ� string�� ����ũ�����̶�� 
        if (name == "CakeShop")
        {
            if (GameObject.Find("CakeShopStay3").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("CakeShopStay3").GetComponent<EmptyPlace>().IsEmpty = false;
                return 0;
            }
            else if (GameObject.Find("CakeShopStay4").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("CakeShopStay4").GetComponent<EmptyPlace>().IsEmpty = false;
                return 1;
            }

            else
            {
                return 1111;
            }
        }
        //�޾ƿ� string�� ���ӻ����̶�� 
        if (name == "DonutShop")
        {
            if (GameObject.Find("DonutShopStay3").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("DonutShopStay3").GetComponent<EmptyPlace>().IsEmpty = false;
                return 0;
            }
            else if (GameObject.Find("DonutShopStay4").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("DonutShopStay4").GetComponent<EmptyPlace>().IsEmpty = false;
                return 1;
            }

            else
            {
                return 1111;
            }
        }
        //�޾ƿ� string�� ��л����̶�� 
        if (name == "MelonShop")
        {
            if (GameObject.Find("MelonShopStay3").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("MelonShopStay3").GetComponent<EmptyPlace>().IsEmpty = false;
                return 0;
            }
            else if (GameObject.Find("MelonShopStay4").GetComponent<EmptyPlace>().IsEmpty)
            {
                GameObject.Find("MelonShopStay4").GetComponent<EmptyPlace>().IsEmpty = false;
                return 1;
            }

            else
            {
                return 1111;
            }
        }
        //�޾ƿ� string�� ���̻����̶�� 
        return 99;
    }

    IEnumerator ReturnTimer()
    {
        //3�� ���Կ��� ��ٸ��� 
        yield return new WaitForSeconds(3f);

        //�Ʒ����� ��ȯ�� ���̶�� �״�� �Ʒ����� Ÿ�ټ���
        if (NpcType == 2)
        {
            SetTarget(new Vector3(this.transform.position.x, EndPos.position.y, 0));
        }
        //������ ��ȯ�� ���̸� ���� ���� ��ұ��� Ÿ�ټ���
        else
        {

            SetTarget(new Vector3(this.transform.position.x, UpNpcPos.position.y, 0));
        }
        //�� ���ڸ��� �ٽ� ���Կ� �����ֵ��� True ���·� ��ȯ.
        switch (ReturnToNew)
        {
            case 1:
                GameObject.Find("PieShopStay3").GetComponent<EmptyPlace>().IsEmpty = true;
                break;
            case 2:
                GameObject.Find("PieShopStay4").GetComponent<EmptyPlace>().IsEmpty = true;
                break;
            case 3:
                GameObject.Find("CookieShopStay3").GetComponent<EmptyPlace>().IsEmpty = true;
                break;
            case 4:
                GameObject.Find("CookieShopStay4").GetComponent<EmptyPlace>().IsEmpty = true;
                break;
            case 5:
                GameObject.Find("CakeShopStay3").GetComponent<EmptyPlace>().IsEmpty = true;
                break;
            case 6:
                GameObject.Find("CakeShopStay4").GetComponent<EmptyPlace>().IsEmpty = true;
                break;
            case 7:
                GameObject.Find("DonutShopStay3").GetComponent<EmptyPlace>().IsEmpty = true;
                break;
            case 8:
                GameObject.Find("DonutShopStay4").GetComponent<EmptyPlace>().IsEmpty = true;
                break;
            case 9:
                GameObject.Find("MelonShopStay3").GetComponent<EmptyPlace>().IsEmpty = true;
                break;
            case 10:
                GameObject.Find("MelonShopStay4").GetComponent<EmptyPlace>().IsEmpty = true;
                break;

            default:
                break;
        }
        StopCoroutine("ReturnTimer");


    }
}
