using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class InterfaceAnimationFunctions : MonoBehaviour
{
    [Header("Game Over Screens")]
    public Sprite winScreen;
    public Sprite looseScreen;

    [Header("Game Over Atributes")]
    public Animator anim;
    public Image bg;
    public TMP_Text text;

    private void Start()
    {
        ChangeBackground();
        PlayAnimation(GameOverManager.Condition);
    }
    
    public void ChangeBackground()
    {
        switch (GameOverManager.Condition)
        {
            default:
            case "Win":
                bg.sprite = winScreen;
                break;

            case "Lose":
                bg.sprite = looseScreen;
                break;
        }

        text.text += GameOverManager.Condition;
    }

    public void GoToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void PlayAnimation(string animName)
    {
        anim.Play(animName);
    }
}
