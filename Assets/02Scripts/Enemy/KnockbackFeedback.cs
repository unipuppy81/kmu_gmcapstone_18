using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockbackFeedback : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float strengthBullet = 16f, delayBullet = 0.15f;
    [SerializeField]
    private float strengthGuardian = 16f, delayGuardian = 0.15f;
    [SerializeField]
    private float strengthMagnet = 16f, delayMagnet = 0.15f;

    public UnityEvent OnBegin, OnDone;

    public void PlayFeedbackB(GameObject sender)
    {
        StopAllCoroutines();
        OnBegin?.Invoke();
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        rb.AddForce(direction * strengthBullet, (ForceMode)ForceMode2D.Impulse);
        StartCoroutine(ResetB());
    }

    private IEnumerator ResetB()
    {
        yield return new WaitForSeconds(delayBullet);
        rb.velocity = Vector3.zero;
        OnDone?.Invoke();
    }

    public void PlayFeedbackG(GameObject sender)
    {
        StopAllCoroutines();
        OnBegin?.Invoke();
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        rb.AddForce(direction * strengthGuardian, (ForceMode)ForceMode2D.Impulse);
        StartCoroutine(ResetG());
    }

    private IEnumerator ResetG()
    {
        yield return new WaitForSeconds(delayGuardian);
        rb.velocity = Vector3.zero;
        OnDone?.Invoke();
    }

    public void PlayFeedbackM(GameObject sender)
    {
        StopAllCoroutines();
        OnBegin?.Invoke();
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        rb.AddForce(direction * strengthMagnet, (ForceMode)ForceMode2D.Impulse);
        StartCoroutine(ResetM());
    }

    private IEnumerator ResetM()
    {
        yield return new WaitForSeconds(delayMagnet);
        rb.velocity = Vector3.zero;
        OnDone?.Invoke();
    }
}
