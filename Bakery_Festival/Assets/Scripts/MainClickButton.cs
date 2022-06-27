using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainClickButton : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    Vector2 creatPonit;
    //Touch �ν��� �ٸ� �ڵ忡�� �ϱ� ���� ȣ��
    [SerializeField] FestivalManager festivalMng;

    //�������������� ���� �ֱ����� BOOL
    public bool IsFestivalNow;
    private void Start()
    {
        festivalMng = GameObject.Find("DataController").GetComponent<FestivalManager>();
        Debug.Log(festivalMng);
    }
    public void OnMouseDown()
    {
        // ��ġ ��ġ
        //Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        creatPonit = Input.mousePosition;
        
        if(IsFestivalNow)
        DataController.Instance.Gold += DataController.Instance.ClickGold*5;
        else
        DataController.Instance.Gold += DataController.Instance.ClickGold;
        MouseClick();
    }
    //���� ���̶��
  
    public void MouseClick()
    {
        // ��ġ ��ġ�� ����Ʈ ��������.
        Instantiate(prefab, creatPonit, Quaternion.identity, GameObject.Find("Canvas").transform);
        festivalMng.TouchFunc();
    }

}
