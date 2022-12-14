using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static UnityEngine.ParticleSystem;


public class ButtonManager : MonoBehaviour
{


    public static bool GameIsPauseed = false;
    public GameObject ButtonName;
    public GameObject pausePanel;
    public GameObject levelpanel;
    public GameObject joystick2;
    public GameObject eqPanel;

    [SerializeField]
    TextMeshProUGUI gun1_levelText;
    [SerializeField]
    TextMeshProUGUI sheild1_levelText;
    [SerializeField]
    TextMeshProUGUI emp1_levelText;
    [SerializeField]
    TextMeshProUGUI ax1_levelText;
    [SerializeField]
    TextMeshProUGUI basket1_levelText;
    [SerializeField]
    TextMeshProUGUI ammo1_levelText;
    [SerializeField]
    TextMeshProUGUI dumb1_levelText;
    [SerializeField]
    TextMeshProUGUI hot1_levelText;
    [SerializeField]
    TextMeshProUGUI bshoes_levelText;
    [SerializeField]
    TextMeshProUGUI maginc_levelText;
    [SerializeField]
    TextMeshProUGUI ppoppai_levelText;
    [SerializeField]
    TextMeshProUGUI armor_levelText;
    [SerializeField]
    TextMeshProUGUI coinText;

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
    public int axCount;
    public int basketCount;
    public int bshoesCount;
    public int magincCount;
    public int ppoppaiCount;
    public int armorCount;
    public int coin;

    public GameManager gm;
    OnButtonClick onButtonClick;
    int max;
    private void Awake()
    {
        max = 5;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        }
        else if (EventSystem.current.currentSelectedGameObject.tag == "Ax")
        {
            if (axCount < max)
            {
                Skill_Ax.axLevel++;

                axCount++;
            }
            else
            {
                axCount = 5;
            }
            Wp_1_levelText();
        }
        else if (EventSystem.current.currentSelectedGameObject.tag == "Basketball")
        {
            if (basketCount < max)
            {
                BasketBall.basketballLevel++;

                basketCount++;
            }
            else
            {
                basketCount = 5;
            }
            Wp_1_levelText();
        }
        else if (EventSystem.current.currentSelectedGameObject.tag == "Bshoes")
        {
            if (bshoesCount < max)
            {
                bshoesCount++;
            }
            else
            {
                bshoesCount = 5;
            }
            Wp_1_levelText();
        }
        else if (EventSystem.current.currentSelectedGameObject.tag == "MagInc")
        {
            if (magincCount < max)
            {
                magincCount++;
            }
            else
            {
                magincCount = 5;
            }
            Wp_1_levelText();
        }
        else if (EventSystem.current.currentSelectedGameObject.tag == "Ppoppai")
        {
            if (ppoppaiCount < max)
            {
                ppoppaiCount++;
            }
            else
            {
                ppoppaiCount = 5;
            }
            Wp_1_levelText();
        }
        else if (EventSystem.current.currentSelectedGameObject.tag == "Armor")
        {
            if (armorCount < max)
            {
                armorCount++;
            }
            else
            {
                armorCount = 5;
            }
            Wp_1_levelText();
        }
        else if (EventSystem.current.currentSelectedGameObject.tag == "coin")
        {
            coin += 200;
            cointext();
        }
        else if (EventSystem.current.currentSelectedGameObject.tag == "heart")
        {
            player.playercurHp += 20f;
        }
        gm.closePanel();
        //joystick2.SetActive(true);
        gm.selectPanel.Clear();
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
    public void EqPanelOpenbtn()
    {
        eqPanel.SetActive(true);
    }
    public void EqPanelClosebtn()
    {
        eqPanel.SetActive(false);
    }

    
    void Wp_1_levelText()
    {
        gun1_levelText.text = string.Format("LV : {0:D1}", gunCount);
        sheild1_levelText.text = string.Format("LV : {0:D1}", sheildCount);
        emp1_levelText.text = string.Format("LV : {0:D1}", empCount);
        ax1_levelText.text = string.Format("LV : {0:D1}", axCount);
        basket1_levelText.text = string.Format("LV : {0:D1}", basketCount);
        ammo1_levelText.text = string.Format("LV : {0:D1}", ammoCount);
        dumb1_levelText.text = string.Format("LV : {0:D1}", dumbbellCount);
        hot1_levelText.text = string.Format("LV : {0:D1}", hot7Count);
        bshoes_levelText.text = string.Format("LV : {0:D1}", bshoesCount);
        maginc_levelText.text = string.Format("LV : {0:D1}", magincCount);
        ppoppai_levelText.text = string.Format("LV : {0:D1}", ppoppaiCount);
        armor_levelText.text = string.Format("LV : {0:D1}", armorCount);
    }
    void cointext()
    {
        coinText.text = string.Format("COIN : {0:D3}", coin);
    }

}
