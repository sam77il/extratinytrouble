using System.Collections;
using UnityEngine;

public class CoinThrow : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;

    private void Start()
    {
        //StartCoroutine(TestCode()); // for testing, throw a coin after 2 seconds
    }
    private IEnumerator TestCode()
    {
        yield return new WaitForSeconds(2f);
        ThrowCoin();
    }

    public void ThrowCoin()
    {
        // instantiate the coin at the Main Camera position
        // throw it toward mainCamera.forward with some force
        // add rotational force for realism
        GameObject coin = Instantiate(coinPrefab, Camera.main.transform.position + Camera.main.transform.forward * 0.2f, Quaternion.identity);
        Rigidbody rb = coin.GetComponent<Rigidbody>();
        rb.AddForce(Camera.main.transform.forward * 7.5f + new Vector3(0, 2, 0), ForceMode.VelocityChange);
        rb.AddTorque(Random.insideUnitSphere * 2f, ForceMode.VelocityChange);

    }

}
