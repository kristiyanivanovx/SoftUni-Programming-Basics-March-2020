using System.Collections;
using System.Collections.Generic;

namespace Froggy
{
    public class Lake : IEnumerable
    {
        private List<int> stonesUnsorted;

        public Lake(params int[] stonesInput)
        {
            this.stonesUnsorted = new List<int>(stonesInput);
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < this.stonesUnsorted.Count - 1; i += 1)
            {
                yield return stonesUnsorted[i];
                this.stonesUnsorted.Remove(this.stonesUnsorted[i]);
            }

            for (int i = this.stonesUnsorted.Count - 1; i >= 0; i -= 1)
            {
                yield return this.stonesUnsorted[i];
                this.stonesUnsorted.Remove(this.stonesUnsorted[i]);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
