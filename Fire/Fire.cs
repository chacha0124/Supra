using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Vector3 _scale;
    public float _hp;
    Vector3 _zerohp = new Vector3(0, 0, 0);

    // 게임 오브젝트가 생성될 때 초기 화재 크기 설정
    private void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            transform.GetChild(i).localScale = _scale;
        }
    }

    // 화재 발생 시 불이 커지는 메서드
    public void IncreFire()
    {
        // 화재가 꺼져 있다면 화재를 활성화
        if (gameObject.activeInHierarchy == false) gameObject.SetActive(true);
        // 화재가 이미 최대 크기라면 더 이상 증가시키지 않음
        if (transform.GetChild(0).localScale == _scale) return;
        // 각 자식 요소의 크기를 증가시켜 화재 크기를 증가
        for (int i = 0; i < 3; i++) transform.GetChild(i).localScale += _scale / _hp;
    }

    // 소화기에 부딪혔을 때 불이 작아지는 메서드
    public void DecreFire()
    {
        // 화재가 이미 꺼진 상태라면 더 이상 감소시키지 않음
        if (transform.GetChild(0).localScale == _zerohp) return;
        // 각 자식 요소의 크기를 감소시켜 화재 크기를 감소
        for (int i = 0; i < 3; i++) transform.GetChild(i).localScale -= _scale / _hp;
        // 화재가 완전히 꺼진 상태라면
        if (transform.GetChild(0).localScale == _zerohp)
        {
            EventManager.EventIndex++;
            EventManager.Instance.FireClear(); // 화재가 꺼진 이벤트를 호출
            gameObject.SetActive(false);
        }
    }
}
