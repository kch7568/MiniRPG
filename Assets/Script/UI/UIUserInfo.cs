using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIUserInfo : MonoBehaviour
{

    // UI - 플레이어
    public TMP_Text txtHPValue;
    public Slider sliderHP;

    public TMP_Text txtMPValue;
    public Slider sliderMP;

    public void SetUp(int hp, int mp)
    {
        txtHPValue.text = hp.ToString();
        sliderHP.maxValue = hp;
        sliderHP.value = hp;

        txtMPValue.text= mp.ToString();
        sliderMP.maxValue = mp;
        sliderMP.value = mp;
    }

    //플레이어 체력변화
    //플레이어 마나 변화
    public void ChangePlayerInfo(int hp, int mp)
    {
        txtHPValue.text = hp.ToString();
        sliderHP.value = hp;

        txtMPValue.text = mp.ToString();
        sliderMP.value = mp;

    }
}
