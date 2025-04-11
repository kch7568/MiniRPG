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


    // �÷��̾� ����
    public int playerHp; //�ִ�ü�� ���� ������ ������ ����.
    public int playerMp;
    public int[] playerAtk;
    public int[] playerCost;

    //����Ʈ   
    public string[] effectName;

    //����
    public AudioSource[] audio;

    //���� ���� �Ǵܿ� �Ҹ���
    public bool canAttack = true;

    public Enemy enemy;
    public UIUserInfo uiUserInfo;

    public void Start()
    {
        uiUserInfo.SetUp(playerHp,playerMp);
    }









    //�÷��̾ ����1
    // Open Close(���� ��� ��Ģ)
    public void Attack(int index)
    {
        int playerCost = this.playerCost[index];
        int playerAtk = this.playerAtk[index]; 
        string effectName = this.effectName[index];
        AudioSource audio = this.audio[index];

        // ������ �ߴ��� �Ǵ�, 
        if (canAttack == false)
            return;

        if (playerMp < playerCost)
            return;

        enemy.Hit(playerAtk);

        playerMp -= playerCost; //������ 0�� ��� ������.

        uiUserInfo.ChangePlayerInfo(playerHp, playerMp);

        audio.Play();
        GameObject effectRes = Resources.Load<GameObject>(effectName);
        Instantiate(effectRes, enemy.transform.position + Vector3.back, effectRes.transform.rotation);

        canAttack = false;
        // 4�� ��Ÿ���� ���� ����.
        // Invoke
        Invoke(nameof(DelayReset), 4);
        //������ ������
    }

    //������ �ʱ�ȭ
    void DelayReset()
    {
        canAttack = true;
    }

    //�������� ����
    public void Hit(int damage)
    {
        playerHp -= damage;
        if (playerHp <= 0)
        {
            playerHp = 0;
            //����  ����
        }
        uiUserInfo.ChangePlayerInfo(playerHp, playerMp);

    }
}
