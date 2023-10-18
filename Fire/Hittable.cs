using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hittable : MonoBehaviour
{
    public UnityEvent OnHit; // 소화기에 부딪혔을 때 이벤트
    public UnityEvent OnFire; // 불이 붙었을 때 이벤트

    public void Hit()
    {
        OnHit?.Invoke();
    }

    public void Fire()
    {
        OnFire?.Invoke();
    }
}