using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Single;
using System.Drawing;

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

            Matrix<float> mathNetMatrix1 = Matrix<float>.Build.DenseOfArray(floatMatrix1);
            Matrix<float> mathNetMatrix2 = Matrix<float>.Build.DenseOfArray(floatMatrix2);

            if (Convert.ToInt32(mathNetMatrix2.Determinant())== 0){
                return null;
            }
            else
            {
                float[,] result = mathNetMatrix1.Multiply(mathNetMatrix2.Inverse()).ToArray();

                return result;
            }

        }




        public static float[,] DivisionMatrixFloat(float[,] matrix1, float[,] matrix2, IntPtr rows1, IntPtr cols1, IntPtr rows2, IntPtr cols2)
        {   
            Matrix<float> mathNetMatrix1 = Matrix<float>.Build.DenseOfArray(matrix1);
            Matrix<float> mathNetMatrix2 = Matrix<float>.Build.DenseOfArray(matrix2);

            if (Convert.ToInt32(mathNetMatrix2.Determinant()) == 0)
            {
                return null;
            }
            Matrix<float> result=mathNetMatrix1.Multiply(mathNetMatrix2.Inverse());
            return result!.ToArray();


        }











        /*  Операция нахождения определителя матрицы
            Нельзя найти определитель не квадратной матрицы/вырожденной матрицы
            Если в матрице есть нулевая строка/столбец то определитель равен нулю  */
        public static int DeterminantInt(int[,] matrix, IntPtr size)
        {

            float[,] floatMatrix = new float[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    floatMatrix[i, j] = (float)matrix[i, j];
                }
            }
            Matrix<float> mathNetMatrix = DenseMatrix.OfArray(floatMatrix);
            float determinant = mathNetMatrix.Determinant();

            return Convert.ToInt32(determinant);



        }

        public static float DeterminantFloat(float[,] matrix, IntPtr size)
        {

            Matrix<float> mathNetMatrix = DenseMatrix.OfArray(matrix);
            float determinant = mathNetMatrix.Determinant();

            return determinant;
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
            Matrix<float> mathNetMatrix = Matrix<float>.Build.DenseOfArray(matrix);
            Matrix<float> transpositionMatrix = mathNetMatrix.Transpose();
            return transpositionMatrix.ToArray();

        }











        /*    Операция нахождения обратной матрицы
              Если матрица вырожденная или неквадратная, то она не имеет обратной матрицы
              Обратная матрица существует, если определитель не равен нулю    */
        public static float[,] ReverseMatrixInt(int[,] matrix, IntPtr rows, IntPtr cols)
        {
            float[,] floatMatrix = new float[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    floatMatrix[i, j] = (float)matrix[i, j];
                }
            }

            Matrix<float> mathNetMatrix = Matrix<float>.Build.DenseOfArray(floatMatrix);
            Matrix<float> reverseMatrix = mathNetMatrix.Inverse();
            return reverseMatrix.ToArray();
        }



        public static float[,] ReverseMatrixFloat(float[,] matrix, IntPtr rows, IntPtr cols)
        {
            Matrix<float> mathNetMatrix = Matrix<float>.Build.DenseOfArray(matrix);
            Matrix<float> reverseMatrix = mathNetMatrix.Inverse();
            return reverseMatrix.ToArray();

        }


    }

}
