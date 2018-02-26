﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenderSharp.Library
{
    class Matrix
    {
        int height; // Number of rows
        int Height
        {
            get
            {
                return height;
            }
        }
        int width; // Number of columns
        int Width
        {
            get
            {
                return height;
            }
        }
        private long[] matrixData;
        public long this[int x, int y] {
            get {
                return matrixData[(y * width) + x];
            }
            set {
                matrixData[(y * width) + x] = value;
            }
        }

        public Matrix(int width, int height) {
            this.height = height;
            this.width = width;
            this.matrixData = new long[height * width];
        }

        public void SetRow(int rowNumber, long[] row) {
            if (rowNumber >= height) {
                throw new IndexOutOfRangeException(String.Format("The row {0} does not exist in a matrix of height {1}", rowNumber, this.height));
            }
            if (row.Length != this.width) {
                throw new Exception(String.Format("The specified row has a Length {0}, but the matrix has a Width {1}", row.Length, this.width));
            }

            for (int columnNumber = 0; columnNumber < width; columnNumber++) {
                this[columnNumber, rowNumber] = row[columnNumber];
            }
        }

        public static Matrix operator +(Matrix m1, Matrix m2) {
            Matrix answer = new Matrix(m1.width, m1.height);
            for (int row = 0; row < answer.height; row++)
            {
                for (int col = 0; col < answer.width; col++)
                {
                    unsafe
                    {
                        answer[col, row] = m1[col, row] + m2[col, row];
                    }
                }
            }
            return answer;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int row = 0; row < this.height; row++) {
                for (int col = 0; col < this.width; col++) {
                    str.AppendFormat("{0} ", this[col, row]);
                    if (col == this.width - 1)
                        str.AppendLine();
                }
            }
            str.AppendLine();
            return str.ToString();
        }
    }
}
