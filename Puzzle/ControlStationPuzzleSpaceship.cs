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
        // ��ġ�� ���ϸ� Ÿ�̸� �ʱ�ȭ
        if (tmpx != transform.position.x || tmpz != transform.position.z)
        {
            timer = 0;
            tmpx = transform.position.x;
            tmpz = transform.position.z;
        }
        // Ÿ�̸Ӱ� ��� �ð��� �ʰ��ϸ� ���� ��ġ�� ����
        if (timer >= waitingTime && nav.enabled == true && isClear == false)
        {
            nav.enabled = false;
            transform.position = startPoint.transform.position;
            timer = 0;
            Debug.Log("Die");
        }
        // �������� �̵�
        if (nav.enabled)
        {
            nav.destination = arrivalPoint.transform.position;
            timer += Time.deltaTime;
            // �������� �����ϸ� Ŭ���� ó��
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