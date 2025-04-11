using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIUserInfo : MonoBehaviour
{

    // UI - �÷��̾�
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

    //�÷��̾� ü�º�ȭ
    //�÷��̾� ���� ��ȭ
    public void ChangePlayerInfo(int hp, int mp)
    {
        txtHPValue.text = hp.ToString();
        sliderHP.value = hp;

        txtMPValue.text = mp.ToString();
        sliderMP.value = mp;

    }
}
