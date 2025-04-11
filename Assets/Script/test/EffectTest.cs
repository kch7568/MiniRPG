using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTest : MonoBehaviour
{
    public Transform target;

    public GameObject effect;
    // ����
    //1. �������� ���ҽ� ����
    //  a. public ������ ����
    //  b. �ڵ�� �ε� (Resources)
    //2. ���� ���ҽ� ����
    void Start()
    {
        //�����Ʈ��, Ÿ���� �����ġ�� �������
        //Instantiate(effect,target.position+Vector3.back,effect.transform.rotation);

        // Resources.Load
        GameObject effectRes = Resources.Load<GameObject>("Particles/Hit_2");
        Instantiate(effectRes, target.position + Vector3.back, effect.transform.rotation);

    }

}
