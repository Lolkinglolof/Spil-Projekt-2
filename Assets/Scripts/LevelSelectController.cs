using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectController : MonoBehaviour
{
    public Material green;
    public Material purple;
    public GameObject Controller;
    public Canvas canvas;
    public GameObject Menu;
    public GameObject level1But;
    public GameObject level2But;
    public GameObject level3But;
    public GameObject level4But;
    public GameObject level5But;
    public GameObject level6But;
    public GameObject level7But;
    public GameObject level8But;
    public GameObject level9But;
    GameObject Object_Hit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D Hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        Object_Hit = Hit.collider.gameObject;
        if (Hit != false && Hit.collider.gameObject.name != "Square" || Hit.collider.gameObject.name != "circle")
        {
            Object_Hit.transform.GetChild(1).GetComponent<SpriteRenderer>().material = green;

            if (Input.GetMouseButton(0))
            {

                string HitName = Object_Hit.name;
                if (HitName.Contains("Level"))
                {
                    switch (HitName)
                    {
                        case "Level 1":
                            SceneManager.LoadScene("LevelZero");
                            break;
                        case "Level 2":
                            SceneManager.LoadScene("LevelOne");
                            break;
                        case "Level 3":
                            SceneManager.LoadScene("LevelTwo");
                            break;
                        case "Level 4":
                            SceneManager.LoadScene("LevelThree");
                            break;
                        case "Level 5":
                            SceneManager.LoadScene("LevelSpikeIntro");
                            break;
                        case "Level 6":
                            SceneManager.LoadScene("SpikeEasy");
                            break;
                        case "Level 7":
                            SceneManager.LoadScene("LevelSpike");
                            break;
                        case "Level 8":
                            SceneManager.LoadScene("PortalIntro");
                            break;
                        case "Level 9":
                            SceneManager.LoadScene("LevelNew");
                            break;
                    }
                }
                else if (Object_Hit.tag == "menu")
                {
                    Menu.transform.position = new Vector2(100, 100);
                    canvas.GetComponent<Canvas>().enabled = true;
                    Controller.SetActive(true);
                }

            }
        }

    }
}
