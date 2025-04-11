using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Properties;
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


    // 플레이어 정보
    public int playerHp; //최대체력 저장 변수가 있으면 좋음.
    public int playerMp;
    public int[] playerAtk;
    public int[] playerCost;

    //이펙트   
    public string[] effectName;

    //사운드
    public AudioSource[] audio;

    //공격 여부 판단용 불리언
    public bool canAttack = true;

    public Enemy enemy;
    public UIUserInfo uiUserInfo;

    public void Start()
    {
        uiUserInfo.SetUp(playerHp,playerMp);
    }









    //플레이어가 공격1
    // Open Close(개방 폐쇄 원칙)
    public void Attack(int index)
    {
        int playerCost = this.playerCost[index];
        int playerAtk = this.playerAtk[index]; 
        string effectName = this.effectName[index];
        AudioSource audio = this.audio[index];

        // 공격을 했는지 판단, 
        if (canAttack == false)
            return;

        if (playerMp < playerCost)
            return;

        enemy.Hit(playerAtk);

        playerMp -= playerCost; //지금은 0이 닳게 설정됨.

        uiUserInfo.ChangePlayerInfo(playerHp, playerMp);

        audio.Play();
        GameObject effectRes = Resources.Load<GameObject>(effectName);
        Instantiate(effectRes, enemy.transform.position + Vector3.back, effectRes.transform.rotation);

        canAttack = false;
        // 4초 쿨타임후 공격 가능.
        // Invoke
        Invoke(nameof(DelayReset), 4);
        //공격후 딜레이
    }

    //딜레이 초기화
    void DelayReset()
    {
        canAttack = true;
    }

    //몬스터한테 맞음
    public void Hit(int damage)
    {
        playerHp -= damage;
        if (playerHp <= 0)
        {
            playerHp = 0;
            //게임  오버
        }
        uiUserInfo.ChangePlayerInfo(playerHp, playerMp);

    }
}
