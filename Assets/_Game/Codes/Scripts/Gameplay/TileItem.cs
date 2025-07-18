using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HolePeople
{
    public class TileItem : MonoBehaviour, ITile
    {
        [Header("Setup")]
        [SerializeField] Vector2Int posTile;
        [SerializeField] Entity entity;
        void Start()
        {
            posTile = new Vector2Int((int)transform.position.x, (int)transform.position.y);
            GameplayManager.Instance.AddTileOnGrid(this);
        }

        public Vector2Int GetPosTile()
        {
            return posTile;
        }
        public string GetKeyTile()
        {
            Debug.Log(posTile.ToString());
            return posTile.ToString();
        }
        public TypeEntity GetTypeEntity()
        {
            if (entity)
                return entity.GetTypeEntity();
            return TypeEntity.None;
        }

        public ColorType GetColorTypeEntity()
        {
            if (entity)
                return entity.GetColorTypeEntity();
            return ColorType.None;
        }
    }
}
