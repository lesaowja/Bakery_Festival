using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainClickButton : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    public void OnMouseDown()
    {
        // ��ġ ��ġ
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MouseClick(mousePos);
        DataController.Instance.Gold += DataController.Instance.ClickGold;
    }

    public void MouseClick(Vector2 pos)
    {
        // ��ġ ��ġ�� ����Ʈ ��������.
        Instantiate(prefab, pos, Quaternion.identity);

    }

}
