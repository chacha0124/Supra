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

    // ������ ������ ���� ���� ���ο� �ӹ��� �־����� ��Ʈ�ѷ��� ������ �ְ� �ӹ� �ؽ�Ʈ�� ���� �Լ�
    public void SetText(string str)
    {
        controller.SendHapticImpulse(0.7f, 0.1f);
        tmp.text = str;
    }

    // ���� ���� �̺�Ʈ�� �����ϴ� �ڷ�ƾ
    IEnumerator StartEventCoroutine()
    {
        yield return new WaitForSecondsRealtime(3f);
        EventManager.Instance.NewGameEvent?.Invoke();
        EventManager.EventIndex++;
    }

    // ���� ���� �Լ�
    public void Ending()
    {
        StartCoroutine(EndingCoroutine());
    }

    // ���� ���� �ڷ�ƾ. ȭ���� ���̵� �ƿ��ϰ� ���θ޴� ������ ����
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