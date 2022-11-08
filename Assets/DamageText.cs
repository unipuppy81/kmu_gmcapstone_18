using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    public float moveSpeed;  // Text �̵��ӵ�
    public float alphaSpeed; // ���� ��ȯ�ӵ�
    public float destroyTime;

    public float damage;

    TextMeshPro text;
    Color alpha;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        alpha = text.color;
        Invoke("destroyObject", destroyTime);
        text.text = damage.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed);
        text.color = alpha;
    }

    private void destroyObject()
    {
        Destroy(gameObject);
    }
}
