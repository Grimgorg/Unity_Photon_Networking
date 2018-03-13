using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Com.GrimGames.Agility
{
    /// Player name input field. Let the user input his name, will appear above the player in the game.
    [RequireComponent(typeof(InputField))]
    public class PlayerNameInputField : MonoBehaviour
    {
        #region Private Variables
        // Store the PlayerPref Key to avoid typos
        static string playerNamePrefKey = "PlayerName";
        #endregion



        #region MonoBehaviour CallBacks
        /// called on GameObject by Unity during initialization phase.
        void Start()
        {
            string defaultName = "";
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
        /// Sets the name of the player, and save it in the PlayerPrefs for future sessions.
        public void SetPlayerName(string value)
        {
            //  force a trailing space string in case value is an empty string, else playerName would not be updated.
            PhotonNetwork.playerName = value + " ";

            PlayerPrefs.SetString(playerNamePrefKey, value);
        }
        #endregion
    }
}