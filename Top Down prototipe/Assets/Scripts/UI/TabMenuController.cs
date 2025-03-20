using UnityEngine;
using UnityEngine.UI;

public class TabMenuController : MonoBehaviour
{
    public Image[] tabMenu;
    public GameObject[] PagesMenu;
    void Start()
    {
        activeTab(0);
    }

    // Update is called once per frame
    public void activeTab(int index)
    {
        for (int i = 0; i < PagesMenu.Length; i++)
        {
            if (i == index)
            {
                PagesMenu[i].SetActive(true);
                tabMenu[i].color = new Color(1, 1, 1, 1);
            }
            else
            {
                PagesMenu[i].SetActive(false);
                tabMenu[i].color = new Color(1, 1, 1, 0.5f);
            }
        }
    }
}
