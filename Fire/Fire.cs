using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Vector3 _scale;
    public float _hp;
    Vector3 _zerohp = new Vector3(0, 0, 0);

    // ���� ������Ʈ�� ������ �� �ʱ� ȭ�� ũ�� ����
    private void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            transform.GetChild(i).localScale = _scale;
        }
    }

    // ȭ�� �߻� �� ���� Ŀ���� �޼���
    public void IncreFire()
    {
        // ȭ�簡 ���� �ִٸ� ȭ�縦 Ȱ��ȭ
        if (gameObject.activeInHierarchy == false) gameObject.SetActive(true);
        // ȭ�簡 �̹� �ִ� ũ���� �� �̻� ������Ű�� ����
        if (transform.GetChild(0).localScale == _scale) return;
        // �� �ڽ� ����� ũ�⸦ �������� ȭ�� ũ�⸦ ����
        for (int i = 0; i < 3; i++) transform.GetChild(i).localScale += _scale / _hp;
    }

    // ��ȭ�⿡ �ε����� �� ���� �۾����� �޼���
    public void DecreFire()
    {
        // ȭ�簡 �̹� ���� ���¶�� �� �̻� ���ҽ�Ű�� ����
        if (transform.GetChild(0).localScale == _zerohp) return;
        // �� �ڽ� ����� ũ�⸦ ���ҽ��� ȭ�� ũ�⸦ ����
        for (int i = 0; i < 3; i++) transform.GetChild(i).localScale -= _scale / _hp;
        // ȭ�簡 ������ ���� ���¶��
        if (transform.GetChild(0).localScale == _zerohp)
        {
            EventManager.EventIndex++;
            EventManager.Instance.FireClear(); // ȭ�簡 ���� �̺�Ʈ�� ȣ��
            gameObject.SetActive(false);
        }
    }
}
