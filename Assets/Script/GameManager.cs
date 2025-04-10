using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //몬스터
    //체력100
    //공격력 20


    //플레이어
    //체력 100
    //공격1 20
    //mp 0
    //공격2 40
    //mp 20

    //한번공격 ->상대몬스터도 공격
    //공격하고나면 4초동안 다시공격 x

    //몬스터한테 애니메이션
    //대기
    //공격
    //히트
    //파티클

    //몬스터잡으면
    //메시지 나오고 확인버튼 누를시 엔딩씬 넘어가기

    // 에너미 정보
    // 에너미 애니메이션 이름
    public Animator enemyAnimator; //Animation이랑 착오 주의
    public Transform enemyTransform;
    public int enemyHP;
    public int enemyAtk;

    // UI - 에너미
    public TMP_Text txtEnemyHPValue;
    public Slider sliderEnemyHP;


    // 플레이어 정보
    public int playerHp; //최대체력 저장 변수가 있으면 좋음.
    public int playerMp;
    public int playerAtk1;
    public int playerCost1;
    public int playerAtk2;
    public int playerCost2;


    // UI - 플레이어
    public TMP_Text txtHPValue;
    public Slider sliderHP;

    public TMP_Text txtMPValue;
    public Slider sliderMP;

    public GameObject uiClearPopup;

    //이펙트
    public string effectName1;
    public string effectName2;

    //사운드
    public AudioSource audio1;
    public AudioSource audio2;

    //공격 여부 판단용 불리언
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

    //플레이어가 공격1
    public void Attack1()
    {
        // 공격을 했는지 판단, 
        if (canAttack == false)
            return;

        if (playerMp < playerCost1)
            return;

        enemyAnimator.SetTrigger("Hit");

        playerMp -= playerCost1; //지금은 0이 닳게 설정됨.

        enemyHP -= playerAtk1;
        if (enemyHP <= 0)
        {
            enemyAnimator.SetTrigger("Die");
            enemyHP = 0;

            //게임 클리어
            canAttack = false;
            uiClearPopup.SetActive(true);

            //게임이 클리어되었는데, Invoke가 동작하는것 방지
            CancelInvoke();
        }
        ChangeEnemyInfo();
        ChangePlayerInfo();

        audio1.Play();
        GameObject effectRes = Resources.Load<GameObject>(effectName1);
        Instantiate(effectRes, enemyTransform.position + Vector3.back, effectRes.transform.rotation);
   
        canAttack = false;
        // 4초 쿨타임후 공격 가능.
        // Invoke
        Invoke("DelayReset", 4);
        //공격후 딜레이
        Invoke("MonsterAttack", 2);
        //몬스터 공격 딜레이
    }

    //딜레이 초기화
    void DelayReset()
    {
        canAttack = true;
    }
    //플레이어가 공격2
    public void Attack2()
    {
        // 공격을 했는지 판단, 
        if (canAttack == false)
            return;

        if (playerMp < playerCost2)
            return;

        enemyAnimator.SetTrigger("Hit");
        
        playerMp -= playerCost2; //20이 닳게 설정됨.
        enemyHP -= playerAtk2;
        if (enemyHP <= 0)
        {
            enemyAnimator.SetTrigger("Die");
            enemyHP = 0;

            //게임 클리어
            canAttack = false;
            uiClearPopup.SetActive(true);

            //게임이 클리어되었는데, Invoke가 동작하는것 방지
            CancelInvoke();
        }
        ChangeEnemyInfo();
        ChangePlayerInfo();

        audio2.Play();
        GameObject effectRes = Resources.Load<GameObject>(effectName2);
        Instantiate(effectRes, enemyTransform.position + Vector3.back, effectRes.transform.rotation);

        canAttack = false;
        // 4초 쿨타임후 공격 가능.
        // Invoke
        Invoke("DelayReset", 4);
        //공격후 딜레이
        Invoke("MonsterAttack", 2);
        //몬스터 공격 딜레이
    }

    //몬스터가 공격
    public void MonsterAttack()
    {
        enemyAnimator.SetTrigger("Attack");
        playerHp -= enemyAtk;
        if (playerHp <= 0)
        {
            playerHp = 0;
            //게임  오버
        }

        ChangePlayerInfo();
    }


    //몬스터 체력변화
    public void ChangeEnemyInfo()
    {
    txtEnemyHPValue.text = enemyHP.ToString();
    sliderEnemyHP.value = enemyHP;
    }


    //플레이어 체력변화
    //플레이어 마나 변화
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
