using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class InterfaceAnimationFunctions : MonoBehaviour
{
    [Header("Game Over Screens")]
    public Sprite[] winScreen;
    public Sprite looseScreen;
    private int winScreenIndex;

    [Header("Game Over Atributes")]
    public Animator anim;
    public Image bg;
    public Image bg2;
    public TMP_Text text;

    private void Start()
    {
        ChangeBackground();
        PlayAnimation(GameOverManager.Condition);
        winScreenIndex = 0;
    }

    public void ChangeBackground()
    {
        if(GameOverManager.Condition == "Lose")
        {
                bg.sprite = looseScreen;
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

    public void ChangeSprite()
    {
        if (GameOverManager.Condition == "Win")
        {
            bg.sprite = winScreen[winScreenIndex];

            if (winScreenIndex < winScreen.Length)
            {
                winScreenIndex += 1;
            }
        }
    }
}