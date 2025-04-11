using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTest : MonoBehaviour
{
    public Transform target;

    public GameObject effect;
    // 생성
    //1. 만들고싶은 리소스 접근
    //  a. public 변수료 연결
    //  b. 코드로 로드 (Resources)
    //2. 선택 리소스 생성
    void Start()
    {
        //어떤이펙트를, 타겟의 어느위치에 어떤각도로
        //Instantiate(effect,target.position+Vector3.back,effect.transform.rotation);

        // Resources.Load
        GameObject effectRes = Resources.Load<GameObject>("Particles/Hit_2");
        Instantiate(effectRes, target.position + Vector3.back, effect.transform.rotation);

    }

}
