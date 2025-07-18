using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HolePeople
{
    public interface ITile
    {
        public Vector2 GetPosTile();
        public string GetKeyTile();

        public TypeEntity GetTypeEntity();
        public ColorType GetColorTypeEntity();
    }
}
