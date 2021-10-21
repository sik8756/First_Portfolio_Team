using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ability : MonoBehaviour
{

    public Image Player;

    public GameObject abilityPanel;
    public Button abilityButten;

    bool isabilityActive = false;
    void Start()
    {
        //abilityButten에 클릭하면 ExitButton 함수가 발동되게끔 설정 
        abilityButten.onClick.AddListener(ExitButton);
    }

    void Update()
    {
        //마우스 클릭이 되엇다면
        if (Input.GetMouseButtonUp(0))
            //Rayability() 함수를 실행
            Rayability();
    }


    public void Rayability()
    {
        //스마트폰 터치로 touch 
        Touch touch = Input.GetTouch(0);

        Vector3 Pos = Camera.main.ScreenToWorldPoint(touch.position);
        Pos.z = -10;

        RaycastHit2D hit2D = Physics2D.Raycast(Pos, transform.forward, 30);

        if(hit2D.collider != null)
        {
            if (hit2D.collider.CompareTag("Ability"))
            {
                if(!isabilityActive)
                {
                    Activeability(true);
                    Player.sprite = Inventory.instance.Player.sprite;
                }
            }
        }

    }

    public void Activeability(bool isOpen)
    {
        isabilityActive = isOpen;
        abilityPanel.SetActive(isOpen);
    }

    public void ExitButton()
    {
        Activeability(false);
    }
}
