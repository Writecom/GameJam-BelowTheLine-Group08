using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class E_GameState : MonoBehaviour
{
    [Header("Managers")]
    public ButtonManager buttonManager;
    public BarManager barManager;
    public EndOfDayManager endOfDayManager;
    public F_GameState fGamestate;
    public G_GameState gGamestate;

    [Header("Game Objects")]
    public GameObject decisionE;
    public GameObject impactE1;
    public GameObject impactE2;
    public GameObject factE;
    public GameObject continueButtonE;

    [Header("Bools")]
    public bool choiceE1Picked;
    public bool choiceE2Picked;

    [Header("Buttons")]
    public Button buttonE1;
    public Button buttonE2;

    [Header("Choice1")]
    public float costOfChoiceE1;
    public float healthOfChoiceE1;
    public float moodOfChoiceE1;
    public float temporaryIncomeChangeE1;
    public float permanentIncomeChangeE1;

    [Header("Choice 2")]
    public float costOfChoiceE2;
    public float healthOfChoiceE2;
    public float moodOfChoiceE2;
    public float temporaryIncomeChangeE2;
    public float permanentIncomeChangeE2;

    public void ButtonE1Click()
    {
        buttonManager.OnChoiceButtonClick(decisionE, impactE1, continueButtonE);
        barManager.UpdateHealthBar(healthOfChoiceE1);
        barManager.UpdateMoodBar(moodOfChoiceE1);
        barManager.UpdateMoneyBar(costOfChoiceE1);
        choiceE1Picked = true;
    }

    public void ButtonE2Click()
    {
        buttonManager.OnChoiceButtonClick(decisionE, impactE2, continueButtonE);
        barManager.UpdateHealthBar(healthOfChoiceE2);
        barManager.UpdateMoodBar(moodOfChoiceE2);
        barManager.UpdateMoneyBar(costOfChoiceE2);
        choiceE2Picked = true;
    }

    public void ContinueButtonEClick()
    {
        if (impactE1.activeInHierarchy || impactE2.activeInHierarchy)
        {
            // 1: fra consequenceE til factE
            buttonManager.ContinueToFact(impactE1, impactE2, factE);
        }

        else if (factE.activeInHierarchy)
        {
            //2: update daily income text og permanent income
            endOfDayManager.UpdateIncomeForTheDay1(choiceE1Picked, costOfChoiceE1, costOfChoiceE2);
            endOfDayManager.UpdateAverageDailyIncome1(choiceE1Picked, permanentIncomeChangeE1, permanentIncomeChangeE2);

            if (choiceE1Picked)
            {
                //3: knapper, der ikke er råd til ved decisionF skal gøres non-interactable
                buttonManager.DisableButton(fGamestate.costOfChoiceF1, fGamestate.buttonF1, fGamestate.costOfChoiceF2, fGamestate.buttonF2);
            }
            else if (choiceE2Picked)
            {
                //4: knapper, der ikke er råd til ved decisionG skal gøres non-interactable
                buttonManager.DisableButton(gGamestate.costOfChoiceG1, gGamestate.buttonG1, gGamestate.costOfChoiceG2, gGamestate.buttonG2);
            }

            //5: Enables enten decision F eller G
            buttonManager.EnableNextDecision1or2(factE, choiceE1Picked, fGamestate.decisionF, gGamestate.decisionG, continueButtonE);

            //6: checker loosingcondition for enten F eller G
            if (fGamestate.decisionF.activeInHierarchy)
            {
                buttonManager.CheckLoosingCondition(fGamestate.buttonF1, fGamestate.buttonF2);
            }
            else if (gGamestate.decisionG.activeInHierarchy)
            {
                buttonManager.CheckLoosingCondition(gGamestate.buttonG1, gGamestate.buttonG2);
            }
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

