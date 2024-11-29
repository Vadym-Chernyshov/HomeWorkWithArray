namespace HomeWorkWithArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //1. Створити масив із 10 елементів типу int.
            //Присвоїти їм випадкові значення від -10 до 10,
            //використовуючи клас Random
            //(https://learn.microsoft.com/en-us/dotnet/api/system.random?view=net-8.0)
            //Вивести на екран елементи масиву з парним індексом.
            //(не парні значення, а саме парні індекси!!)

            //2.Визначити, чи вірно, що сума елементів масиву з пункту 1 є невід'ємне число.

            int[] randomArray = new int[10];
            int minValue = -10, maxValue = 10;
            Random random = new();

            int sum = 0; //сума елементів масиву(для 2-ої задачі)
            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = random.Next(minValue, maxValue + 1);

                //задача 1
                if (i % 2 == 0) Console.WriteLine(i + " індекс: " + randomArray[i] + " ");

                sum += randomArray[i];           
            }
            Console.WriteLine();
            string noNegativeSum = sum < 0 ? "Сума елементів масиву менше 0" : "Cума елементів масиву більша або дорівнює 0";
            Console.WriteLine(noNegativeSum);
            Console.WriteLine();

            //3. Створити та заповнити двовимірний масив розміру 9х9
            //з результатами таблиці множення (у першому рядку мають
            //бути записані добутки кожного з чисел від 1 до 9 на 1,
            //у другому – на 2, ..., в останньому – на 9). Тобто в 1
            //строчці будуть значення від 1 до 9, а у другому 2,4,6,.
            //...,18 і т.д.

            sbyte[,] multiplicationTable = new sbyte[9, 9]; //створення таблиці 9X9
            Console.WriteLine("Таблиця множення до 9");

            //https://learn.microsoft.com/en-us/dotnet/api/system.array.getlength?view=net-9.0
            //GetLength повертає кількість елементів в одному з зазаначенних вимірів
            for (sbyte i = 0; i < multiplicationTable.GetLength(0); i++)
            {
                for (sbyte j = 0; j < multiplicationTable.GetLength(1); j++)
                {
                    multiplicationTable[i, j] = (sbyte)((i + 1) * (j + 1));
                    Console.Write(multiplicationTable[i, j] + " "); //вивід для самоперевірки
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //4. Створити двовимірний масив 5х5. Заповнити його будь-якими числами.
            //Визначити та вивести на екран:
            //а) максимальний елемент масиву;
            //б) мінімальний елемент масиву;
            //в) координати мінімального елемента масиву.
            //г) координати максимального елемента масиву.

            int[,] randomArray5on5 = new int[5, 5];            
            Random randomForExNum4 = new();

            int maxValueInArray = 0;
            sbyte[] coordinatesMaxValueInArray = new sbyte[2]; //координата XY для більшого
            int minValueInArray = 0;
            sbyte[] coordinatesMinValueInArray = new sbyte[2]; //координата XY для меншого

            for (sbyte i = 0; i < randomArray5on5.GetLength(0); i++)
            {
                for (sbyte j = 0; j < randomArray5on5.GetLength(1); j++)
                {
                    randomArray5on5[i, j] = randomForExNum4.Next(-1000, 1000); //діапазон взятий для наглядності
                                  
                    if(i == 0 && j == 0) //при першій ітераціїї присвоюємо наші данні для подальшої обробки
                    {
                        //значення
                        maxValueInArray = randomArray5on5[i, j];
                        //координати
                        coordinatesMaxValueInArray[0] = i;
                        coordinatesMaxValueInArray [1] = j;

                        //значення
                        minValueInArray = randomArray5on5[i, j];
                        //координати
                        coordinatesMinValueInArray[0] = i;
                        coordinatesMinValueInArray[1] = j;
                    }
                    else //міняємо значення мін та макс якщо виконуються умови
                    {
                        if (randomArray5on5[i, j] > maxValueInArray)
                        {
                            maxValueInArray = randomArray5on5[i, j];
                            coordinatesMaxValueInArray[0] = i;
                            coordinatesMaxValueInArray [1] = j;
                        }
                        if (randomArray5on5[i, j] < minValueInArray)
                        {
                            minValueInArray = randomArray5on5[i, j];
                            coordinatesMinValueInArray[0] = i;
                            coordinatesMinValueInArray [1] = j;
                        }
                    }
                }                
            }

            Console.WriteLine($"Максимальний елемент масиву: {maxValueInArray}. " +
                              $"Його координати X:{coordinatesMaxValueInArray[0]} Y: {coordinatesMaxValueInArray[1]}");
            Console.WriteLine($"Мінімальний елемент масиву: {minValueInArray}. " +
                              $"Його координати X:{coordinatesMinValueInArray[0]} Y: {coordinatesMinValueInArray[1]}");
            Console.WriteLine();

            //5. За допомогою enum створити програму, що буде запитувати у
            //користувача кількість днів, а потім рахувати який буде день
            //через введену кількість, якщо рахувати від понеділка і
            //виводити результат.

            Console.WriteLine("Введіть кількість днів");
            int countOfDay = int.Parse(Console.ReadLine()); //будемо вважати що ввід правильний
            int convertToEnum = countOfDay < 7 ? countOfDay : countOfDay % 7;

            //пошарився в документації, є така зручна штука як Enum.GetName
            //https://learn.microsoft.com/en-us/dotnet/api/system.enum.getname?view=net-9.0
            Console.WriteLine("Твій день тижня: " + Enum.GetName(typeof(DayOfWeek), convertToEnum));
        }
    }
    enum DayOfWeek
    {
        Monday, Tuesday, Wednesday, Thursday, Friday, Saturaday, Sunday
    }
}
