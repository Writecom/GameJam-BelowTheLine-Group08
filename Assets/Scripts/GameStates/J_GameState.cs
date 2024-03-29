using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class J_GameState : MonoBehaviour
{
    [Header("Managers")]
    public ButtonManager buttonManager;
    public BarManager barManager;
    public EndOfDayManager endOfDayManager;

    [Header("Game Objects")]
    public GameObject decisionJ;
    public GameObject impactJ1;
    public GameObject impactJ2;
    public GameObject factJ;
    public GameObject continueButtonJ;

    [Header("Bools")]
    public bool choiceJ1Picked;
    public bool choiceJ2Picked;

    [Header("Buttons")]
    public Button buttonJ1;
    public Button buttonJ2;

    [Header("Choice1 Variables")]
    public float costOfChoiceJ1;
    public float healthOfChoiceJ1;
    public float moodOfChoiceJ1;
    public float temporaryIncomeChangeJ1;
    public float permanentIncomeChangeJ1;

    [Header("Choice 2 Variables")]
    public float costOfChoiceJ2;
    public float healthOfChoiceJ2;
    public float moodOfChoiceJ2;
    public float temporaryIncomeChangeJ2;
    public float permanentIncomeChangeJ2;

    [Header("SceneController")]
    public SceneController1 sceneController;

    public void ButtonJ1Click()
    {
        buttonManager.OnChoiceButtonClick(decisionJ, impactJ1, continueButtonJ);
        barManager.UpdateHealthBar(healthOfChoiceJ1);
        barManager.UpdateMoodBar(moodOfChoiceJ1);
        barManager.UpdateMoneyBar(costOfChoiceJ1);
        choiceJ1Picked = true;
    }

    public void ButtonJ2Click()
    {
        buttonManager.OnChoiceButtonClick(decisionJ, impactJ2, continueButtonJ);
        barManager.UpdateHealthBar(healthOfChoiceJ2);
        barManager.UpdateMoodBar(moodOfChoiceJ2);
        barManager.UpdateMoneyBar(costOfChoiceJ2);
        choiceJ2Picked = true;
    }

    public void ContinueButtonIClick()
    {
        if (impactJ1.activeInHierarchy || impactJ2.activeInHierarchy)
        {
            // 1: fra consequenceJ til factJ
            buttonManager.ContinueToFact(impactJ1, impactJ2, factJ);
        }

        else if (factJ.activeInHierarchy)
        {
            sceneController.PlayWinningScene();
            /*
            //3: update daily income text og permanent income
            endOfDayManager.UpdateIncomeForTheDay1(choiceJ1Picked, costOfChoiceJ1, costOfChoiceJ2);
            endOfDayManager.UpdateAverageDailyIncome1(choiceJ1Picked, permanentIncomeChangeJ1, permanentIncomeChangeJ2);

            //3: fra factB til endOfTheDayScreen og tilføjer daily income til ens moneybar
            endOfDayManager.EnableEndOfDayScreen(factJ);
            */
        }
        else if (endOfDayManager.endOfDayScreen.activeInHierarchy)
        {
            //4: Loads winning screen
            // GAMMLE KODE: SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

            sceneController.PlayWinningScene();
        }
    }
    /*
    public void DisableAANBJ()
    {
        // disabler ask a neighbor button, tiløfjer x antal penge og tjekker loosinjg conditions, hvis man er inde i decisionI
        buttonManager.DisableAskANeighborButton(decisionJ);
    }
    */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
