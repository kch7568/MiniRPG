using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UITest : MonoBehaviour
{
    public UnityEngine.UI.Image img;
    public UnityEngine.UI.Button btn;
    public UnityEngine.UI.Slider slider;
    public UnityEngine.UI.Text text;

    void Start()
    {
        img.color = Color.white;
        img.color = new Color(0.5f,0.5f,0.5f);
        // img.sprite = null;

        //��ư Ȱ��ȭ
        btn.interactable = true;
       // btn.interactable = false;

        //btn.onClick.AddListner(�Լ�);

        slider.interactable = true;
        //slider.interactable = false;
        slider.minValue = 0;
        slider.maxValue = 100;
        slider.value = 50;

        text.text = "�ȳ��ϼ���.";
        text.fontStyle = FontStyle.Bold;
        text.fontSize = 30;
    }

    void Update()
    {
        
    }
    public void SceneChange()
    {
        SceneManager.LoadScene("UITest2");
    }
}
