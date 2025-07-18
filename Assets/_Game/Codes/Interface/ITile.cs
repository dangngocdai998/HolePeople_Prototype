using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HolePeople
{
    public interface ITile
    {
        public Vector2Int GetPosTile();
        public string GetKeyTile();

        public TypeEntity GetTypeEntity();
        public ColorType GetColorTypeEntity();
    }
}
