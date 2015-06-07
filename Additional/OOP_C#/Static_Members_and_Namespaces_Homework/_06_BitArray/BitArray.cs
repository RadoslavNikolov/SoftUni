
namespace _06_BitArray
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class BitArray
    {
        public readonly int BitsCount;
        private List<byte> bitsValue = new List<byte>();

        public BitArray(int bitsCount)
        {
            this.BitsCount = bitsCount;
            FillArray();
        }


        private void FillArray()
        {
            for (int i = 0; i < BitsCount; i++)
            {
                bitsValue.Add(0);
            }
        }

        public int this[int index]
        {
            get
            {
                if ((index >= 0) && (index < BitsCount))
                {
                    //Check the bit at position index
                    return bitsValue[index];
                }
                else
                {
                    throw new IndexOutOfRangeException(string.Format("Index {0} is out of range! Must be in ranege [0...{1}]",index,this.BitsCount-1));
                }
            }

            set
            {
                if ((index < 0) || (index > BitsCount - 1))
                {
                    throw new IndexOutOfRangeException(string.Format("Index {0} is out of range! Must be in ranege [0...{1}]", index, this.BitsCount - 1));
                }
                if ((value < 0) || (value > 1))
                {
                    throw new ArgumentOutOfRangeException(string.Format("Value {0} is invalid must be 0 or 1!",value));
                }

                this.bitsValue[this.BitsCount - index - 1] = (byte) value;
            }          
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (byte bit in bitsValue)
            {
                result.Append(bit);
            }
            return result.ToString();
        }
    }
}