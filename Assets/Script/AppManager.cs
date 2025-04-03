using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManager : MonoBehaviour
{
    //GameObject color vector transform 
   public GameObject cube;
   public GameObject light;
   public MeshRenderer ground;
   public Color lightColor;


    private void Start()
    {
        lightColor = Color.blue;
        // cube.SetActive(false);  //Ȱ��ȭ ����

        // Instantiate(cube);   //����(����)
        // Destroy();           // �ı�

        //���׸�Ŭ����
        cube.GetComponent<Rigidbody>().mass = 1000;
        cube.GetComponent<Rigidbody>().useGravity = false;
  
    }

    public void CubeOn()
    {
        cube.SetActive(true);
        light.GetComponent<Light>().color = lightColor;
        ground.material.color = Color.gray;

    }
    public void CubeOff()
    {
        cube.SetActive(false);
    }
    public void SetGroundColor()
    {
        ground.material.color = Color.red;

    }
    public void SetLightColor()
    {
        light.GetComponent<Light>().color = Color.red;
    }
    public void SceneChange()
    {
        SceneManager.LoadScene("GameScene");
    }
}
