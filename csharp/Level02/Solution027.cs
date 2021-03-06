﻿/*
    Problem: 27

    Title: Quadratic primes

    Description:
        Euler discovered the remarkable quadratic formula:
        
            n^2 + n + 41
        
        It turns out that the formula will produce 40 primes for the consecutive values
        n = 0 to 39. However, when n = 40, 40^2 + 40 + 41 = 40(40 + 1) + 41 is
        divisible by 41, and certainly when n = 41, 41^2 + 41 + 41 is clearly divisible
        by 41.
        
        The incredible formula  n^2 − 79n + 1601 was discovered, which produces 80
        primes for the consecutive values n = 0 to 79. The product of the coefficients,
        −79 and 1601, is −126479.
        
        Considering quadratics of the form:
        
            n^2 + an + b, where |a| < 1000 and |b| < 1000
        
            where |n| is the modulus/absolute value of n
            e.g. |11| = 11 and |−4| = 4
        
        Find the product of the coefficients, a and b, for the quadratic expression
        that produces the maximum number of primes for consecutive values of n,
        starting with n = 0.
        

    Url: https://projecteuler.net/problem=27
*/

using System;
using System.Linq;
using csharp.Utility;

namespace csharp.Level02
{
    public class Solution027 : SolutionBase
    {
        public override object Answer()
        {
            var quadratic = new Func<int, int, int, int>((n, a, b) => n*n + a*n + b);
            int maxN = 0, maxA = 0, maxB = 0;
            
            foreach (var b in ToolBox.PrimeSieve.PrimeRange(0,1000).Select(p=>(int)p))
            {
                for (int a = -b+2; a < 1000; a++)
                {
                    int n = 0;
                    while (true)
                    {
                        var p = quadratic(n, a, b);
                        if (p<0 || !ToolBox.PrimeSieve[p])
                            break;
                        n++;
                    }
                    if (n > maxN)
                    {
                        maxN = n;
                        maxA = a;
                        maxB = b;
                    }
                }
            }
            return maxA*maxB;
        }
    }
}

