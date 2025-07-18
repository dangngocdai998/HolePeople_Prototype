using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace HolePeople
{
    public class GameplayManager : SingletonMonoBehaviour<GameplayManager>
    {
        [Header("Grid")]
        Dictionary<string, ITile> dicGrids = new();



        [Header("Level")]
        [SerializeField] LevelController levelController;
        public Transform RootLevel => levelController.transform;


        [Header("State")]
        GameState gameState = GameState.NotReady;
        public bool IsGameStatePlaying => gameState == GameState.Playing;

        void Start()
        {
            SetGameState(GameState.NotReady);
            LoadLevel();
        }

        #region Level
        void LoadLevel()
        {
            dicGrids.Clear();
            levelController.LoadLevel();

            ChangeGameState(GameState.Ready);
        }
        #endregion

        #region State
        public void ChangeGameState(GameState state)
        {
            if (state == gameState)
                return;
            if (state == GameState.Win && gameState == GameState.Lose)
                return;
            if (state == GameState.Lose && gameState == GameState.Win)
                return;

            SetGameState(state);

        }

        void SetGameState(GameState state)
        {
            gameState = state;
            switch (gameState)
            {
                case GameState.NotReady:

                    break;
                case GameState.Ready:

                    break;
                case GameState.Playing:

                    break;
                case GameState.Win:


                    break;
                case GameState.Lose:

                    break;
            }
        }
        #endregion

        #region Grid
        public void AddTileOnGrid(ITile tile)
        {
            string key = tile.GetKeyTile();
            if (dicGrids.ContainsKey(key))
            {
                Debug.LogError($"Tile {key} already exists");
                return;
            }

            dicGrids.Add(key, tile);
        }
        #endregion

        #region BFS
        public List<ITile> FindTilesStickmanByColor(List<ITile> startTiles, ColorType colorType, int size = 16)
        {
            List<ITile> tileStickmans = new();
            HashSet<ITile> visited = new();
            Queue<ITile> queue = new();

            if (startTiles == null || startTiles.Count <= 0) return tileStickmans;

            foreach (ITile startTile in startTiles)
            {
                queue.Enqueue(startTile);
                visited.Add(startTile);
            }

            while (queue.Count > 0)
            {
                ITile current = queue.Dequeue();

                if (current.GetTypeEntity() == TypeEntity.Stickman && current.GetColorTypeEntity() == colorType)
                {
                    tileStickmans.Add(current);
                    if (tileStickmans.Count >= size)
                    {
                        break;
                    }
                }

                Vector2Int posCurrent = current.GetPosTile();

                //Kiểm tra 4 hướng
                for (int i = 0; i < 4; i++)
                {
                    Vector2Int posNext = GetPosNextByIndex(posCurrent, i);

                    if (dicGrids.ContainsKey(posNext.ToString()))
                    {
                        ITile tileNeighbor = dicGrids[posNext.ToString()];
                        if (IsTileNeighborSatisfy(tileNeighbor, colorType))
                            if (!visited.Contains(tileNeighbor))
                            {
                                visited.Add(tileNeighbor);
                                queue.Enqueue(tileNeighbor);
                            }
                    }
                }
            }

            return tileStickmans;

        }
        Vector2Int GetPosNextByIndex(Vector2Int posCurrent, int index)
        {
            return index switch
            {
                0 => posCurrent + new Vector2Int(0, 1),
                1 => posCurrent + new Vector2Int(0, -1),
                2 => posCurrent + new Vector2Int(1, 0),
                3 => posCurrent + new Vector2Int(-1, 0),
                _ => posCurrent,
            };
        }
        bool IsTileNeighborSatisfy(ITile tile, ColorType color)
        {
            return tile.GetTypeEntity() == TypeEntity.None ||
                         (tile.GetTypeEntity() == TypeEntity.Stickman && tile.GetColorTypeEntity() == color);
        }
        #endregion









    }
}
