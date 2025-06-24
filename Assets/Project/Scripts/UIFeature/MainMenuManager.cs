using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MultiplayerTest.Scripts.UIFeature
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private Button _hostButton;
        [SerializeField] private Button _clientButton;
        [SerializeField] private Button _exitButton;

        private void Awake()
        {
            _hostButton.onClick.AddListener(OnHostButtonClicked);
            _clientButton.onClick.AddListener(OnClientButtonClicked);
            _exitButton.onClick.AddListener(OnExitButtonClicked);
        }

        private void OnHostButtonClicked()
        {
            NetworkManager.Singleton.StartHost();
            NetworkManager.Singleton.SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }

        private void OnClientButtonClicked()
        {
            NetworkManager.Singleton.StartClient();
        }

        private void OnExitButtonClicked()
        {
            Application.Quit();
            Debug.Log("Application exited.");
        }
    }
}