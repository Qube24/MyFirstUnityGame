using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStats : MonoBehaviour
{
    Slider slider;
    GameObject player;
    Hp playerHp;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHp = player.GetComponent<Hp>();
        slider = gameObject.GetComponentInChildren<Slider>();
        slider.maxValue = playerHp.GetHp();
        slider.value = playerHp.GetHp();
    }

    public void UpdatePlayerHp(int hp)
    {
        slider.value = hp;
    }
}
