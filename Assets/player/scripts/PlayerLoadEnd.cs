using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Fusion;

public class PlayerLoadEnd : NetworkBehaviour
{
    [SerializeField] private GameObject Loading;
    [SerializeField] private GameObject Win;
    [SerializeField] private GameObject Loose;
    [SerializeField] private bool Won;
    Finisher LineFinish;
    [SerializeField] private bool StartedCheck;
    void Awake()
    {
        
            Loading = GameObject.FindGameObjectWithTag("LoadingScreen");
            Win = GameObject.FindGameObjectWithTag("WinScreen");
            Loose = GameObject.FindGameObjectWithTag("LooseScreen");
            LineFinish = GameObject.FindGameObjectWithTag("FinishLine").GetComponent<Finisher>();
            Won = false;
        
    }

    // Update is called once per frame
    public override void FixedUpdateNetwork()
    {
        if (Runner.SessionInfo.PlayerCount == 2 && !StartedCheck)
        {
            Loading.gameObject.SetActive(false);
            Win.gameObject.SetActive(false);
            Loose.gameObject.SetActive(false);
            StartedCheck = true;
        }


        if (Won == false && LineFinish.P1Finished == true && HasStateAuthority)
        {
            Debug.Log("abacate");
            Loose.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("FinishLine") && HasStateAuthority && !LineFinish.P1Finished)
        {
            Win.gameObject.SetActive(true);
            LineFinish.P1Finished = true;
            Won = true;
        }

    }
}
