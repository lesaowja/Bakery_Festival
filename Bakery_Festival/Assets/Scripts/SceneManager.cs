using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : Singleton<SceneManager>
{
    int ClickCount = 0;         // �ڷΰ��� ��ư Ŭ�� Ƚ��

    private void Update()
    {
        CloseGame();
        Debug.Log("CloseGame");

    }

    public void LoadScene(string sceneName)
    {
        // ������ ���� �ε��Ѵ�.
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    // ���� ����
    public void CloseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClickCount++;
            if (!IsInvoking("DoubleClick"))     // ����Ŭ�� ���� ������
            {
                Invoke("DoubleClick", 1.0f);    // 1�� ������
                Debug.Log("����Ŭ�� �ϸ� ��������");
            }
            else if (ClickCount == 2)            // ����Ŭ���� �ߴٸ�
            {

                Debug.Log("��������");
                CancelInvoke("DoubleClick");    // ����Ŭ�� �Լ� ��ҽ�Ű��
                Application.Quit();             // �� ����
            }
        }
    }

    void DoubleClick()
    {
        ClickCount = 0;
    }

    public void QuitGame()
    {
        // ���ø����̼� ����
        Application.Quit();
    }

    public void ReloadScene()
    {
        // ������ ���� ���
        var scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();

        // ���� ���� �ٽ� �ε� �Ѵ�.
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene.name);
    }
}