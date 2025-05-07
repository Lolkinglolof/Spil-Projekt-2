using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttoncontroller : MonoBehaviour
{
    public bool MenuButton;
    string menuText = "Return to Menu";
    string restartText = "Restart Level";
    public TextMeshPro TextObject;
    // Start is called before the first frame update
    void Start()
    {

        if (MenuButton)
        {
            TextObject.text = menuText;
        }
        else
        {
            TextObject.text = restartText;
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D Hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButton(0) && Hit == gameObject)
        {
            switch (MenuButton)
            {
                case false:
                    //insert spike function
                    break;
                case true:
                    SceneManager.LoadScene("Main Menu");
                    break;
            }
        }
    }
}
