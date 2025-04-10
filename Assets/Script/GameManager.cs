using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //����
    //ü��100
    //���ݷ� 20


    //�÷��̾�
    //ü�� 100
    //����1 20
    //mp 0
    //����2 40
    //mp 20

    //�ѹ����� ->�����͵� ����
    //�����ϰ��� 4�ʵ��� �ٽð��� x

    //�������� �ִϸ��̼�
    //���
    //����
    //��Ʈ
    //��ƼŬ

    //����������
    //�޽��� ������ Ȯ�ι�ư ������ ������ �Ѿ��

    // ���ʹ� ����
    // ���ʹ� �ִϸ��̼� �̸�
    public Animator enemyAnimator; //Animation�̶� ���� ����
    public Transform enemyTransform;
    public int enemyHP;
    public int enemyAtk;

    // UI - ���ʹ�
    public TMP_Text txtEnemyHPValue;
    public Slider sliderEnemyHP;


    // �÷��̾� ����
    public int playerHp; //�ִ�ü�� ���� ������ ������ ����.
    public int playerMp;
    public int playerAtk1;
    public int playerCost1;
    public int playerAtk2;
    public int playerCost2;


    // UI - �÷��̾�
    public TMP_Text txtHPValue;
    public Slider sliderHP;

    public TMP_Text txtMPValue;
    public Slider sliderMP;

    public GameObject uiClearPopup;

    //����Ʈ
    public string effectName1;
    public string effectName2;

    //����
    public AudioSource audio1;
    public AudioSource audio2;

    //���� ���� �Ǵܿ� �Ҹ���
    public bool canAttack = true;

    public void Start()
    {
        sliderHP.maxValue = playerHp;
        sliderHP.value = playerHp;

        sliderMP.maxValue = playerMp;
        sliderMP.value = playerMp;

        sliderEnemyHP.maxValue = enemyHP;
        sliderEnemyHP.value = enemyHP;

      //  InvokeRepeating("MonsterAttack", 2, 3);
    }

    //�÷��̾ ����1
    public void Attack1()
    {
        // ������ �ߴ��� �Ǵ�, 
        if (canAttack == false)
            return;

        if (playerMp < playerCost1)
            return;

        enemyAnimator.SetTrigger("Hit");

        playerMp -= playerCost1; //������ 0�� ��� ������.

        enemyHP -= playerAtk1;
        if (enemyHP <= 0)
        {
            enemyAnimator.SetTrigger("Die");
            enemyHP = 0;

            //���� Ŭ����
            canAttack = false;
            uiClearPopup.SetActive(true);

            //������ Ŭ����Ǿ��µ�, Invoke�� �����ϴ°� ����
            CancelInvoke();
        }
        ChangeEnemyInfo();
        ChangePlayerInfo();

        audio1.Play();
        GameObject effectRes = Resources.Load<GameObject>(effectName1);
        Instantiate(effectRes, enemyTransform.position + Vector3.back, effectRes.transform.rotation);
   
        canAttack = false;
        // 4�� ��Ÿ���� ���� ����.
        // Invoke
        Invoke("DelayReset", 4);
        //������ ������
        Invoke("MonsterAttack", 2);
        //���� ���� ������
    }

    //������ �ʱ�ȭ
    void DelayReset()
    {
        canAttack = true;
    }
    //�÷��̾ ����2
    public void Attack2()
    {
        // ������ �ߴ��� �Ǵ�, 
        if (canAttack == false)
            return;

        if (playerMp < playerCost2)
            return;

        enemyAnimator.SetTrigger("Hit");
        
        playerMp -= playerCost2; //20�� ��� ������.
        enemyHP -= playerAtk2;
        if (enemyHP <= 0)
        {
            enemyAnimator.SetTrigger("Die");
            enemyHP = 0;

            //���� Ŭ����
            canAttack = false;
            uiClearPopup.SetActive(true);

            //������ Ŭ����Ǿ��µ�, Invoke�� �����ϴ°� ����
            CancelInvoke();
        }
        ChangeEnemyInfo();
        ChangePlayerInfo();

        audio2.Play();
        GameObject effectRes = Resources.Load<GameObject>(effectName2);
        Instantiate(effectRes, enemyTransform.position + Vector3.back, effectRes.transform.rotation);

        canAttack = false;
        // 4�� ��Ÿ���� ���� ����.
        // Invoke
        Invoke("DelayReset", 4);
        //������ ������
        Invoke("MonsterAttack", 2);
        //���� ���� ������
    }

    //���Ͱ� ����
    public void MonsterAttack()
    {
        enemyAnimator.SetTrigger("Attack");
        playerHp -= enemyAtk;
        if (playerHp <= 0)
        {
            playerHp = 0;
            //����  ����
        }

        ChangePlayerInfo();
    }


    //���� ü�º�ȭ
    public void ChangeEnemyInfo()
    {
    txtEnemyHPValue.text = enemyHP.ToString();
    sliderEnemyHP.value = enemyHP;
    }


    //�÷��̾� ü�º�ȭ
    //�÷��̾� ���� ��ȭ
    public void ChangePlayerInfo()
    {
        txtHPValue.text = playerHp.ToString();
        sliderHP.value = playerHp;

        txtMPValue.text = playerMp.ToString();
        sliderMP.value = playerMp;

    }

    public void GoToEnding()
    {
        SceneManager.LoadScene("05.Ending");
    }
}
