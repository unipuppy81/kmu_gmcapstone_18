using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GuardianCullTime : MonoBehaviour
{
    private IEnumerator cullCounter;
    private WaitForFixedUpdate fixedUpdate = new WaitForFixedUpdate();
    private float cullTime = 2f;
    private float filledTime = 0f;
    private float waitTime = 3f;

    public GameObject[] guardians;
    public int hasGuardians = 0;

    public GameObject guardian;

    // Start is called before the first frame update
    
    void OnEnable()
    {
        //guardian.gameObject.SetActive(true);
        StartCoroutine(countCull());
        Invoke("activeFalse", 3.0f);
    }

    private IEnumerator countCull()
    {
        while(true)
        {
            yield return null;
            //Debug.Log("È°¼ºÈ­");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void activeFalse()
    {
        for (int i = 0; i < guardians.Length; i++)
        {
            guardians[i].gameObject.SetActive(false);
        }
    }
    void activeTrue()
    {
        for (int i = 0; i < guardians.Length; i++)
        {
            guardians[i].gameObject.SetActive(true);
        }
    }
}
