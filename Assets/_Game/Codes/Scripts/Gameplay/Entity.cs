using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HolePeople
{
    public class Entity : MonoBehaviour, IEntity
    {
        [Header("Setup")]
        [SerializeField] TypeEntity typeEntity;
        [SerializeField] ColorType colorEntity;



        #region  IEntity

        public TypeEntity GetTypeEntity()
        {
            return typeEntity;
        }

        public ColorType GetColorTypeEntity()
        {
            return colorEntity;
        }
        #endregion


    }
}
