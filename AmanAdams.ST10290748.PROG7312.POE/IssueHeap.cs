using AmanAdams.ST10290748.PROG7312.POE.Models;

//Aman Adams
//ST10290748
//PROG7312
//POE PART 3

namespace AmanAdams.ST10290748.PROG7312.POE
{
    public class IssueHeap
    {
        private List<IssueModel> _heap = new List<IssueModel>();

        public void Insert(IssueModel issue)
        {
            _heap.Add(issue);
            HeapifyUp(_heap.Count - 1);
        }

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parent = (index - 1) / 2;
                if (_heap[parent].CreatedAt >= _heap[index].CreatedAt) break;
                var temp = _heap[parent];
                _heap[parent] = _heap[index];
                _heap[index] = temp;
                index = parent;
            }
        }

        public IssueModel PopMax()
        {
            if (_heap.Count == 0) return null;
            var max = _heap[0];
            _heap[0] = _heap[_heap.Count - 1];
            _heap.RemoveAt(_heap.Count - 1);
            HeapifyDown(0);
            return max;
        }

        private void HeapifyDown(int index)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            int largest = index;

            if (left < _heap.Count && _heap[left].CreatedAt > _heap[largest].CreatedAt) largest = left;
            if (right < _heap.Count && _heap[right].CreatedAt > _heap[largest].CreatedAt) largest = right;

            if (largest != index)
            {
                var temp = _heap[index];
                _heap[index] = _heap[largest];
                _heap[largest] = temp;
                HeapifyDown(largest);
            }
        }
    }

}
//-------------------------------------------------------------END OF FILE-----------------------------------------------------------------//
