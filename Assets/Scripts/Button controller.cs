using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttoncontroller : MonoBehaviour
{
    public bool MenuButton;
    string menuText = "Return to Menu";
    string restartText = "Restart Level";
    public TextMeshPro TextObject;
    string WinControlObjectTag = "wincontrol";
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
        if (Input.GetMouseButton(0) && Hit.collider.gameObject.tag == "restart")
        {

            GameObject.FindWithTag(WinControlObjectTag).GetComponent<WinControl>().Restart();
        }
        else if (Input.GetMouseButton(0) && Hit.collider.gameObject.tag == "menu" || Input.GetKey(KeyCode.Escape))
        {

            SceneManager.LoadScene("Main Menu");
        }
          
    }
}
