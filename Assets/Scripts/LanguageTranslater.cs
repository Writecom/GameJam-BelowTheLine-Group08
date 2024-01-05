using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageTranslater : MonoBehaviour
{
    [SerializeField]
    private TMP_Text contextAText, choiceA1Text, choiceA2Text, consequensA1Text, consequensA2Text, factsAText;

    public bool isLanguageEnglish = true;

    public void DanishText()
    {
        //isLanguageEnglish = false;
        contextAText.text = "Hawa bliver opmærksom på, at den lokale brønd i hendes landsby er blevet forurenet, " +
            "hvilket medfører betydelige sundhedsrisici. Hun skal beslutte, om hun skal hente vand fra den lokale " +
            "brønd eller investere ekstra tid og kræfter på at rejse til den nærmeste landsby 17 km væk for at hente " +
            "renere vand fra deres brønd.";
        choiceA1Text.text = "Hent forurenet vand fra den lokale brønd.";
        choiceA2Text.text = "Rejs til den nærmeste landsby for at hente renere vand.";
        consequensA1Text.text = "Hawa valgte at hente vand fra deres lokale brønd, hvilket sparede hende en stor mængde " +
            "tid og fysisk anstrengelse. Hun havde mere tid til at arbejde på deres afgrøder, hvilket resulterede i en " +
            "indtjening på 6 dollars ved dagens afslutning. Dog har det forurenede vand sundhedsrisici forbundet med det, " +
            "da det kan forårsage vandbårne sygdomme som diarré og maveinfektioner, og deres søn Joseph begyndte at føle " +
            "sig dårlig efter at have drukket vandet. At vide, at hendes søn måske ville blive syg på grund af det forurenede " +
            "vand, forårsagede hende betydelig angst og tristhed";
        consequensA2Text.text = "Hawa traf den vanskelige beslutning at investere ekstra tid og kræfter for at hente " +
            "renere vand. Selvom vandet var rent og uden forurening, hvilket ikke udgjorde nogen sundhedsrisiko, mistede " +
            "hun en hel dags arbejde på marken, hvilket kun resulterede i en indtjening på 3 dollars. Dette er halvdelen " +
            "af deres gennemsnitlige daglige indkomst på 5 dollars. Den reducerede indkomst skabte en økonomisk belastning " +
            "for deres familie og kunne muligvis true deres umiddelbare behov, hvilket fik hende til at føle sig stresset.";
        factsAText.text = "VIDSTE DU BØRN DØR AF VANDMANGEL";
        
    }

    public void EnglishText()
    {
        contextAText.text = "Hawa becomes aware that their local well in their village has been contaminated, " +
            "which poses with great health risks. She must decide whether to fetch water from their local well " +
            "or invest extra time and effort in traveling to the nearest village 17 km away to fetch cleaner water " +
            "from their well.";
    }
    
    public void OnButtonChangeLanguageClick()
    {
        isLanguageEnglish = !isLanguageEnglish;
        if (isLanguageEnglish == true)
        {
            DanishText();
        }
        else if (! isLanguageEnglish)
        {
            EnglishText();
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
