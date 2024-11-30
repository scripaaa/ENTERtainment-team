using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    GameObject finish; 

    public void Continue() 
    {
        pauseMenu.SetActive(false);
        TimeManager.UnfreezeTime();
    }

    public void MainMenu() 
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex); // ����������� ����� ��� ������
        SceneManager.LoadScene(0);
        TimeManager.UnfreezeTime(); // ������������� ����

        if (finish == null)
            TimeManager.UnfreezeTime(); // ������������� ���� ������ ��� ��-�� ����� ����
    }

    public void NewGame() 
    {
        SceneManager.LoadScene(1);
        TimeManager.UnfreezeTime(); // ������������� ����

        if (finish == null)
            TimeManager.UnfreezeTime(); // ������������� ���� ������ ��� ��-�� ����� ����
    }

    public void Quit() 
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex); // ����������� ����� ��� ������
        Application.Quit();
    }

    void Update()
    {
        GameObject finish = GameObject.FindWithTag("Finish"); // ��������� ���� �� ����� �� ������

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (!pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(true);
                TimeManager.FreezeTime(); // ������������ ����
            }
            else
            {
                pauseMenu.SetActive(false);
                TimeManager.UnfreezeTime(); // ������������� ����
            }
        }
    }
}
