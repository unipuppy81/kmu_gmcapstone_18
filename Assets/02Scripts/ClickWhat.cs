using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickWhat : MonoBehaviour
{
    int count;
    // ��ư�� ������ �� ȣ��� �Լ�
    public void ClickBtn()
    {
        print("��ư Ŭ��");

        // ��� Ŭ���� ���� ������Ʈ�� �����ͼ� ����
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;

        // ��� Ŭ���� ���� ������Ʈ�� �̸��� ��ư �� ���� ���
        print(clickObject.name);

    }
}
