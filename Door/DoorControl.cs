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
        // 플레이어가 문의 콜라이더 영역에 들어왔을 때 플레이어가 문 영역 내에 있음을 체크
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) isIn = true;
    }

    private void OnTriggerStay(Collider other)
    {
        // 플레이어가 문의 콜라이더 영역에 계속 있을 때 플레이어가 문 영역 내에 있음을 체크
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) isIn = true;
    }

    private void OnTriggerExit(Collider other)
    {
        // 플레이어가 문의 콜라이더 영역에서 나갔을 때 플레이어가 문 영역 내에 없음을 체크
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) isIn = false;
    }

    // 문 열기
    public void Open()
    {
        anim.SetBool("IsOpen", true);
        _audio.clip = _doorOpen;
        _audio.Play();
        Invoke("Close", 4f); // 4초 후에 Close 메서드를 호출하여 문을 닫음
    }

    // 문 닫기
    private void Close()
    {
        // 문이 열려있고 플레이어가 문 영역 내에 있지 않을 경우 문을 닫음
        if (anim.GetBool("IsOpen") && !isIn)
        {
            anim.SetBool("IsOpen", false);
            _audio.clip = _doorClose;
            _audio.Play();
        }
        else Invoke("Close", 3f); // 문이 여전히 열려있고 플레이어가 영역 내에 있을 경우, 3초 후에 다시 Close 메서드를 호출
    }
}
