using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;

    private int currentIndex;

    void Start()
    {
        SelectCharacter(0);
    }

    public void NextCharacter()
    {
        currentIndex++;

        if (currentIndex >= characters.Length)
        {
            currentIndex = 0;
        }

        SelectCharacter(currentIndex);
    }

    void SelectCharacter(int index)
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(i == index);
        }
    }
}
