using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_GameState : MonoBehaviour
{
    [Header("Managers")]
    public ButtonManager buttonManager;
    public EndOfDayManager endOfDayManager;
    public BarManager barManager;
    public B_GameState bGamestate;

    [Header("Game Objects")]
    public GameObject decisionA;
    public GameObject impactA1;
    public GameObject impactA2;
    public GameObject factA;
    public GameObject continueButtonA;

    [Header("Bools")]
    public bool choiceA1Picked;
    public bool choiceA2Picked;

    [Header("Choice 1")]
    public float costOfChoiceA1 = -5f;
    public float healthOfChoiceA1 = -5f;
    public float moodOfChoiceA1 = -5f;
    public float temporaryIncomeChangeA1;
    public float permanentIncomeChangeA1;

    [Header("Choice 2")]
    public float costOfChoiceA2;
    public float healthOfChoiceA2;
    public float moodOfChoiceA2;
    public float temporaryIncomeChangeA2;
    public float permanentIncomeChangeA2;

    public void ButtonA1Click()
    {
        buttonManager.OnChoiceButtonClick(decisionA, impactA1, continueButtonA);

        //saml disse linjer til en metode, så alle 3 bar opdateres i en metode.  
        barManager.UpdateHealthBar(healthOfChoiceA1);
        barManager.UpdateMoodBar(moodOfChoiceA1);
        barManager.UpdateMoneyBar(costOfChoiceA1);

        //indsæt i metode, at denne sættes true?
        choiceA1Picked = true;
    }

    public void ButtonA2Click()
    {
        buttonManager.OnChoiceButtonClick(decisionA, impactA2, continueButtonA);
        barManager.UpdateHealthBar(healthOfChoiceA2);
        barManager.UpdateMoodBar(moodOfChoiceA2);
        barManager.UpdateMoneyBar(costOfChoiceA2);
        choiceA2Picked = true;
    }

    public void ContinueButtonAClick()
    {
        if (impactA1.activeInHierarchy || impactA2.activeInHierarchy)
        {
            //1: fra ConsequenceC til factC
            buttonManager.ContinueToFact(impactA1, impactA2, factA);
        }
        else if (factA.activeInHierarchy)
        {
            //2: knapper, der ikke er råd til ved decisionb skal gøres non-interactable
            buttonManager.DisableButton(bGamestate.costOfChoiceB1, bGamestate.buttonB1, bGamestate.costOfChoiceB2, bGamestate.buttonB2);

            //3: updater Income for the day text & permanent income
            endOfDayManager.UpdateIncomeForTheDay1(choiceA1Picked, costOfChoiceA1, costOfChoiceA2);
            endOfDayManager.UpdateAverageDailyIncome1(choiceA1Picked, permanentIncomeChangeA1, permanentIncomeChangeA2);

            //4: fra factB til endOfTheDayScreen og tilføjer daily income til ens moneybar 
            endOfDayManager.EnableEndOfDayScreen(factA);
        }

        else if (endOfDayManager.endOfDayScreen.activeInHierarchy)
        {
            //5: fra endOfTheDayScreen til decision c eller d
            endOfDayManager.DisableEndOfDayScreen(choiceA1Picked, bGamestate.decisionB, bGamestate.decisionB, continueButtonA);

            //6: tjek om loosing conditions bliver mødt (om ingen knapper er interactable og askANeighborg er inaktiv)
            buttonManager.CheckLoosingCondition(bGamestate.buttonB1, bGamestate.buttonB2);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
