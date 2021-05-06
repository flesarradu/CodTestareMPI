using System;

namespace MPI_SortCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 10000000;
            int[] a = new int[x];
            int[] b = new int[x];
            int[] c = new int[x];
            int[] d = new int[x];
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < x; i++)
            {
                a[i] = i;
                b[i] = a[i];
                c[i] = a[i];
                d[i] = a[i];
            }
            DateTime now = DateTime.Now;
            //BubbleSort(a);
            Console.WriteLine($"Timpul de executie al BubbleSort cu {a.Length} termeni este {(DateTime.Now - now).TotalSeconds.ToString("N6")} secunde");
            now = DateTime.Now;
            Array.Sort(b);
            Console.WriteLine($"Timpul de executie al QuickSort cu {a.Length} termeni este {(DateTime.Now - now).TotalSeconds.ToString("N6")} secunde");
            now = DateTime.Now;
            //InsertionSort(c);
            Console.WriteLine($"Timpul de executie al InsertionSort cu {a.Length} termeni este {(DateTime.Now - now).TotalSeconds.ToString("N6")} secunde");
            now = DateTime.Now;
            HeapSort(d);
            Console.WriteLine($"Timpul de executie al HeapSort cu {a.Length} termeni este {(DateTime.Now - now).TotalSeconds.ToString("N6")} secunde");
            //Print(a);
            //Console.WriteLine("");
            //Print(b);
            //Console.WriteLine("");
            //Print(c);
            //Console.WriteLine("");
            //Print(d);

        }

        public static void Print(int[] a)
        {
            for(int i = 0; i < a.Length; i++) { Console.Write(a[i] + " "); }
        }
        public static void BubbleSort(int[] a)
        {
            int ok = 0, n = a.Length;
            do {
                ok = 0;
                for(int i = 0; i < n-1; i++) { 
                    if(a[i]>a[i+1]){
                        int aux = a[i];
                        a[i] = a[i + 1];
                        a[i + 1] = aux;
                        ok = 1;
                    }    
                }

            } while (ok == 1);
        }


        public static void InsertionSort(int[] a)
        {
            int n = a.Length,i=0,j=0;

            while (i < n)
            {
                j = i;
                while(j>0 && a[j - 1] > a[j])
                {
                    int aux = a[j];
                    a[j] = a[j - 1];
                    a[j - 1] = aux;
                    j--;
                }
                i++;
            }
        }

        public static int Partition(int[] a, int st, int dr)
        {
            int pivot = a[dr];
            int sti = (st - 1);
            for (int j = st; j < dr; j++)
            {
                if (a[j] <= pivot)
                {
                    sti++;

                    int aux = a[sti];
                    a[sti] = a[j];
                    a[j] = aux;
                }
            }

            int aux2 = a[sti + 1];
            a[sti + 1] = a[dr];
            a[dr] = aux2;

            return sti + 1;
        }

        public static void QuickSort(int[] a, int st, int dr)
        {
            if (st < dr)
            {
                int p = Partition(a, st, dr);
                QuickSort(a, st, p - 1);
                QuickSort(a, p + 1, dr);
            }
        }


        public static void HeapSort(int[] a)
        {
            int n = a.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
                heap(a, n, i);
            for (int i = n - 1; i > 0; i--)
            {    
                int aux = a[0];
                a[0] = a[i];
                a[i] = aux;
                heap(a, i, 0);
            }
        }

        public static void heap(int[] a, int n, int i)
        {
            int max = i; 
            int l = 2 * i + 1; 
            int r = 2 * i + 2; 
            if (l < n && a[l] > a[max])
                max = l;
            if (r < n && a[r] > a[max])
                max = r;
            if (max != i)
            {
                int aux = a[i];
                a[i] = a[max];
                a[max] = aux;
                heap(a, n, max);
            }
        }

    }


}
