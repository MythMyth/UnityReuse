using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject[] menuPages;
    private Stack<int> travelStack = new Stack<int>();
    // Start is called before the first frame update
    void Start()
    {
        foreach(var page in menuPages)
        {
            page.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateView()
    {
        for(int i = 0; i < menuPages.Length; i++)
        {
            bool visible = false;
            if(travelStack.Count > 0) { 
                visible = (i == travelStack.Peek());
            } else
            {
                visible = false;
            }
            menuPages[i].SetActive(visible);
        }
    }

    public void OpenMenu()
    {
        if(menuPages.Length > 0) {
            OpenPage(0);
        }
    }

    public void OpenPage(int pageIndex)
    {
        if (pageIndex < menuPages.Length)
        {
            travelStack.Push(pageIndex);
            UpdateView();
        }
    }

    public void Back()
    {
        travelStack.Pop();
        UpdateView();
    }
}
