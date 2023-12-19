namespace DynamicMatrix_DLL
{
    public static class DynamicMatrix
    {
        public static float[,] ConvertToFloatMatrix(in int[,] intMatrix, IntPtr rows, IntPtr cols)
        {


            float[,] floatMatrix = new float[rows, cols];

            for (IntPtr i = 0; i < rows; ++i)
            {
                for (IntPtr j = 0; j < cols; ++j)
                {
                    floatMatrix[i, j] = (float)(intMatrix[i, j]);
                }
            }

            return floatMatrix;
        }
        public static int SummInt(int num1, int num2)
        {
            return num1 + num2;
        }








        /*    Операция суммирования матриц -
              Работает для матриц одинаковых размеров     */
        public static int[,] AddMatrixInt(int[,] matrix1, int[,] matrix2, IntPtr rows, IntPtr cols)
        {

            int[,] result = new int[rows, cols];


            for (IntPtr i = 0; i < rows; ++i)
            {
                for (IntPtr j = 0; j < cols; ++j)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return result;
        }



        public static float[,] AddMatrixFloat(float[,] matrix1, float[,] matrix2, IntPtr rows, IntPtr cols)
        {

            float[,] result = new float[rows, cols];


            for (IntPtr i = 0; i < rows; ++i)
            {
                for (IntPtr j = 0; j < cols; ++j)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return result;
        }










        /*    Операция вычитания матриц
              Работает для матриц одинаковых размеров    */
        public static int[,] SubtractMatricesInt(int[,] matrix1, int[,] matrix2, IntPtr rows, IntPtr cols)
        {
            if (rows != rows || cols != cols)
            {
                return null;
            }

            int[,] result = new int[rows, cols];

            for (IntPtr i = 0; i < rows; ++i)
            {
                for (IntPtr j = 0; j < cols; ++j)
                {
                    result[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }

            return result;
        }



        public static float[,] SubtractMatricesFloat(float[,] matrix1, float[,] matrix2, IntPtr rows, IntPtr cols)
        {

            if (rows != rows || cols != cols)
            {
                return null;
            }

            float[,] result = new float[rows, cols];


            for (IntPtr i = 0; i < rows; ++i)
            {
                for (IntPtr j = 0; j < cols; ++j)
                {
                    result[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }

            return result;
        }










        /*    Операция перемножения матриц
              Число столбцов в первом сомножителе должно быть равно числу строк во втором  */
        public static int[,] MultiplyMatricesInt(int[,] matrix1, int[,] matrix2, IntPtr rows1, IntPtr cols1, IntPtr rows2, IntPtr cols2)
        {

            if (cols1 != rows2)
            {
                return null;
            }

            int[,] result = new int[rows1, cols2];


            for (IntPtr i = 0; i < rows1; ++i)
            {
                for (IntPtr j = 0; j < cols2; ++j)
                {
                    result[i, j] = 0;
                }
            }

            for (IntPtr i = 0; i < rows1; ++i)
            {
                for (IntPtr j = 0; j < cols2; ++j)
                {
                    for (IntPtr k = 0; k < cols1; ++k)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            return result;
        }




        public static float[,] MultiplyMatricesFloat(float[,] matrix1, float[,] matrix2, IntPtr rows1, IntPtr cols1, IntPtr rows2, IntPtr cols2)
        {

            if (cols1 != rows2)
            {
                return null;
            }

            float[,] result = new float[rows1, cols2];
            for (IntPtr i = 0; i < rows1; ++i)
            {

                for (IntPtr j = 0; j < cols2; ++j)
                {
                    result[i, j] = 0.0f;
                }
            }

            for (IntPtr i = 0; i < rows1; ++i)
            {
                for (IntPtr j = 0; j < cols2; ++j)
                {
                    for (IntPtr k = 0; k < cols1; ++k)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            return result;
        }












        // Операция умножения матрицы на число 
        public static int[,] MultiplicationOnNumberInt(int[,] matrix, IntPtr rows, IntPtr cols, int number)
        {

            int[,] result = new int[rows, cols];


            for (IntPtr i = 0; i < rows; ++i)
            {
                for (IntPtr j = 0; j < cols; ++j)
                {
                    result[i, j] = matrix[i, j] * number;
                }
            }

            return result;
        }



        public static float[,] MultiplicationOnNumberFloat(float[,] matrix, IntPtr rows, IntPtr cols, float number)
        {

            float[,] result = new float[rows, cols];



            for (IntPtr i = 0; i < rows; ++i)
            {
                for (IntPtr j = 0; j < cols; ++j)
                {
                    result[i, j] = matrix[i, j] * number;
                }
            }

            return result;
        }











        /*    Операция деления матриц
              Умножение первого сомножителя на обратную матрицу второго сомножителя    */
        public static float[,] DivisionMatrixInt(int[,] matrix1, int[,] matrix2, IntPtr rows1, IntPtr cols1, IntPtr rows2, IntPtr cols2)
        {
            float[,] floatMatrix1 = new float[rows1, cols1];

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    floatMatrix1[i, j] = (float)matrix1[i, j];
                }
            }
            float[,] floatMatrix2 = new float[rows2, cols2];

            for (int i = 0; i < rows2; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    floatMatrix2[i, j] = (float)matrix2[i, j];
                }
            }

            if (DeterminantInt(matrix2) == 0)
            {
                return null;
            }
            else
            {
                float[,] result = MultiplyMatricesFloat(floatMatrix1, ReverseMatrix<int>(matrix2, rows2, cols2), rows1, cols1, rows2, cols2);
                return result;
            }

        }




        public static float[,] DivisionMatrixFloat(float[,] matrix1, float[,] matrix2, IntPtr rows1, IntPtr cols1, IntPtr rows2, IntPtr cols2)
        {

            if (Convert.ToInt32(DeterminantFloat(matrix2)) == 0)
            {
                return null;
            }
            else
            {
                float[,] result = MultiplyMatricesFloat(matrix1, ReverseMatrix<float>(matrix2, rows2, cols2), rows1, cols1, rows2, cols2);
                return result;
            }
        }



        /*  Операция нахождения определителя матрицы
            Нельзя найти определитель не квадратной матрицы/вырожденной матрицы
            Если в матрице есть нулевая строка/столбец то определитель равен нулю  */
        public static int DeterminantInt(int[,] matrix)
        {
            IntPtr size = matrix.GetLength(0);
            if (size == 0)
                return 0;
            else if (size == 1)
                return matrix[0, 0];
            else if (size == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                int determinant = 0;

                for (int i = 0; i < size; i++)
                {
                    int[,] subMatrix = CreateSubMatrix<int>(matrix, 0, i);

                    int subDeterminant = DeterminantInt(subMatrix);

                    determinant += matrix[0, i] * subDeterminant * Convert.ToInt32(Math.Pow(-1, i));
                }

                return determinant;
            }


        }

        public static float DeterminantFloat(float[,] matrix)
        {
            IntPtr size = matrix.GetLength(0);
            if (size == 0)
                return 0;
            else if (size == 1)
                return matrix[0, 0];
            else if (size == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                float determinant = 0;

                for (int i = 0; i < size; i++)
                {
                    float[,] subMatrix = CreateSubMatrix<float>(matrix, 0, i);

                    float subDeterminant = DeterminantFloat(subMatrix);

                    determinant += matrix[0, i] * subDeterminant * Convert.ToSingle(Math.Pow(-1, i));
                }

                return determinant;
            }

        }

        static T[,] CreateSubMatrix<T>(T[,] matrix, int row, int col)
        {
            int size = matrix.GetLength(0);

            T[,] subMatrix = new T[size - 1, size - 1];

            int subRow = 0;

            for (int i = 0; i < size; i++)
            {
                int subCol = 0;

                if (i != row)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (j != col)
                        {
                            subMatrix[subRow, subCol] = matrix[i, j];
                            subCol++;
                        }
                    }

                    subRow++;
                }
            }

            return subMatrix;
        }




        // Операция транспонирования матрицы

        public static T[,] Transposition<T>(T[,] matrix, IntPtr rows, IntPtr cols)
        {

            T[,] result = new T[cols, rows];



            for (IntPtr i = 0; i < rows; ++i)
            {
                for (IntPtr j = 0; j < cols; ++j)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return result;
        }



        /*    Операция нахождения обратной матрицы
              Если матрица вырожденная или неквадратная, то она не имеет обратной матрицы
              Обратная матрица существует, если определитель не равен нулю    */
        public static float[,] ReverseMatrix<T>(T[,] matrix, IntPtr rows, IntPtr cols)
        {
            int n = matrix.GetLength(0);
            float[,] augmentedMatrix = new float[n, 2 * n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    augmentedMatrix[i, j] = Convert.ToSingle(matrix[i, j]);
                    augmentedMatrix[i, j + n] = (i == j) ? 1 : 0;
                }
            }


            for (int i = 0; i < n; i++)
            {

                if (augmentedMatrix[i, i] == 0)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (augmentedMatrix[j, i] != 0)
                        {
                            SwapRows(augmentedMatrix, i, j);
                            break;
                        }
                    }
                }


                float leadingElement = augmentedMatrix[i, i];
                for (int j = i; j < 2 * n; j++)
                {
                    augmentedMatrix[i, j] /= leadingElement;
                }


                for (int j = 0; j < n; j++)
                {
                    if (j != i)
                    {
                        float multiplier = augmentedMatrix[j, i];
                        for (int k = i; k < 2 * n; k++)
                        {
                            augmentedMatrix[j, k] -= multiplier * augmentedMatrix[i, k];
                        }
                    }
                }
            }

            float[,] inverseMatrix = new float[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    inverseMatrix[i, j] = augmentedMatrix[i, j + n];
                }
            }

            return inverseMatrix;

        }

        private static void SwapRows<T>(T[,] matrix, int row1, int row2)
        {
            int n = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                T temp = matrix[row1, i];
                matrix[row1, i] = matrix[row2, i];
                matrix[row2, i] = temp;
            }
        }

    }

}
