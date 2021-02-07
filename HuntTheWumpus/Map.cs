using HuntTheWumpus.GameObjects;

namespace HuntTheWumpus
{
    public class Map
    {
        private readonly byte _mapSize;
        private GameObject[] _gameObjects;
        private int _gameObjectCount;
        private string[,] _map;

        public Map(byte mapSize)
        {
            _map = new string[mapSize, mapSize];
            _gameObjects = new GameObject[100];
            _gameObjectCount = 0;

            for (int y = 0; y < mapSize; y++)
            {
                for (int x = 0; x < mapSize; x++)
                {
                    _map[x, y] = "[ ]";
                }
            }

            this._mapSize = mapSize;
        }

        public void AddObject(GameObject gameObject)
        {
            Coordinates objectCoordinates = gameObject.Coordinates;
            _map[objectCoordinates.X, objectCoordinates.Y] = gameObject.Model;
            _gameObjects[_gameObjectCount] = gameObject;
            _gameObjectCount++;
        }

        public string[,] GetMap()
        {
            return _map;
        }

        public string[,] RenderMap()
        {
            for (int y = 0; y < _mapSize; y++)
            {
                for (int x = 0; x < _mapSize; x++)
                {
                    _map[x, y] = "[ ]";
                }
            }

            for (int i = 0; i < _gameObjectCount; i++)
            {
                GameObject gameObject = _gameObjects[i];
                int x = gameObject.Coordinates.X;
                int y = gameObject.Coordinates.Y;

                _map[x, y] = gameObject.Model;
            }

            return _map;
        }
    }
}
