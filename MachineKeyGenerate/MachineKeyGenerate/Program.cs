using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MachineKeyGenerate
{
    class Program
    {
        static void Main(string[] args)
        {
            var txtDecryptionKey = CreateMachineKey(48);
            var txtValidationKey = CreateMachineKey(128);

            Console.WriteLine("DecryptionKey: {0}\nValidationKe: {1}", txtDecryptionKey, txtValidationKey);
            Console.ReadKey();
        }

        //Рубрика спизжено с https://professorweb.ru/my/ASP_NET/base/level4/4_3.php
        public static string CreateMachineKey(int length)
        {
            // Создать массив байтов
            byte[] random = new byte[length / 2];

            // Создать криптографически устойчивый генератор случайных чисел
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            // Заполнить массив байтов случайными байтами
            rng.GetBytes(random);

            // Создать StringBuilder для размещения результата после
            // его преобразования в шестнадцатеричный формат
            System.Text.StringBuilder machineKey = new System.Text.StringBuilder(length);

            // Проход в цикле по массиву случайных байтов с присоединением
            // каждого значения к StringBuilder
            for (int i = 0; i < random.Length; i++)
                machineKey.Append(String.Format("{0:X2}", random[i]));

            return machineKey.ToString();
        }
    }
}
