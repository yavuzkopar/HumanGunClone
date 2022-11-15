using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool IsGameOver { get; private set; }
    public int DamageModifier { get { return PlayerPrefs.GetInt("DamageModifier"); } set { PlayerPrefs.SetInt("DamageModifier", value); } }
    public float WeaponRangeModifier { get { return PlayerPrefs.GetFloat("RangeModifier"); } set { PlayerPrefs.SetFloat("RangeModifier", value); } }
    public static int LastSceneIndex { get { return PlayerPrefs.GetInt("LastScene"); } private set { PlayerPrefs.SetInt("LastScene", value); } }
    //Scriptable object
    public UseableWeaponsObject weaponsObject;

    public Transform DollarTargetPoint;

    [SerializeField] UnityEvent gameOverEvent;
    [SerializeField] UnityEvent LevelComplatedEvent;
    [SerializeField] UnityEvent LevelStarter;

    [SerializeField] DollarUI[] dollars;
    int dolarIndex;

    bool isSccesful;
    

    private void Awake()
    {
        Instance = this;
        isSccesful = false;
        IsGameOver = false;
    }
    public void GameOver()
    {
        IsGameOver = true;
        if (!isSccesful)
            gameOverEvent?.Invoke();
        else
            LevelComplatedEvent?.Invoke();
    }
    //object pool
    public void DollarEnabling()
    {

        if (dolarIndex >= 10)
            dolarIndex = 0;
        dollars[dolarIndex].gameObject.SetActive(true);
        dolarIndex++;
    }
    // in event
    public void GameStarter()
    {
        LevelStarter?.Invoke();
    }
    public void SetSuccessfulEnd(bool value)
    {
        isSccesful = value;
    }
#region Buttons
    public void NextButton()
    {
        LastSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(LastSceneIndex);
    }
    public void ReTryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetRangeModifier()
    {
        WeaponRangeModifier++;
    }
    public void SetDamageModifier()
    {
        DamageModifier++;
    }
#endregion
}

