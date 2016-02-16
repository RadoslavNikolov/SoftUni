namespace Count_Subseq_Occurences
{
    using System;

    public class StringSearcher  // Knuth-Morris-Pratt string search
    {
        private char[] W;  // the (small) pattern to search for
        private int[] T;   // lets the search function to skip ahead

        public StringSearcher(char[] W)
        {
            this.W = new char[W.Length];
            Array.Copy(W, this.W, W.Length);
            this.T = BuildTable(W);           // use a helper to build T
        }

        private int[] BuildTable(char[] W)
        {
            int[] result = new int[W.Length];
            int pos = 2;
            int cnd = 0;
            result[0] = -1;
            result[1] = 0;
            while (pos < W.Length)
            {
                if (W[pos - 1] == W[cnd])
                {
                    ++cnd; result[pos] = cnd; ++pos;
                }
                else if (cnd > 0)
                    cnd = result[cnd];
                else
                {
                    result[pos] = 0; ++pos;
                }
            }
            return result;
        }

        public int Search(char[] S)
        {
            // look for this.W inside of S
            int m = 0;
            int i = 0;
            while (m + i < S.Length)
            {
                if (this.W[i] == S[m + i])
                {
                    if (i == this.W.Length - 1)
                        return m;
                    ++i;
                }
                else
                {
                    m = m + i - this.T[i];
                    if (this.T[i] > -1)
                        i = this.T[i];
                    else
                        i = 0;
                }
            }
            return -1;  // not found
        }
    }
}