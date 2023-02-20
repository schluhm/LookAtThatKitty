using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Chess
{
    public class Chessboard : MonoBehaviour
    {
        [SerializeField] private PromptController controller;
        public List<GameObject> chessFigures;
        
        [SerializeField] private float tileSize;
        [SerializeField] private float tileOffset;
        [SerializeField] private Vector2 boardOffset;
        [SerializeField] private TextAsset puzzleSheet;
        
        private float _selectionX;
        private float _selectionY;
        private readonly ChessFigure[,] _chessFigurePositions = new ChessFigure[8, 8];
        private readonly List<GameObject> _activeFigures = new List<GameObject>();
        private List<string> _riddles;
        private string _solution;
        
        private void Start()
        {
            _riddles = puzzleSheet.text.Split('\n').ToList().Take(10000).ToList();
            _riddles.RemoveAt(0);
        }

        public void TryMove(Vector2 start, Vector2 end)
        {
            var startString = GetTileByPosition(start);
            var endString = GetTileByPosition(end);
            controller.ReportActionSuccess((int)PromptController.Prompt.Checkmate,
                _solution.Contains(startString + endString));
        }
        

        private void SpawnChessFigure(int index, int x, int y)
        {
            var go =
                Instantiate(chessFigures[index], GetTileCenter(x, y), chessFigures[index].transform.rotation);
            go.transform.SetParent(transform);
            _chessFigurePositions[x, y] = go.GetComponent<ChessFigure>();
            _chessFigurePositions[x, y].SetPosition(x, y);
            _chessFigurePositions[x, y].board = this;
            _activeFigures.Add(go);
        }

        private void MoveChessFigure()
        {
            if (_solution.Split(' ').Length <= 1) return;
            var firstMove = _solution.Split(' ')[0];
            var xStart = firstMove[0] - 97;
            var yStart = int.Parse("" + firstMove[1]) - 1;
            var xEnd = firstMove[2] - 97;
            var yEnd = int.Parse("" + firstMove[3]) - 1;
            ChessFigure temp = null;
            if (_chessFigurePositions[xEnd, yEnd] != null)
                temp = _chessFigurePositions[xEnd, yEnd];
            _chessFigurePositions[xEnd, yEnd] = _chessFigurePositions[xStart, yStart];
            _chessFigurePositions[xEnd, yEnd].gameObject.transform.position = GetTileCenter(xEnd, yEnd);
            _chessFigurePositions[xEnd, yEnd].SetPosition(xEnd, yEnd);
            _chessFigurePositions[xStart, yStart] = null;
            if(null != temp)
                Destroy(temp.gameObject);

        }

        public void SetupRiddle()
        {
            if (_activeFigures.Count > 0)
                RemoveAllFigures();
            var riddleString = _riddles[Random.Range(0, _riddles.Count)];
            _solution = riddleString.Split(',')[2];
            var lineIndex = 7;
            foreach (var line in riddleString.Split(",")[1].Split(' ')[0].Split("/"))
            {
                var emptyCounter = 0;
                foreach (var c in line)
                {
                    if (char.IsDigit(c))
                        emptyCounter += int.Parse(c.ToString());
                    else
                    {
                        var figure = 0;
                        switch (c)
                        {
                            case 'K':
                                figure = 0;
                                break;
                            case 'Q':
                                figure = 1;
                                break;
                            case 'R':
                                figure = 2;
                                break;
                            case 'B':
                                figure = 3;
                                break;
                            case 'N':
                                figure = 4;
                                break;
                            case 'P':
                                figure = 5;
                                break;
                            case 'k':
                                figure = 6;
                                break;
                            case 'q':
                                figure = 7;
                                break;
                            case 'r':
                                figure = 8;
                                break;
                            case 'b':
                                figure = 9;
                                break;
                            case 'n':
                                figure = 10;
                                break;
                            case 'p':
                                figure = 11;
                                break;
                        }

                        SpawnChessFigure(figure, emptyCounter, lineIndex);
                        emptyCounter++;
                    }
                }

                lineIndex--;
            }

            MoveChessFigure();
        }

        private void RemoveAllFigures()
        {
            foreach (var figure in _activeFigures.ToList())
            {
                Destroy(figure);
            }
        }

        private Vector2 GetTileCenter(int x, int y)
        {
            var origin = Vector2.zero + boardOffset;
            origin.x += (tileSize * x) + tileOffset;
            origin.y += (tileSize * y) + tileOffset;
            return origin;
        }

        private string GetTileByPosition(Vector2 pos)
        {
            var tile = Vector2.one;
            tile.x = (int)((pos.x - boardOffset.x) / tileSize);
            tile.y = (int)((pos.y - boardOffset.y) / tileSize) + 1;
            return "" + (char)(tile.x + 97) + tile.y;
        }
    }
}