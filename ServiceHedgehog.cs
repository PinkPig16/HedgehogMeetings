using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hedgehog
{
    public class ServiceHedgehog
    {
        public int MinimumMeetings(int neededHedgehog, List<int> hedgehogPopulation)

        {
            //Получаем индексты двух других ёжей
            int firstHedgehog = (neededHedgehog + 1) % 3;
            int secondHedgehog = (neededHedgehog + 2) % 3;

            if (hedgehogPopulation[firstHedgehog] == 0 && hedgehogPopulation[secondHedgehog] == 0)
            {
                return 0;
            }else if(hedgehogPopulation[firstHedgehog] == hedgehogPopulation.Sum() || hedgehogPopulation[secondHedgehog] == hedgehogPopulation.Sum())
            {
                return -1;
            }

            //Если условие не будет выполнятся то невозможно будет привести двух других ёжей к одинаковому кол-ву
            //Что необходимо для приведения к одному цвету
            if ((hedgehogPopulation[firstHedgehog] - hedgehogPopulation[secondHedgehog]) % 3 == 0) 
            {
                int countOperation = 0;
                //Распределение элементов к среднему 
                while (Math.Abs(hedgehogPopulation[firstHedgehog] - hedgehogPopulation[secondHedgehog]) != 3)
                {

                    int minIndex = 2;

                    if (hedgehogPopulation[0] <= hedgehogPopulation[1] && hedgehogPopulation[0] <= hedgehogPopulation[2])
                    {
                        minIndex = 0;
                    }
                    else if (hedgehogPopulation[1] <= hedgehogPopulation[0] && hedgehogPopulation[1] <= hedgehogPopulation[2])
                    {
                        minIndex = 1;
                    }

                    Console.WriteLine($"{hedgehogPopulation[0]} {hedgehogPopulation[1]} {hedgehogPopulation[2]} \n");

                    //Встреча ёжиков
                    hedgehogPopulation[(minIndex + 1) % 3]--;
                    hedgehogPopulation[(minIndex + 2) % 3]--;
                    hedgehogPopulation[minIndex] += 2;

                    countOperation++;
                }

                var min = hedgehogPopulation[firstHedgehog] < hedgehogPopulation[secondHedgehog] ? firstHedgehog : secondHedgehog;

                Console.WriteLine($"{hedgehogPopulation[0]} {hedgehogPopulation[1]} {hedgehogPopulation[2]} \n");
                //Встреча ёжиков
                hedgehogPopulation[(min + 1) % 3]--;
                hedgehogPopulation[(min + 2) % 3]--;
                hedgehogPopulation[min] += 2;

                countOperation++;

                while (hedgehogPopulation[firstHedgehog] + hedgehogPopulation[secondHedgehog] != 0)
                {
                    Console.WriteLine($"{hedgehogPopulation[0]} {hedgehogPopulation[1]} {hedgehogPopulation[2]} \n");

                    //Встреча ёжиков
                    hedgehogPopulation[firstHedgehog]--;
                    hedgehogPopulation[secondHedgehog]--;
                    hedgehogPopulation[neededHedgehog]+=2;

                    countOperation++;
                }
                return countOperation;
            }

            return -1;
        }

    }
}