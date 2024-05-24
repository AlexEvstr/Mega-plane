using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuySkinButton : MonoBehaviour
{
    [SerializeField] private GameObject _clicked;
    [SerializeField] private int _totalCost;
    [SerializeField] private GameObject _cost;
    [SerializeField] private GameObject _choosen;

    [SerializeField] private MenuMusicController _menuMusicController;

    private void Start()
    {
        string planeName = PlayerPrefs.GetString("Plane", "");
        if (gameObject.name == planeName)
            _clicked.transform.SetParent(gameObject.transform);
    }

    public void ChooseThisPlane()
    {
        if (!_choosen.activeInHierarchy)
        {
            MainMenuManager.Coins -= _totalCost;
            PlayerPrefs.SetInt("coinsCount", MainMenuManager.Coins);
            SaveStatus();
            _menuMusicController.BuySound();
        }
        else
        {
            _menuMusicController.ClickSound();
        }

        PlayerPrefs.SetString("Plane", gameObject.name);
        _clicked.transform.SetParent(gameObject.transform);
        MakeBought();
    }

    private void SaveStatus()
    {
        if (gameObject.name == "0") PlayerPrefs.SetString("plane_0", "unlocked");
        else if (gameObject.name == "1") PlayerPrefs.SetString("plane_1", "unlocked");
        else if (gameObject.name == "2") PlayerPrefs.SetString("plane_2", "unlocked");
    }

    private void Update()
    {
        CheckPlane();
        CheckCost();
        CheckState();
    }

    private void CheckPlane()
    {
        if (gameObject.transform.childCount == 4)
            gameObject.GetComponent<Image>().color = Color.green;
        else
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
    }

    private void CheckCost()
    {
        if (_totalCost > MainMenuManager.Coins && !_choosen.activeInHierarchy)
            gameObject.GetComponent<Button>().interactable = false;
        else
            gameObject.GetComponent<Button>().interactable = true;
    }

    private void CheckState()
    {
        if (gameObject.name == "0")
        {
            if (PlayerPrefs.GetString("plane_0", "") != "") MakeBought();
        }


        else if (gameObject.name == "1")
        {
            if (PlayerPrefs.GetString("plane_1", "") != "") MakeBought();
        }

        else if (gameObject.name == "2")
        {
            if (PlayerPrefs.GetString("plane_2", "") != "") MakeBought();
        }

    }

    private void MakeBought()
    {
        _cost.SetActive(false);
        _choosen.SetActive(true);
    }
}