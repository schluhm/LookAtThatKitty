using UnityEngine;

namespace Chess
{
    public abstract class ChessFigure : MonoBehaviour
    {
        public Chessboard board;
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }
        public bool isWhite;
        private Vector2 _mousePosition;
        private Vector2 startPosition;

        public void SetPosition(int x, int y)
        {
            CurrentX = x;
            CurrentY = y;
            startPosition = transform.position;
        }

        public void OnMouseDown()
        {
            transform.position = _mousePosition;
        }

        public void OnMouseDrag()
        {
            transform.position = _mousePosition;
        }

        public void OnMouseUp()
        {
            board.TryMove(startPosition, (Vector2) transform.localPosition);
        }


        private void FixedUpdate()
        {
            _mousePosition = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
        }

        public virtual bool[,] PossibleMove()
        {
            return new bool[8, 8];
        }
    }
}