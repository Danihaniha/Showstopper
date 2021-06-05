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
            // Her m� jeg ogs� prompte dialogpanelet according til Suspect?
            // lage check p� Equipment etter karakternavn + none for non-characters, og s� sjekke igjen her med en if-statement / switch statement.

            // Under if (item.isSuspectItem) s� m� jeg ha en test etter hvilken karakter det er, og ut fra hvilken karakter det er skal tilsvarende dialog komme opp.
            // M� deretter lage en funksjon utenfor dette som kan kalles p� n�r man trykker "Next" i dialogen, for � collecte karakteren + samme for motiv.

            switch (item.characterName)
            {
                case CharacterName.None:
                    break;
                case CharacterName.MikeM1:
                    dialogueUI.SetActive(true);
                    mikeDialogue01.SetActive(true);
                    break;
                case CharacterName.PeggyM1:
                    break;
                case CharacterName.AmeliaM1:
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
