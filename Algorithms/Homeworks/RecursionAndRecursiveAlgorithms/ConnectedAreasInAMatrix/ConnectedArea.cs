namespace ConnectedAreasInAMatrix
{
    using System;

    class ConnectedArea : IComparable<ConnectedArea>
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Size { get; set; }

        public int CompareTo(ConnectedArea other)
        {
            int sizeCompareResult = -this.Size.CompareTo(other.Size);

            if (sizeCompareResult == 0)
            {
                int xCompareResult = this.X.CompareTo(other.X);

                if (xCompareResult == 0)
                {
                    int yCompareResult = this.Y.CompareTo(other.Y);

                    return yCompareResult;
                }

                return xCompareResult;
            }

            return sizeCompareResult;
        }
    }
}
