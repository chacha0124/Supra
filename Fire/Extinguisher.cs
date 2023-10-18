using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Extinguisher : MonoBehaviour
{
    // 소화기의 상태 (Idle 상태, Drop 상태)
    public enum State
    {
        Idle,
        Drop,
    }

    public float explosionRadius;
    public LayerMask explosionHittableMask;

    public UnityEvent OnExplosion;  // 폭발이 발생할 때 호출되는 이벤트

    private State state; // 현재 상태
    private bool isActive = true;

    // 소화기 떨어뜨리기
    public void Drop()
    {
        state = State.Drop;
    }

    // 소화기 던지기
    public void Throw()
    {
        var interactable = GetComponent<XRGrabInteractable>();
        interactable.interactionManager.CancelInteractableSelection((IXRSelectInteractable)interactable);

        var rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(0f, 150f, 300f));
    }

    // 소화기가 불에 닿았을 때
    private void OnCollisionEnter(Collision collision)
    {
        // 대기 상태라면 return
        if (state == State.Idle)
            return;
        // 불에 닿았고 활성 상태라면
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("FireObject")) && isActive)
        {
            isActive = false;
            Explosion(); // 폭발 함수
            Invoke("Distroy", 0.1f);
        }
    }

    private void Explosion()
    {
        // 범위 내 객체 검색
        var overlaps = Physics.OverlapSphere(transform.position, explosionRadius, explosionHittableMask, QueryTriggerInteraction.Collide);
        foreach (var overlap in overlaps)
        {
            // 객체의 Hittable 컴포넌트를 불러오고 Hit 함수 호출
            var hitObject = overlap.GetComponent<Hittable>();
            hitObject?.Hit();
        }
        OnExplosion?.Invoke(); // 폭발 이벤트
    }

    private void Distroy()
    {
        gameObject.SetActive(false);
    }
}
