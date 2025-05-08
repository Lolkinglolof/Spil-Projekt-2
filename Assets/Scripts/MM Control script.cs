using UnityEngine;
using UnityEngine.SceneManagement;

public class MMControlscript : MonoBehaviour
{
    public Canvas canvas;
    public GameObject Object_Hit;
    public Material Green;
    public Material Red;
    public Material Base;
    public string Level;
    public GameObject Prev_Hit;
    public GameObject LevelSelector;
    Material Mat;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D Hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        Object_Hit = Hit.collider.gameObject;
        if (Hit != false && Hit.collider.gameObject.name != "Square")
        {
            Prev_Hit = Hit.collider.gameObject;
            string Htag = Hit.collider.tag;
            switch (Htag)
            {
                case "Play":
                    Mat = Green;
                    break;
                case "Quit":
                    Mat = Red;
                    break;
            }

            Hit.collider.transform.GetChild(1).GetComponent<SpriteRenderer>().material = Mat;
            if (Input.GetMouseButton(0))
            {
                switch (Htag)
                {
                    case "Play":
                        PlayerPrefs.SetInt("UseTimer", 1);
                        SceneManager.LoadScene(Level);
                        break;
                    case "Quit":
                        Application.Quit();
                        break;
                    case "LevelSelect":
                        LevelSelector.transform.position = new Vector3(0,0,-5);
                        canvas.GetComponent<Canvas>().enabled = false;
                        gameObject.SetActive(false);
                        break;

                }
            }
        }
        else if (Prev_Hit.name != "Square")
        {
            Prev_Hit.transform.GetChild(1).GetComponent<SpriteRenderer>().material = Base;
        }
    }
}
