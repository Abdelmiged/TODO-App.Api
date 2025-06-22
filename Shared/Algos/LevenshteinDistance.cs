using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Algos
{
    public static class LevenshteinDistance
    {
        public static readonly int SimilarityTolerance = 5;
        public static int CalcSimilarity(string source, string target)
        {
            if (string.IsNullOrEmpty(source))
                return target.Length;
            if(string.IsNullOrEmpty(target))
                return source.Length;

            int[,] matrix = new int[source.Length + 1, target.Length + 1];

            for (int i = 0; i <= source.Length; i++)
                matrix[i, 0] = i;
            for (int j = 0; j <= target.Length; j++)
                matrix[0, j] = j;

            int cost = 0;
            for(int i = 1; i <= source.Length; i++)
            {
                for(int j = 1; j <= target.Length; j++)
                {
                    cost = (source[i - 1] == target[j - 1]) ? 0 : 1;

                    matrix[i, j] = Math.Min(Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1), matrix[i - 1, j - 1] + cost);
                }
            }

            return matrix[source.Length, target.Length];
        }
    }
}
