using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianCullTime : MonoBehaviour
{
    private IEnumerator cullCounter;
    private WaitForFixedUpdate fixedUpdate = new WaitForFixedUpdate();
    private float cullTime;
    private float filledTime;

    public GameObject[] guardians;
    public int hasGuardians = 0;

    public GameObject guardian;

    // Start is called before the first frame update
    void Start()
    {
        cullCounter = countCull();
    }

    private IEnumerator countCull()
    {
        guardian.gameObject.SetActive(false);

        cullTime = 5f;
        filledTime = 0f;

        if (filledTime < cullTime)
        {
            yield return fixedUpdate;
            filledTime += Time.deltaTime;
        }
        else
        {
            guardian.gameObject.SetActive(true);
            yield break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
