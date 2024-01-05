using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class BarManager : MonoBehaviour
{
    public ButtonManager buttonManager;
    public Slider healthBarSlider;
    public Slider moodBarSlider;
    public float moneyValueTotal;
    //public Button choiceB1Button;
    public TMP_Text moneyValueTotalText;
    public SceneController1 sceneController;
    
    [SerializeField]
    private GameObject smiley1, smiley2, smiley3, smiley4;

    /// <summary>
    /// Deactivates all smileys 
    /// </summary>
    private void SetSmileysFalse()
    {
        smiley1.SetActive(false);
        smiley2.SetActive(false);
        smiley3.SetActive(false);
        smiley4.SetActive(false);
    }

    /// <summary>
    /// uses the SceneManager.GetActiveScene to load the Scene +1, which is the GameOverScreen in the buildIndex
    /// </summary>
    public void LoadGameOverScreen()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        //Calls the method from the Scene Controller1 script, in order to get a Coroutine and play our animations
        sceneController.NextScene();
    }

    /// <summary>
    /// Updates the MoneyBar by added the parameter moneyValue to the moneyValue total and overriding this variable and then converting this to a string.
    /// The moneyValueTotalText is then set to this string usng the .text. If the player has 0 or less money and no active askAneighborButton, the
    /// game load the GameOverScreen using the LoadGameOverScreen method
    /// </summary>
    
    public void UpdateMoneyBar(float moneyValue)
    {
        moneyValueTotal += moneyValue;
        moneyValueTotalText.text = moneyValueTotal.ToString();
        if (moneyValueTotal <= 0 && !buttonManager.askANeighborButton.activeInHierarchy)
        {
            LoadGameOverScreen();
        }
    }

    /// <summary>
    /// Same as UpdateMoney bar beside it noes not check for the AANB
    /// </summary>
    public void UpdateHealthBar(float healthValue)
    {
        healthBarSlider.value = healthBarSlider.value + healthValue;
        if (healthBarSlider.value <= 0)
        {
            LoadGameOverScreen();
        }
    }

    /// <summary>
    /// Same as UpdateMoney bar beside it does not check for the AANB.
    /// Changes the icon of the smiley based on the total value of the mood
    /// </summary>

    public void UpdateMoodBar(float moodValue)
    {
        moodBarSlider.value += moodValue;

        if (moodBarSlider.value <= 10 && moodBarSlider.value >= 7.5)
        {
            SetSmileysFalse();
            smiley1.SetActive(true);

        }
        else if (moodBarSlider.value < 7.5 && moodBarSlider.value >= 5)
        {
            SetSmileysFalse();
            smiley2.SetActive(true);

        }
        else if (moodBarSlider.value < 5 && moodBarSlider.value >= 2.5)
        {
            SetSmileysFalse();
            smiley3.SetActive(true);

        }
        else if (moodBarSlider.value < 2.5 && moodBarSlider.value > 0)
        {
            SetSmileysFalse();
            smiley4.SetActive(true);

        }
        else if (moodBarSlider.value <= 0)
        {
            LoadGameOverScreen();
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        moneyValueTotalText.text = moneyValueTotal.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
