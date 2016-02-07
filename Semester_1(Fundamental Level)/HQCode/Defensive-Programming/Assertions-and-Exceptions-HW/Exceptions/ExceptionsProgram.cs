namespace Exceptions_Homework
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Exceptions_Homework.Helpers;
    using Exceptions_Homework.Helpers.Exceptions;
    using Models;

    class ExceptionsProgram
    {
        static void Main()
        {
            try
            {
                var substr = CommonUtils.Subsequence("Hello!".ToCharArray(), 2, 3);
                Console.WriteLine(substr);

                var subarr = CommonUtils.Subsequence(new int[] {-1, 3, 2, 1}, 0, 2);
                Console.WriteLine(String.Join(" ", subarr));

                var allarr = CommonUtils.Subsequence(new int[] {-1, 3, 2, 1}, 0, 4);
                Console.WriteLine(String.Join(" ", allarr));

                var emptyarr = CommonUtils.Subsequence(new int[] {-1, 3, 2, 1}, 0, 0);
                Console.WriteLine(String.Join(" ", emptyarr));
            }
            catch (NegativeNumberException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }


            try
            {
                Console.WriteLine(CommonUtils.ExtractEnding("I love C#", 2));
                Console.WriteLine(CommonUtils.ExtractEnding("Nakov", 4));
                Console.WriteLine(CommonUtils.ExtractEnding("beer", 4));
                Console.WriteLine(CommonUtils.ExtractEnding("Hi", 100));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
           

            try
            {
                CommonUtils.CheckPrime(23);
                Console.WriteLine("23 is prime.");
            }
            catch (NotPrimeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                CommonUtils.CheckPrime(33);
                Console.WriteLine("33 is prime.");
            }
            catch (NotPrimeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            var peterExams = new List<Exam>()
            {
                new SimpleMathExam(2),
                new CSharpExam(55),
                new CSharpExam(100),
                new SimpleMathExam(1),
                new CSharpExam(0),
            };

            var peter = new Student("Peter", "Petrov", peterExams);
            try
            {
                var peterAverageResult = peter.CalcAverageExamResultInPercents();
                Console.WriteLine("Average results = {0:p0}", peterAverageResult);
            }
            catch (InvalidNameException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (EmptyCollectionException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidCommentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidGradeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidScoreException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
