using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace ConsoleApplication2
{
    class Program
    {
        /**<summary>рассчет свертки двух массивов при помощи библиотеки Math.net через матричные преобразования</summary>
         * */
        static void Main(string[] args)
        {
            Vector<double> m1 = Vector<double>.Build.Dense(new double[]{1, 0, 0, 0, 0, 0});
            Vector<double> m2 = Vector<double>.Build.Dense(new double[]{1, 1});
            Console.WriteLine(string.Format("Рассчет свертки массивов: \nпервый вектор {0}\nвторой вектор {1}",m1.ToString(),m2.ToString()));
            
            Matrix<double> matAppend = m1.ToColumnMatrix();
            Matrix<double> mat1 = matAppend.Clone();
            for (int i = 1; i < m2.Count;i++ )
            {
                mat1 = mat1.InsertRow(mat1.RowCount,Vector<double>.Build.Dense(mat1.ColumnCount,0));
                matAppend = matAppend.InsertRow(0, Vector<double>.Build.Dense(new double[] { 0 }));
                mat1 = mat1.Append(matAppend);

            }
            Matrix<double> mat2 = m2.ToColumnMatrix();
            Vector<double> res= mat1*mat2.Column(0);
            Console.WriteLine(String.Format("Свертка равна:\n{0}",res.ToString()));
            Console.ReadLine();
        }
    }
}
