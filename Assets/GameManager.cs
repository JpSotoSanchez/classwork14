using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public Vector3 spawn = new Vector3(5,5,0);

    private GameObject actual;
    void Start()
    {
        actual = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(int i)
    {
        Destroy(actual);
        actual = Instantiate(playerPrefab, spawn, Quaternion.identity);
        playerMovement mv = actual.GetComponent<playerMovement>();
        mv.powerIndex=i;

    }
}
