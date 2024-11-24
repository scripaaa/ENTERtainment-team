using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseArtifact : MonoBehaviour
{
    private Hero hero = FindObjectOfType<Hero>();
    public void ChooseArtifact1()
    {
        Debug.Log("������ 1 ��������");
        Artifact artf = new DoubleJump();
        hero.AddArtifact(artf);
    }
    public void ChooseArtifact2()
    {
        hero.AddArtifact(new ExtraXP());
    }
}
