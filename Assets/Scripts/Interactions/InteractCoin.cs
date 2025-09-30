using System.Collections;
using UnityEngine;

public class InteractCoin : Interactables
{
    public override void Use()
    {
        UseHelper();
    }

    private void UseHelper()
    {
        gameObject.SetActive(false);
        Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
        gameObject.GetComponent<CoinThrow>().ThrowCoin();
    }

}
