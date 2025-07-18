using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HolePeople
{
    public class LevelController : MonoBehaviour
    {
        protected GameObject CurrentLevel;


        public virtual void CloseLevel()
        {
            if (CurrentLevel != null)
                Destroy(CurrentLevel);
            while (this.transform.childCount > 0)
            {
                var child = this.transform.GetChild(0);
                child.parent = null;
                Destroy(child.gameObject);
            }
        }

        public void IncreaseLevel()
        {

        }



        public virtual void LoadLevel()
        {
            CloseLevel();
            GameplayManager.Instance.ChangeGameState(GameState.Playing);
        }

        public void NextLevel()
        {

        }

        public virtual void Reset()
        {
        }
    }
}
