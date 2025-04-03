using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject victory;
    public Slider ehpBar;
    public Slider empBar;
    public Slider playerMpBar;
    public Slider playerHpBar;
    public Text eName;
    public Text eHpText;
    public Text eHpValue;
    public Text eMpText;
    public Text eMpValue;
    public GameObject popup;

    // ü�� : 100
    public int enemyHp = 100;
    

    //�÷��̾�
    //MP : 50
    public int playerMp = 50;
    

    //���� 1 : 20
    //���� 2 : 30
    int attackDamage1 = 20;
    int attackDamage2 = 30;

   public void Attack1()
    {

        if(playerMp <= 20)
        {
            Debug.Log("MP�� �����մϴ�.");
            return;
        }
        enemyHp -= attackDamage1;
        playerMp -= 5;//mp 5
        playerMpBar.value -= 5;

        ehpBar.value -= attackDamage1;
            if (enemyHp <= 0)
            {
                Debug.Log("���͸� ��ҽ��ϴ�.");
                victory.SetActive(true);
                Destroy(enemy);

            popup.SetActive(false);
       
            }  
    }
   public void Attack2() 
    {
        if (playerMp <= 20)
        {
            Debug.Log("MP�� �����մϴ�.");
            return;
        }
        enemyHp -= attackDamage2;
        playerMp -= 10;//mp 10

        if (enemyHp <= 0)
        {
            Debug.Log("���͸� ��ҽ��ϴ�.");
            victory.SetActive(true);
            Destroy(enemy);
            popup.SetActive(false);

        }


    }
   public void SceneChange()
    {
        SceneManager.LoadScene("UITest");
    }

}
