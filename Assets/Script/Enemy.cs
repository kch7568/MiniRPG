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
    // 에너미 정보
    // 에너미 애니메이션 이름
    public Animator enemyAnimator; //Animation이랑 착오 주의
    public int enemyHP;
    public int enemyAtk;


    private void Start()
    {
        enemyAnimator.GetComponent<Animator>();
        uiEnemyInfo.Setup(enemyHP);
    } 
    //몬스터가 공격
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
        Invoke(nameof(MonsterAttack), 2);//몬스터 공격 딜레이
        uiEnemyInfo.ChangeEnemyInfo(enemyHP);

    }
}
