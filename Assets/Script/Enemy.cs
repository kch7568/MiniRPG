using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    const string AttackTrigger = "Attack";
    const string HitTrigger = "Hit";
    const string DieTrigger = "Die";

    public GameManager gm;
    public UIEnemyInfo uiEnemyInfo;
    public UIClearPopup uiClearPopup;
    // ���ʹ� ����
    // ���ʹ� �ִϸ��̼� �̸�
    public Animator enemyAnimator; //Animation�̶� ���� ����
    public int enemyHP;
    public int enemyAtk;


    private void Start()
    {
        enemyAnimator.GetComponent<Animator>();
        uiEnemyInfo.Setup(enemyHP);
    } 
    //���Ͱ� ����
    public void MonsterAttack()
    {
        enemyAnimator.SetTrigger(AttackTrigger);
        gm.Hit(enemyAtk); 
    }
    public void Hit(int damage)
    {
        enemyAnimator.SetTrigger(HitTrigger);

        enemyHP -= damage;
        if (enemyHP <= 0)
        {
            enemyAnimator.SetTrigger(DieTrigger);
            enemyHP = 0;
            uiClearPopup.gameObject.SetActive(true);
        }
        Invoke(nameof(MonsterAttack), 2);//���� ���� ������
        uiEnemyInfo.ChangeEnemyInfo(enemyHP);

    }
}
