using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;
    public GameObject dialogueUI;
    public GameObject mikeDialogue01;
    public GameObject amiliaDialogue01;
    public GameObject peggyDialogue01;
    public GameObject ameliaDialogueM2;
    public GameObject andyDialogueM2;
    public GameObject buzzDialogueM2;
    public GameObject jesseDialogueM2;
    public GameObject fittsDialogueM3;
    public GameObject behavedDialogueM3;
    public GameObject wandaDialogueM3;
    public GameObject anitaDialogueM3;
    public GameObject busterDialogueM3;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    public List<Equipment> items = new List<Equipment>();

    public bool Add (Equipment item)
    {
        if (item.isSuspectItem)
        {
            // Her må jeg også prompte dialogpanelet according til Suspect?
            // lage check på Equipment etter karakternavn + none for non-characters, og så sjekke igjen her med en if-statement / switch statement.

            // Under if (item.isSuspectItem) så må jeg ha en test etter hvilken karakter det er, og ut fra hvilken karakter det er skal tilsvarende dialog komme opp.
            // Må deretter lage en funksjon utenfor dette som kan kalles på når man trykker "Next" i dialogen, for å collecte karakteren + samme for motiv.

            switch (item.characterName)
            {
                case CharacterName.None:
                    break;
                case CharacterName.MikeM1:
                    dialogueUI.SetActive(true);
                    mikeDialogue01.SetActive(true);
                    break;
                case CharacterName.PeggyM1:
                    dialogueUI.SetActive(true);
                    peggyDialogue01.SetActive(true);
                    break;
                case CharacterName.AmeliaM1:
                    dialogueUI.SetActive(true);
                    amiliaDialogue01.SetActive(true);
                    break;
                case CharacterName.AmeliaM2:
                    dialogueUI.SetActive(true);
                    ameliaDialogueM2.SetActive(true);
                    break;
                case CharacterName.BuzzM2:
                    dialogueUI.SetActive(true);
                    buzzDialogueM2.SetActive(true);
                    break;
                case CharacterName.AndyM2:
                    dialogueUI.SetActive(true);
                    andyDialogueM2.SetActive(true);
                    break;
                case CharacterName.JesseM2:
                    dialogueUI.SetActive(true);
                    jesseDialogueM2.SetActive(true);
                    break;
                case CharacterName.MissFittsM3:
                    dialogueUI.SetActive(true);
                    fittsDialogueM3.SetActive(true);
                    break;
                case CharacterName.MissBehavedM3:
                    dialogueUI.SetActive(true);
                    behavedDialogueM3.SetActive(true);
                    break;
                case CharacterName.WandaStraponM3:
                    dialogueUI.SetActive(true);
                    wandaDialogueM3.SetActive(true);
                    break;
                case CharacterName.AnitaTensionM3:
                    dialogueUI.SetActive(true);
                    anitaDialogueM3.SetActive(true);
                    break;
                case CharacterName.BusterBlockM3:
                    dialogueUI.SetActive(true);
                    busterDialogueM3.SetActive(true);
                    break;

                default:
                    break;
            }

            if (items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return false;
            }

            if (items.Contains(item))
                return false;

            items.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }

        if (!item.isSuspectItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return false;
            }

            //la til denne her, la oss teste om man får duplicate av motiver da
            if (items.Contains(item))
                return false;

            items.Add(item);

            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }

        return true;
    }

    public void Remove(Equipment item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
