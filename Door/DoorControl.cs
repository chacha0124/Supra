using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public AudioSource _audio;
    public AudioClip _doorOpen;
    public AudioClip _doorClose;
    Animator anim;
    bool isIn = false;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // �÷��̾ ���� �ݶ��̴� ������ ������ �� �÷��̾ �� ���� ���� ������ üũ
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) isIn = true;
    }

    private void OnTriggerStay(Collider other)
    {
        // �÷��̾ ���� �ݶ��̴� ������ ��� ���� �� �÷��̾ �� ���� ���� ������ üũ
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) isIn = true;
    }

    private void OnTriggerExit(Collider other)
    {
        // �÷��̾ ���� �ݶ��̴� �������� ������ �� �÷��̾ �� ���� ���� ������ üũ
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) isIn = false;
    }

    // �� ����
    public void Open()
    {
        anim.SetBool("IsOpen", true);
        _audio.clip = _doorOpen;
        _audio.Play();
        Invoke("Close", 4f); // 4�� �Ŀ� Close �޼��带 ȣ���Ͽ� ���� ����
    }

    // �� �ݱ�
    private void Close()
    {
        // ���� �����ְ� �÷��̾ �� ���� ���� ���� ���� ��� ���� ����
        if (anim.GetBool("IsOpen") && !isIn)
        {
            anim.SetBool("IsOpen", false);
            _audio.clip = _doorClose;
            _audio.Play();
        }
        else Invoke("Close", 3f); // ���� ������ �����ְ� �÷��̾ ���� ���� ���� ���, 3�� �Ŀ� �ٽ� Close �޼��带 ȣ��
    }
}
