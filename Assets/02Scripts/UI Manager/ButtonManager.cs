using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class ButtonManager : MonoBehaviour
{


    public static bool GameIsPauseed = false;
    public GameObject ButtonName;
    public GameObject pausePanel;
    public GameObject levelpanel;

    [SerializeField]
    TextMeshProUGUI gun1_levelText;
    [SerializeField]
    TextMeshProUGUI sheild1_levelText;
    [SerializeField]
    TextMeshProUGUI emp1_levelText;
    [SerializeField]
    TextMeshProUGUI ammo1_levelText;
    [SerializeField]
    TextMeshProUGUI dumb1_levelText;
    [SerializeField]
    TextMeshProUGUI hot1_levelText;

    [SerializeField]
    TextMeshProUGUI gun2_levelText;
    [SerializeField]
    TextMeshProUGUI sheild2_levelText;
    [SerializeField]
    TextMeshProUGUI emp2_levelText;
    [SerializeField]
    TextMeshProUGUI ammo2_levelText;
    [SerializeField]
    TextMeshProUGUI dumb2_levelText;
    [SerializeField]
    TextMeshProUGUI hot2_levelText;

    [SerializeField]
    TextMeshProUGUI gun3_levelText;
    [SerializeField]
    TextMeshProUGUI sheild3_levelText;
    [SerializeField]
    TextMeshProUGUI emp3_levelText;
    [SerializeField]
    TextMeshProUGUI ammo3_levelText;
    [SerializeField]
    TextMeshProUGUI dumb3_levelText;
    [SerializeField]
    TextMeshProUGUI hot3_levelText;

    int maxGuardians = 4;

    Skill_Guardian guardian;
    Skill_Magnetic magneticField;
    Player player;
    Bullet bullet;

    public int gunCount;
    public int sheildCount;
    public int empCount;
    public int ammoCount;
    public int dumbbellCount;
    public int hot7Count;


    public GameManager gm;

    int max;
    private void Awake()
    {
        gm = gameObject.GetComponent<GameManager>();
        max = 5;
        guardian = GameObject.Find("Front").GetComponent<Skill_Guardian>();
        player = GameObject.Find("Player").GetComponent<Player>();
        magneticField = GameObject.Find("MagneticField").GetComponent<Skill_Magnetic>();
    }

    public void ClickBtn()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        if (EventSystem.current.currentSelectedGameObject.tag == "Gun")
        {
            if(gunCount < max)
            {
                gunCount++;
            }
            else
            {
                gunCount = 5;
            }
            Wp_1_levelText();
            Wp_2_levelText();
            Wp_3_levelText();
        }
        else if(EventSystem.current.currentSelectedGameObject.tag == "Sheild")
        {
            if (sheildCount < max)
            {
                sheildCount++;
            }
            else
            {
                sheildCount = 5;

            }
            Wp_1_levelText();
            Wp_2_levelText();
            Wp_3_levelText();

        }
        else if (EventSystem.current.currentSelectedGameObject.tag == "EMP")
        {
            if (empCount < max)
            {
                empCount++;
            }
            else
            {
                empCount = 5;
            }
            Wp_1_levelText();
            Wp_2_levelText();
            Wp_3_levelText();
        }
        else if (EventSystem.current.currentSelectedGameObject.tag == "Ammo")
        {
            if (ammoCount < max)
            {
                ammoCount++;
            }
            else
            {
                ammoCount = 5;
            }
            Wp_1_levelText();
            Wp_2_levelText();
            Wp_3_levelText();
        }
        else if (EventSystem.current.currentSelectedGameObject.tag == "Dumbbell")
        {
            if (dumbbellCount < max)
            {
                dumbbellCount++;
            }
            else
            {
                dumbbellCount = 5;
            }
            Wp_1_levelText();
            Wp_2_levelText();
            Wp_3_levelText();
        }
        else if (EventSystem.current.currentSelectedGameObject.tag == "Hot7")
        {
            if (hot7Count < max)
            {
                hot7Count++;
            }

            else
            {
                hot7Count = 5;
            }
            Wp_1_levelText();
            Wp_2_levelText();
            Wp_3_levelText();
        }

        levelpanel.SetActive(false);
        ButtonName.SetActive(true);  
        Time.timeScale = 1f;
    }
    public void PauseClick()
    {
        if (GameIsPauseed)
        {
            Resume();
        }
        else
        {
            Pause();
            pausePanel.SetActive(true);
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPauseed = false;
        pausePanel.SetActive(false);
    }

    public void Pause()
    {
        ButtonName.SetActive(true);
        Time.timeScale = 0f;
        GameIsPauseed = true;
    }

    public void ToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    void Wp_1_levelText()
    {
        gun1_levelText.text = string.Format("LV : {0:D1}", gunCount);
        sheild1_levelText.text = string.Format("LV : {0:D1}", sheildCount);
        emp1_levelText.text = string.Format("LV : {0:D1}", empCount);
        ammo1_levelText.text = string.Format("LV : {0:D1}", ammoCount);
        dumb1_levelText.text = string.Format("LV : {0:D1}", dumbbellCount);
        hot1_levelText.text = string.Format("LV : {0:D1}", hot7Count);
    }
    void Wp_2_levelText()
    {
        gun2_levelText.text = string.Format("LV : {0:D1}", gunCount);
        sheild2_levelText.text = string.Format("LV : {0:D1}", sheildCount);
        emp2_levelText.text = string.Format("LV : {0:D1}", empCount);
        ammo2_levelText.text = string.Format("LV : {0:D1}", ammoCount);
        dumb2_levelText.text = string.Format("LV : {0:D1}", dumbbellCount);
        hot2_levelText.text = string.Format("LV : {0:D1}", hot7Count);
    }
    void Wp_3_levelText()
    {
        gun3_levelText.text = string.Format("LV : {0:D1}", gunCount);
        sheild3_levelText.text = string.Format("LV : {0:D1}", sheildCount);
        emp3_levelText.text = string.Format("LV : {0:D1}", empCount);
        ammo3_levelText.text = string.Format("LV : {0:D1}", ammoCount);
        dumb3_levelText.text = string.Format("LV : {0:D1}", dumbbellCount);
        hot3_levelText.text = string.Format("LV : {0:D1}", hot7Count);
    }
}
