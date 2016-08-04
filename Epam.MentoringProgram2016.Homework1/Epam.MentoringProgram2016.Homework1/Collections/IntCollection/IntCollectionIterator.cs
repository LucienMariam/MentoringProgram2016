using System.Collections;

namespace SouvenirMarket.AdminService.AdminCollections
{
    public class IntCollectionIterator: IEnumerator
    {
        private IntCollection _outerPointer;
        private int _currentPosition;

        public IntCollectionIterator(IntCollection obj)
        {
            _outerPointer = obj;
            _currentPosition = 0;
        }
        public bool MoveNext()
        {
            if (_currentPosition <= _outerPointer.Count - 1)
            {
                if (_outerPointer[_currentPosition++] < 0)
                    return false;

                return true;
            }

            return false;
        }

        public void Reset()
        {
            _currentPosition = -1;
        }

        public object Current
        {
            get { return _outerPointer[_currentPosition]; }
        }
    }
}
