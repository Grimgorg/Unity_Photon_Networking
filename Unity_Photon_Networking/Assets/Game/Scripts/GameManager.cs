using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Com.GrimGames.Agility
{
    /// <summary>
    /// This class manages the switching between scenes/maps.
    /// </summary>
    public class GameManager : Photon.PunBehaviour
    {
        #region Photon Messages
        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }

        public override void OnPhotonPlayerConnected(PhotonPlayer other)
        {
            Debug.Log("OnPhotonPlayerConnected() " + other.NickName);
        }

        public override void OnPhotonPlayerDisconnected(PhotonPlayer other)
        {
            Debug.Log("OnPhotonPlayerDisconnected() " + other.NickName);
        }
        #endregion



        #region public Methods
        public void LeaveGame()
        {
            PhotonNetwork.LeaveRoom();
        }
        #endregion
    }
}