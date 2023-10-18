using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Extinguisher : MonoBehaviour
{
    // ��ȭ���� ���� (Idle ����, Drop ����)
    public enum State
    {
        Idle,
        Drop,
    }

    public float explosionRadius;
    public LayerMask explosionHittableMask;

    public UnityEvent OnExplosion;  // ������ �߻��� �� ȣ��Ǵ� �̺�Ʈ

    private State state; // ���� ����
    private bool isActive = true;

    // ��ȭ�� ����߸���
    public void Drop()
    {
        state = State.Drop;
    }

    // ��ȭ�� ������
    public void Throw()
    {
        var interactable = GetComponent<XRGrabInteractable>();
        interactable.interactionManager.CancelInteractableSelection((IXRSelectInteractable)interactable);

        var rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(0f, 150f, 300f));
    }

    // ��ȭ�Ⱑ �ҿ� ����� ��
    private void OnCollisionEnter(Collision collision)
    {
        // ��� ���¶�� return
        if (state == State.Idle)
            return;
        // �ҿ� ��Ұ� Ȱ�� ���¶��
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("FireObject")) && isActive)
        {
            isActive = false;
            Explosion(); // ���� �Լ�
            Invoke("Distroy", 0.1f);
        }
    }

    private void Explosion()
    {
        // ���� �� ��ü �˻�
        var overlaps = Physics.OverlapSphere(transform.position, explosionRadius, explosionHittableMask, QueryTriggerInteraction.Collide);
        foreach (var overlap in overlaps)
        {
            // ��ü�� Hittable ������Ʈ�� �ҷ����� Hit �Լ� ȣ��
            var hitObject = overlap.GetComponent<Hittable>();
            hitObject?.Hit();
        }
        OnExplosion?.Invoke(); // ���� �̺�Ʈ
    }

    private void Distroy()
    {
        gameObject.SetActive(false);
    }
}
