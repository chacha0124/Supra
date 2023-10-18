using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class EventManager : MonoBehaviour
{
    public static int EventIndex = 0;

    public UnityEvent NewGameEvent;
    public UnityEvent ChangeSightEvent;
    public UnityEvent MoveEvent;
    public UnityEvent RepairGrabEvent;
    public UnityEvent RepairElectricDoorOpenEvent;
    public UnityEvent WireGrabEvent;
    public UnityEvent WireConnectEvent;
    public UnityEvent ElectricOxyzenLockDoorOpenEvent;
    public UnityEvent FuseConnectEvent;
    public UnityEvent ElectricOxyzenDoorOpenEvent;
    public UnityEvent OxygenStationPuzzleClearEvent;
    public UnityEvent ExtinguisherGrabEvent;
    public UnityEvent ExtinguisherThrowEvent;
    public UnityEvent FireClearEvent;
    public UnityEvent LiftControlStationLockDoorOpenEvent;
    public UnityEvent LiftControlStationDoorOpenEvent;
    public UnityEvent ControlStationPuzzleClearEvent;

    public Hittable OxygenFireObject;

    public int FuseCount;

    private static EventManager instance;
    private void Awake()
    {
        Application.targetFrameRate = 60;

        if (null == instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static EventManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    // ���� ��
    public void NewGame()
    {
        if (EventIndex == 0)
        {
            GameManager.isNewStart = true;
        }
    }
    // �þ� ȸ��
    public void ChangeSight()
    {
        if (EventIndex == 1)
        {
            EventIndex++;
            ChangeSightEvent?.Invoke();
        }
    }
    // �������� ��
    public void Move()
    {
        if (EventIndex == 2)
        {
            EventIndex++;
            MoveEvent?.Invoke();
        }
    }
    // ����� �׷�
    public void RepairGrab()
    {
        if (EventIndex == 3)
        {
            EventIndex++;
            RepairGrabEvent?.Invoke();
        }
    }
    // ����� - ����� �� ����
    public void RepairElectricDoorOpen()
    {
        if (EventIndex == 4)
        {
            EventIndex++;
            RepairElectricDoorOpenEvent?.Invoke();
        }
    }
    // ���� �׷�
    public void WireGrab()
    {
        if (EventIndex == 5)
        {
            EventIndex++;
            WireGrabEvent?.Invoke();
        }
    }
    // ���� ����
    public void WireConnect()
    {
        if (EventIndex == 6)
        {
            EventIndex++;
            WireConnectEvent?.Invoke();
        }
    }
    // ����� - ��Ұ��޽� ��� �� ���� �õ�
    public void ElectricOxyzenLockDoorOpen()
    {
        if (EventIndex == 7)
        {
            EventIndex++;
            ElectricOxyzenLockDoorOpenEvent?.Invoke();
        }
    }
    // ǻ�� ����
    public void FuseConnect()
    {
        if (EventIndex == 8)
        {
            EventIndex++;
            FuseConnectEvent?.Invoke();
        }
    }
    // ����� - ��Ұ��޽� �� ����
    public void ElectricOxyzenDoorOpen()
    {
        if (EventIndex == 9)
        {
            EventIndex++;
            ElectricOxyzenDoorOpenEvent?.Invoke();
        }
    }
    // ��Ұ��޽� ���� ����
    public void OxygenStationPuzzleClear()
    {
        if (EventIndex == 10)
        {
            EventIndex++;
            OxygenStationPuzzleClearEvent?.Invoke();
        }
    }
    // ��ȭ�� ���
    public void ExtinguisherGrab()
    {
        if (EventIndex == 11)
        {
            EventIndex++;
            ExtinguisherGrabEvent?.Invoke();
        }
    }
    // ��ȭ�� ������
    public void ExtinguisherThrow()
    {
        if (EventIndex == 12)
        {
            //EventIndex++;
            ExtinguisherThrowEvent?.Invoke();
        }
    }
    // ȭ�� Ŭ����
    public void FireClear()
    {
        if (EventIndex == 13)
        {
            EventIndex++;
            FireClearEvent?.Invoke();
        }
    }
    // ���ؽ� �� ���� ����
    public void LiftControlStationLockDoorOpen()
    {
        LiftControlStationLockDoorOpenEvent?.Invoke();
    }
    // ���ؽ� �� ����
    public void LiftControlStationDoorOpen()
    {
        if (EventIndex == 14)
        {
            EventIndex++;
            LiftControlStationDoorOpenEvent?.Invoke();
        }
    }
    // ���ؽ� ���� ����
    public void ControlStationPuzzle()
    {
        if (EventIndex == 15)
        {
            ControlStationPuzzleClearEvent?.Invoke();
        }
    }

    public void FuseAdd()
    {
        FuseCount++;
    }
    public void FuseSub()
    {
        FuseCount--;
    }
    public void Update()
    {
        if (FuseCount == 2)
        {
            FuseConnect();
        }
    }
}
