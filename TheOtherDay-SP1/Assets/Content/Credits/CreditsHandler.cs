using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsHandler : MonoBehaviour
{
    [SerializeField] private Image profileImageObj;
    [SerializeField] private TextMeshProUGUI nameTextObj;
    [SerializeField] private TextMeshProUGUI roleTextObj;
    [SerializeField] private float profileDuration = 5f;
    [SerializeField] private string mainMenuSceneName = "Main Menu";
    [SerializeField] private CreditsProfile[] profiles;

    private void Start()
    {
        StartCoroutine(ChangeProfileSequence());
    }
    private IEnumerator ChangeProfileSequence()
    {
        foreach (CreditsProfile profile in profiles)
        {
            profileImageObj.sprite = profile.profileImage;
            nameTextObj.text = profile.profileName;
            roleTextObj.text = profile.profileRole;
            yield return new WaitForSeconds(profileDuration);
        }
    }

    public void ChangeToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
