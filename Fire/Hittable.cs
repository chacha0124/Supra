using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hittable : MonoBehaviour
{
    public UnityEvent OnHit; // ��ȭ�⿡ �ε����� �� �̺�Ʈ
    public UnityEvent OnFire; // ���� �پ��� �� �̺�Ʈ

    public void Hit()
    {
        OnHit?.Invoke();
    }

    public void Fire()
    {
        OnFire?.Invoke();
    }
}