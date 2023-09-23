using System;


class mymatrix
{
    private int n;
    private int m;
    private double[,] arr;
    
    public mymatrix (int n, int m, int max, int min)
    {
        Random rand = new Random();
        this.n = n;
        this.m = m;
        arr = new double[n, m];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                arr[i, j] = rand.Next(min, max);

    }
    public mymatrix(double[,] arr)
    {
        this.n = arr.GetLength(0);
        this.m = arr.GetLength(1);
        this.arr = arr;
    }

    public mymatrix (int n, int m)
    {
       this.n= n;
        this.m = m;
        arr=new double[n, m];
    }

    public int N
    {
        get { return n; }
        set { if (value > 0) n = value; }
    }

    public int M
    {
        get { return m; }
        set { if (value > 0) m = value; }
    }

    public double this[int n, int m]
    {
        get
        {
            return arr[n, m];
        }
        set
        {
            arr[n, m] = value;
        }
    }

    public mymatrix multiplication_int(int n,mymatrix mym) 
    {
        mymatrix rezmatrix = new mymatrix(mym.N,mym.M );
        for (int i = 0; i < mym.N; i++)
        {
            for (int j = 0; j < mym.M; j++)
            {
                rezmatrix[i, j] = mym[i, j]*n;
            }
        }
        return rezmatrix;
    }

    public mymatrix dividing_int(int n, mymatrix mym)
    {
        mymatrix rezmatrix = new mymatrix(mym.N, mym.M);
        for (int i = 0; i < mym.N; i++)
        {
            for (int j = 0; j < mym.M; j++)
            {
                rezmatrix[i, j] = mym[i, j]/n;
            }
        }
        return rezmatrix;
    }
    public mymatrix multiplication(mymatrix a,mymatrix b)
    {
        if (a.M == b.N)
        {
            mymatrix rezmatrix = new mymatrix(a.N, b.M);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < a.M; j++)
                {
                    for (int k = 0; k < b.M; k++)
                    {
                        rezmatrix[i, j] += a[i, k] * b[k, j];

                    }
                }
            }
            return rezmatrix;
        }
        else { return a; }
       
    }
    public mymatrix adding (mymatrix a,mymatrix b)
    {
        mymatrix rezmatrix = new mymatrix(a.N, a.M);
        for (int i = 0; i< a.N; i++) 
        {
            for (int j = 0;j< a.M; j++)
            {
                rezmatrix[i,j]= a[i,j]+b[i,j];
            }
        }
        return rezmatrix;
    }

    public mymatrix subtracting(mymatrix a, mymatrix b)
    {
        mymatrix rezmatrix = new mymatrix(a.N, a.M);
        for (int i = 0; i < a.N; i++)
        {
            for (int j = 0; j < a.M; j++)
            {
                rezmatrix[i, j] = a[i, j] - b[i, j];
            }
        }
        return rezmatrix;
    }

    public void print()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(arr[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }



}

namespace part1
{
    class program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность матрицы: строки ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите размерность матрицы: столбцы ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите max ");
            int max = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите min");
            int min = Convert.ToInt32(Console.ReadLine());
            mymatrix A =new mymatrix(n, m, max,min);
            mymatrix B = new mymatrix(n, m, max, min);
            Console.WriteLine("Матрица А: ");
            A.print();
            Console.WriteLine();
            Console.WriteLine("Матрица В: ");
            Console.WriteLine();
            B.print();

            Console.WriteLine("Сложение матриц А и Б: ");
            mymatrix C=A.adding(A, B);
            C.print();

            Console.WriteLine("Вычитание матриц А и Б: ");
            mymatrix D = A.subtracting(A, B);
            D.print();

            Console.WriteLine("Умножение матриц А и Б: ");
            mymatrix E = A.multiplication(A, B);
            E.print();

            Console.WriteLine("Умножение матрицы А на число 5: ");
            mymatrix F = A.multiplication_int(5,A);
            F.print();


        }
    }
}