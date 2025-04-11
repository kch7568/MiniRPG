using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemyInfo : MonoBehaviour
{
    // UI - ���ʹ�
    public TMP_Text txtEnemyHPValue;
    public Slider sliderEnemyHP;
   
    public void Setup(int hp)
    {
        sliderEnemyHP.maxValue = hp;
        sliderEnemyHP.value = hp;
        txtEnemyHPValue.text = hp.ToString();
     }

    //���� ü�º�ȭ
    public void ChangeEnemyInfo(int hp)
    {
        txtEnemyHPValue.text = hp.ToString();
        sliderEnemyHP.value = hp;
    }

}
