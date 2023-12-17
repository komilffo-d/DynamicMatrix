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
        public static int[,] DivisionMatrixInt(int[,] matrix1, int[,] matrix2, IntPtr rows1, IntPtr cols1, IntPtr rows2, IntPtr cols2)
        {

            if (cols1 != rows2)
            {
                return null;
            }

            int[,] matrix_in = TranspositionInt(matrix2, rows2, cols2);

            int[,] result = new int[rows1, cols2];


            for (IntPtr i = 0; i < rows1; ++i)
            {
                for (IntPtr j = 0; j < cols2; ++j)
                {
                    for (IntPtr k = 0; k < cols1; ++k)
                    {
                        result[i, j] += matrix1[i, k] * matrix_in[j, k];
                    }
                }
            }


            return result;
        }




        public static float[,] DivisionMatrixFloat(float[,] matrix1, float[,] matrix2, IntPtr rows1, IntPtr cols1, IntPtr rows2, IntPtr cols2)
        {

            if (cols1 != rows2)
            {
                return null;
            }

            float[,] matrix_in = TranspositionFloat(matrix2, rows2, cols2);

            float[,] result = new float[rows1, cols2];


            for (IntPtr i = 0; i < rows1; ++i)
            {
                for (IntPtr j = 0; j < cols2; ++j)
                {
                    for (IntPtr k = 0; k < cols1; ++k)
                    {
                        result[i, j] += matrix1[i, k] * matrix_in[j, k];
                    }
                }
            }


            return result;
        }











        /*  Операция нахождения определителя матрицы
            Нельзя найти определитель не квадратной матрицы/вырожденной матрицы
            Если в матрице есть нулевая строка/столбец то определитель равен нулю  */
        public static int DeterminantInt(int[,] matrix, IntPtr size)
        {

            int[][] mat = new int[size][];
            for (IntPtr i = 0; i < size; ++i)
            {
                mat[i] = new int[size];
                for (IntPtr j = 0; j < size; ++j)
                {
                    mat[i][j] = matrix[i, j];
                }
            }

            int det = 1;
            for (IntPtr i = 0; i < size; ++i)
            {
                IntPtr maxRow = i;
                for (IntPtr j = i + 1; j < size; ++j)
                {
                    if (Math.Abs(mat[j][i]) > Math.Abs(mat[maxRow][i]))
                    {
                        maxRow = j;
                    }
                }
                if (maxRow != i)
                {
                    (mat[i], mat[maxRow]) = (mat[maxRow], mat[i]);
                    det = -det;
                }
                if (mat[i][i] == 0)
                {
                    return 0;
                }
                det *= mat[i][i];
                for (IntPtr j = i + 1; j < size; ++j)
                {
                    int factor = mat[j][i] / mat[i][i];
                    for (IntPtr k = i; k < size; ++k)
                    {
                        mat[j][k] -= factor * mat[i][k];
                    }
                }
            }


            return det;
        }

        public static float DeterminantFloat(float[,] matrix, IntPtr size)
        {
            float[][] mat = new float[size][];
            for (IntPtr i = 0; i < size; ++i)
            {
                mat[i] = new float[size];
                for (IntPtr j = 0; j < size; ++j)
                {
                    mat[i][j] = matrix[i, j];
                }
            }

            float det = 1;
            for (IntPtr i = 0; i < size; ++i)
            {
                IntPtr maxRow = i;
                for (IntPtr j = i + 1; j < size; ++j)
                {
                    if (Math.Abs(mat[j][i]) > Math.Abs(mat[maxRow][i]))
                    {
                        maxRow = j;
                    }
                }
                if (maxRow != i)
                {
                    (mat[i], mat[maxRow]) = (mat[maxRow], mat[i]);

                    det = -det;
                }
                if (mat[i][i] == 0)
                {
                    return 0;
                }
                det *= mat[i][i];
                for (IntPtr j = i + 1; j < size; ++j)
                {
                    float factor = mat[j][i] / mat[i][i];
                    for (IntPtr k = i; k < size; ++k)
                    {
                        mat[j][k] -= factor * mat[i][k];
                    }
                }
            }



            return det;
        }











        // Операция транспонирования матрицы

        public static int[,] TranspositionInt(int[,] matrix, IntPtr rows, IntPtr cols)
        {

            int[,] result = new int[cols, rows];



            for (IntPtr i = 0; i < rows; ++i)
            {
                for (IntPtr j = 0; j < cols; ++j)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return result;
        }



        public static float[,] TranspositionFloat(float[,] matrix, IntPtr rows, IntPtr cols)
        {

            float[,] result = new float[cols, rows];


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
        public static int[,] ReverseMatrixInt(int[,] matrix, IntPtr rows, IntPtr cols)
        {

            int[,] augmentedMatrix = new int[rows, 2 * cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    augmentedMatrix[i, j] = matrix[i, j];
                    augmentedMatrix[i, j + cols] = (i == j) ? 1 : 0;
                }
            }


            for (int i = 0; i < rows; i++)
            {
                int scalar = augmentedMatrix[i, i];

                for (int j = 0; j < 2 * cols; j++)
                {
                    augmentedMatrix[i, j] /= scalar==0 ? 1 : scalar;
                }

                for (int k = 0; k < rows; k++)
                {
                    if (k != i)
                    {
                        int factor = augmentedMatrix[k, i];

                        for (int j = 0; j < 2 * cols; j++)
                        {
                            augmentedMatrix[k, j] -= factor * augmentedMatrix[i, j];
                        }
                    }
                }
            }

            int[,] resultMatrix = new int[rows, cols];  
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    resultMatrix[i, j] = augmentedMatrix[i, j + cols];
                }
            }

            return resultMatrix;
        }



        public static float[,] ReverseMatrixFloat(float[,] matrix, IntPtr rows, IntPtr cols)
        {

            float[,] augmentedMatrix = new float[rows, 2 * cols];


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    augmentedMatrix[i, j] = matrix[i, j];
                    augmentedMatrix[i, j + cols] = (i == j) ? 1 : 0;
                }
            }


            for (int i = 0; i < rows; i++)
            {
                float scalar = augmentedMatrix[i, i];

                for (int j = 0; j < 2 * cols; j++)
                {
                    augmentedMatrix[i, j] /= scalar ==0.0f ? 1 : scalar;
                }

                for (int k = 0; k < rows; k++)
                {
                    if (k != i)
                    {
                        float factor = augmentedMatrix[k, i];

                        for (int j = 0; j < 2 * cols; j++)
                        {
                            augmentedMatrix[k, j] -= factor * augmentedMatrix[i, j];
                        }
                    }
                }
            }

            float[,] resultMatrix = new float[rows, cols];


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    resultMatrix[i, j] = augmentedMatrix[i, j + cols];
                }
            }

            return resultMatrix;
        }


    }

}
