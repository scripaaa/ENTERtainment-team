using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtifactSelector : MonoBehaviour
{
    public GameObject artifactPanel;
    public Button doubleJumpButton;
    public Button doubleHPButton;
    public Button jumpAttackButton;

    private Hero playerController;

    void Start()
    {
        // ���� ������
        playerController = FindObjectOfType<Hero>();
        if (playerController != null)
        {
            playerController.canControl = false; // ��������� ����������
        }

        artifactPanel.SetActive(true); // ���������� ����

        // ����������� ������
        doubleJumpButton.onClick.AddListener(() => SelectArtifact("DoubleJump"));
        doubleHPButton.onClick.AddListener(() => SelectArtifact("DoubleHP"));
        jumpAttackButton.onClick.AddListener(() => SelectArtifact("JumpAttack"));
    }

    void SelectArtifact(string artifact)
    {
        // ��������� ��������� ��������
        switch (artifact)
        {
            case "DoubleJump":
                PlayerPrefs.SetInt("DoubleJump", 1);
                Debug.Log("������ DoubleJump");
                break;
            case "DoubleHP":
                PlayerPrefs.SetInt("DoubleHP", 1);
                Debug.Log("������ DoubleHP");
                break;
            case "JumpAttack":
                PlayerPrefs.SetInt("JumpAttack", 1);
                Debug.Log("������ JumpAttack");
                break;
        }

        PlayerPrefs.Save(); // ��������� ���������
        HideArtifactPanel();
    }

    void HideArtifactPanel()
    {
        artifactPanel.SetActive(false); // �������� ����
        if (playerController != null)
        {
            playerController.canControl = true; // ��������� ����������
        }

        // ��������� ��������� � ������
        ApplyArtifacts();
    }

    void ApplyArtifacts()
    {
        if (playerController != null)
        {
            playerController.ApplyArtifactEffects();
        }
    }
}