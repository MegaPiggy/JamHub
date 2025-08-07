using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JamHub
{
    public class TrifidController : MonoBehaviour
    {
        [SerializeField] private CharacterDialogueTree dialogue;

        /**
         * On awake, do some key setup
         */
        private void Awake()
        {
            if (dialogue == null) dialogue = GetComponentInChildren<CharacterDialogueTree>();
            dialogue.OnStartConversation += CheckFacts;
            CheckFacts();
        }

        /**
         * Set up Trifid's dialogue stuff
         */
        private void CheckFacts()
        {
            var logRevealed = JamSystemHelper.IsFactRevealed("EH_PHOSPHORS_X1");
            PlayerData.SetPersistentCondition("ECHO_HIKE_DONE", logRevealed);
        }
    }
}
