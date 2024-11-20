
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuManager : MonoBehaviour
{
    

    [SerializeField] private GameObject Painel1;
    [SerializeField] private GameObject Painel2;
    [SerializeField] private GameObject map;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject controls;

    [SerializeField] private Slider desliza;
    MapAnimation abacate;

  


    void Start()
    {
        Painel1.gameObject.SetActive(false);
        Painel2.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
        controls.gameObject.SetActive(false);
        abacate = map.GetComponent<MapAnimation>();

        
    }

    private void Update()
    {
        
    }

    public void ZuadaDaPorra()
    {
        AudioListener.volume = desliza.value;
    }

    public void startarOjoguin(int NextScene)
    {
        SceneManager.LoadScene(NextScene);
    }

    public void OpenOptions()
    {
        abacate.OpenMap();
        Painel1.gameObject.SetActive(true);
        Invoke("OpenOptions2", 0.5f);


    }

    private void OpenOptions2()
    {
        Painel2.gameObject.SetActive(true);
        abacate.KeepMap();

    }

    public void CloseOptions()
    {
        abacate.CloseMap();
        Painel2.gameObject.SetActive(false);
        Invoke("CloseOptions2", 0.5f);
    }

    private void CloseOptions2()
    {
        Painel1.gameObject.SetActive(false);

    }

    public void OpenCredits()
    {
        credits.gameObject.SetActive(true);
    }
    public void CloseCredits()
    {
        credits.gameObject.SetActive(false);
    }

    public void OpenControls()
    {
        controls.gameObject.SetActive(true);
    }
    public void CloseControls()
    {
        controls.gameObject.SetActive(false);
    }
        

    public void QuitGame()
    {
        Application.Quit();
    }

    
}
