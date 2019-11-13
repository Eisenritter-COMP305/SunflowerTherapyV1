using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private float _hp;
    private float _mp;
    private float maxHP = 100;
    private float maxMP = 100;

    private const float FADE_TIMER_MAX = 1f;

    public Image HpImg;
    public Image damagedImg;
    public Image MpImg;
    public Image usageImg;

    private Color damagedColor;
    private Color usageColor;
    private float damagedHpFadeTimer;
    private float usageMpFadeTimer;


    public float Hp
    {
        get { return _hp; }

        set
        {
            // update the UI label once the lives value is changed
            _hp = value;

            if (_hp > maxHP) _hp = maxHP;
            // DEAD!!!
            if (_hp <= 0) 
            {
                SceneManager.LoadScene("End");
                //FindObjectOfType<AudioManager>().Play("PlayerDeath");
            }



            if (damagedColor.a <= 0)
                // Damaged bar image is invisible
                damagedImg.fillAmount = HpImg.fillAmount;

            // .......
            damagedColor.a = .5f;
            damagedImg.color = damagedColor;
            damagedHpFadeTimer = FADE_TIMER_MAX;

            HpImg.fillAmount = (float)Hp / maxHP;

        }
    }

    public float Mp
    {
        get { return _mp; }
        set
        {
            _mp = value;

            if (_mp > maxMP) _mp = maxMP;

            if (_mp <= 0) _mp = 0;

            if (usageColor.a <= 0)
                // Damaged bar image is invisible
                usageImg.fillAmount = MpImg.fillAmount;

            // .......
            usageColor.a = .5f;
            usageImg.color = usageColor;
            usageMpFadeTimer = FADE_TIMER_MAX;

            MpImg.fillAmount = (float)_mp / maxMP;


        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Hp = 100;
        Mp = 100;
        //maxHP = Hp;
        //maxMP = Mp;

        damagedColor = Color.white;
        damagedColor.a = 0f;
        damagedImg.color = damagedColor;

        usageColor = Color.white;
        usageColor.a = 0f;
        usageImg.color = usageColor;

    }


    private void Update()
    {

        // =========== hp bar =================
        if (damagedColor.a > 0)
        {
            damagedHpFadeTimer -= Time.deltaTime;
            if (damagedHpFadeTimer < 0)
            {
                float fadeAmount = 5f;
                damagedColor.a -= fadeAmount * Time.deltaTime;
                damagedImg.color = damagedColor;
            }
        }

        // =========== mp bar ==================
        if (usageColor.a > 0)
        {
            usageMpFadeTimer -= Time.deltaTime;
            if (usageMpFadeTimer < 0)
            {
                float fadeAmount = 5f;
                usageColor.a -= fadeAmount * Time.deltaTime;
                usageImg.color = usageColor;
            }
        }








    }


}
