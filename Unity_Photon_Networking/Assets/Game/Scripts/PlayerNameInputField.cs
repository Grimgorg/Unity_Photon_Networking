using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Com.GrimGames.Agility
{
    [RequireComponent(typeof(InputField))]

    /// <summary>
    /// This class manages the input field for player names.
    /// </summary>
    public class PlayerNameInputField : MonoBehaviour
    {
        #region Private Variables
        // Key for the playername
        static string playerNamePrefKey = "PlayerName";
        #endregion



        #region MonoBehaviour CallBacks
        void Start()
        {
            // Loads the stored playername OR takes a default name.
            string defaultName = "Unknown Soldier";
            InputField _inputField = this.GetComponent<InputField>();

            if (_inputField != null)
            {
                if (PlayerPrefs.HasKey(playerNamePrefKey))
                {
                    defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                    _inputField.text = defaultName;
                }
            }

            PhotonNetwork.playerName = defaultName;
        }
        #endregion


        
        #region Public Methods
        // Sets the name of the player, and save it in the PlayerPrefs for future sessions.
        public void SetPlayerName(string value)
        {
            PhotonNetwork.playerName = value + " ";

            PlayerPrefs.SetString(playerNamePrefKey, value);
        }
        #endregion
    }
}