using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem.LowLevel;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField]
    XRBaseController controller;

    public TMP_Text tmp;

    public static bool isNewStart;

    public GameObject _faderScreen;

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

        if (isNewStart)
        {
            isNewStart = !isNewStart;
            StartCoroutine(StartEventCoroutine());
        }
    }
    public static GameManager Instance
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

    // 게임의 진행을 돕기 위해 새로운 임무가 주어지면 컨트롤러에 진동을 주고 임무 텍스트를 띄우는 함수
    public void SetText(string str)
    {
        controller.SendHapticImpulse(0.7f, 0.1f);
        tmp.text = str;
    }

    // 게임 시작 이벤트를 실행하는 코루틴
    IEnumerator StartEventCoroutine()
    {
        yield return new WaitForSecondsRealtime(3f);
        EventManager.Instance.NewGameEvent?.Invoke();
        EventManager.EventIndex++;
    }

    // 게임 종료 함수
    public void Ending()
    {
        StartCoroutine(EndingCoroutine());
    }

    // 게임 종료 코루틴. 화면을 페이드 아웃하고 메인메뉴 씬으로 가기
    IEnumerator EndingCoroutine()
    {
        _faderScreen.gameObject.SetActive(true);
        Material mat = _faderScreen.GetComponent<MeshRenderer>().material;
        Color color = mat.color;

        while (mat.color.a <= 1)
        {
            color.a += Time.deltaTime * 0.5f;
            mat.color = color;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSecondsRealtime(2f);

        SceneManager.LoadScene(0);
    }
}