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
    // 시작 시
    public void NewGame()
    {
        if (EventIndex == 0)
        {
            GameManager.isNewStart = true;
        }
    }
    // 시야 회전
    public void ChangeSight()
    {
        if (EventIndex == 1)
        {
            EventIndex++;
            ChangeSightEvent?.Invoke();
        }
    }
    // 움직였을 때
    public void Move()
    {
        if (EventIndex == 2)
        {
            EventIndex++;
            MoveEvent?.Invoke();
        }
    }
    // 정비실 그랩
    public void RepairGrab()
    {
        if (EventIndex == 3)
        {
            EventIndex++;
            RepairGrabEvent?.Invoke();
        }
    }
    // 정비실 - 전기실 문 열기
    public void RepairElectricDoorOpen()
    {
        if (EventIndex == 4)
        {
            EventIndex++;
            RepairElectricDoorOpenEvent?.Invoke();
        }
    }
    // 전선 그랩
    public void WireGrab()
    {
        if (EventIndex == 5)
        {
            EventIndex++;
            WireGrabEvent?.Invoke();
        }
    }
    // 전선 연결
    public void WireConnect()
    {
        if (EventIndex == 6)
        {
            EventIndex++;
            WireConnectEvent?.Invoke();
        }
    }
    // 전기실 - 산소공급실 잠긴 문 열기 시도
    public void ElectricOxyzenLockDoorOpen()
    {
        if (EventIndex == 7)
        {
            EventIndex++;
            ElectricOxyzenLockDoorOpenEvent?.Invoke();
        }
    }
    // 퓨즈 복구
    public void FuseConnect()
    {
        if (EventIndex == 8)
        {
            EventIndex++;
            FuseConnectEvent?.Invoke();
        }
    }
    // 전기실 - 산소공급실 문 열기
    public void ElectricOxyzenDoorOpen()
    {
        if (EventIndex == 9)
        {
            EventIndex++;
            ElectricOxyzenDoorOpenEvent?.Invoke();
        }
    }
    // 산소공급실 퍼즐 성공
    public void OxygenStationPuzzleClear()
    {
        if (EventIndex == 10)
        {
            EventIndex++;
            OxygenStationPuzzleClearEvent?.Invoke();
        }
    }
    // 소화기 잡기
    public void ExtinguisherGrab()
    {
        if (EventIndex == 11)
        {
            EventIndex++;
            ExtinguisherGrabEvent?.Invoke();
        }
    }
    // 소화기 던지기
    public void ExtinguisherThrow()
    {
        if (EventIndex == 12)
        {
            //EventIndex++;
            ExtinguisherThrowEvent?.Invoke();
        }
    }
    // 화재 클리어
    public void FireClear()
    {
        if (EventIndex == 13)
        {
            EventIndex++;
            FireClearEvent?.Invoke();
        }
    }
    // 항해실 문 열기 실패
    public void LiftControlStationLockDoorOpen()
    {
        LiftControlStationLockDoorOpenEvent?.Invoke();
    }
    // 항해실 문 열기
    public void LiftControlStationDoorOpen()
    {
        if (EventIndex == 14)
        {
            EventIndex++;
            LiftControlStationDoorOpenEvent?.Invoke();
        }
    }
    // 항해실 퍼즐 성공
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
