namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Poniendo en marcha el metodo ManipulateArray");
            Console.WriteLine("_________________________________________________________________");
            ManipulateArray();
            Console.WriteLine("_________________________________________________________________");
            Console.WriteLine("Poniendo en marcha el metodo HashMap");
            Console.WriteLine("_________________________________________________________________");
            HashMap();
            Console.WriteLine("_________________________________________________________________");
            Console.WriteLine("Poniendo en marcha el metodo GenerarId");
            Console.WriteLine("_________________________________________________________________");
            string id = generarId();
            Console.WriteLine($"El resultado del ID Pattern es:{id}");
        }

        static void ManipulateArray()
        {
            object[] array = new object[] { "a", 10, "b", "hola", 122, 15 };

            // Obteniendo una matriz que lleva solamente las letras
            var letters = Array.FindAll(array, x => x is string);
            Console.WriteLine("Las letras:");
            foreach (var letter in letters)
            {
                Console.WriteLine(letter);
            }

            // Obteniendo una matriz que lleva solamente los numeros
            var numbers = Array.FindAll(array, x => x is int);
            Console.WriteLine("Los numeros:");
    
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            // Obteniendo el valor más alto de la matriz
            int max = int.MinValue;
            foreach (var item in array)
            {
                if (item is int i && i > max)
                {
                    max = i;
                }
            }
            Console.WriteLine("Numero de valor más alto:");
            Console.WriteLine(max);
        }

        static void HashMap()
        {

            double a, b;
            string operation;
            
            Dictionary<string, Func<double, double, double>> operations = new Dictionary<string, Func<double, double, double>>();

            // Suma
            operations.Add("+", (a, b) => a + b);

            // Sustracción
            operations.Add("-", (a, b) => a - b);

            // Multiplicación
            operations.Add("*", (a, b) => a * b);

            // División
            operations.Add("/", (a, b) => b == 0 ? throw new ArgumentException("El divisor no puede ser cero, vale?") : a / b);

            Console.WriteLine("Escriba el primeiro numero, por favor:");
            a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Escriba el segundo numero, por favor:");
            b = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Elija la operación que deseas, por favor:");
            operation = Console.ReadLine();

            double result = operations[operation](a, b);
            Console.WriteLine($"El resultado de la operación es: {a} {operation} {b} = {result}");
        }

        static string randomString(Random rand, int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rand.Next(s.Length)]).ToArray());

        }
        static string generarId()
        {
            Random rand = new Random();
            string x = randomString(rand, 4);
            string a = randomString(rand, 4);
            string b = randomString(rand, 4);
            string c = randomString(rand, 4);
            return $"{x}-{a}-{b}-{c}";

        }

      
    }

}
