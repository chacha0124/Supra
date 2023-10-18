using Oculus.Platform.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class ControlStationPuzzleSpaceship : MonoBehaviour
{
    public GameObject arrivalPoint;
    public NavMeshAgent nav;
    public GameObject startPoint;

    public float waitingTime = 2f;
    float timer = 0f;
    float tmpx;
    float tmpz;
    bool isClear = false;


    private void Awake()
    {
        nav = GetComponent< NavMeshAgent>();
        nav.enabled = false;
        tmpx = transform.position.x;
        tmpz = transform.position.z;
    }

    void Update()
    {
        // 위치가 변하면 타이머 초기화
        if (tmpx != transform.position.x || tmpz != transform.position.z)
        {
            timer = 0;
            tmpx = transform.position.x;
            tmpz = transform.position.z;
        }
        // 타이머가 대기 시간을 초과하면 시작 위치로 리셋
        if (timer >= waitingTime && nav.enabled == true && isClear == false)
        {
            nav.enabled = false;
            transform.position = startPoint.transform.position;
            timer = 0;
            Debug.Log("Die");
        }
        // 목적지로 이동
        if (nav.enabled)
        {
            nav.destination = arrivalPoint.transform.position;
            timer += Time.deltaTime;
            // 목적지에 도착하면 클리어 처리
            if (transform.position.x == arrivalPoint.transform.position.x && transform.position.z == arrivalPoint.transform.position.z)
            {
                nav.enabled = false;
                isClear = true;
                EventManager.Instance.ControlStationPuzzle();
                Debug.Log("Success");
            }
        }
    }
}