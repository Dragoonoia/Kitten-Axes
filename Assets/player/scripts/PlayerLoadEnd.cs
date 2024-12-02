using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Fusion;

public class PlayerLoadEnd : NetworkBehaviour
{
    [SerializeField] private GameObject Loading;
    [SerializeField] private GameObject Win;
    [SerializeField] private GameObject Loose;
    private bool Won;
    Finisher LineFinish;
    void Awake()
    {
        
            Loading = GameObject.FindGameObjectWithTag("LoadingScreen");
            Win = GameObject.FindGameObjectWithTag("WinScreen");
            Loose = GameObject.FindGameObjectWithTag("LooseScreen");
            LineFinish = GameObject.FindGameObjectWithTag("FinishLine").GetComponent<Finisher>();
            Loading.gameObject.SetActive(false);
            Win.gameObject.SetActive(false);
            Loose.gameObject.SetActive(false);
            Won = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Won && LineFinish.P1Finished == true && HasStateAuthority)
        {
            Loose.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("FinishLine") && HasStateAuthority)
        {
            Win.gameObject.SetActive(true);
            LineFinish.P1Finished = true;
            Won = true;
        }

    }
}
