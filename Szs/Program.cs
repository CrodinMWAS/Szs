namespace Szs
{
    using System.Data;
    using System.Threading.Channels;



    public static class StringExtensions
    {

        // 2. Feladatsor 2. Feladat
        public static bool IsValid(this string str)
        {
            Stack<char> stack = new Stack<char>();
            foreach (var item in str)
            {
                if (item == ')')
                {
                    stack.Push(item);
                }
                else if (item == '(')
                {
                    if (stack.Count != 0)
                    {
                        stack.Pop();
                    }
                }
            }

            return stack.Count != 0;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             1. Feladat
            Írj egy programot, amely egész számokat vár parancssori argumentumként, és ezek közül
            a középsőt a két szomszédja egész osztású hányadosának hatványára emeli. Az osztásnál a
            nagyobb szomszédot oszd el a kisebbik szomszéddal!
            Ha a felhasználó nem ad meg értékeket, vagy páros az argumentumszám, akkor a program
            írjon ki egy hibaüzenetet a standard hibakimenetre és lépjen ki 1-es hibakóddal!
            Feltételezheted, hogy a felhasználó egész számokat ad meg bemenetként.
            Példa: 7 5 2 esetén, a középső elem 5, a két szomszéd egész osztású hányadosa 7 / 2 = 3,
            az eredmény 53 = 125.
            1 2 3 4 5 6 7 esetén a középső elem 4, és a hatvány amire emelni kell 5 / 3 = 1, tehát az
            eredmény 4.
            Megjegyzés: A math.h library használatához a fordításnál szükséges a „-lm” kapcsoló
            */
            string[] rawNumbers = args;
            if (args.Length % 2 != 0)
            {
                Console.WriteLine(Math.Pow(Convert.ToInt32(rawNumbers[rawNumbers.Length / 2]), Math.Max(Convert.ToInt32(rawNumbers[(rawNumbers.Length / 2) - 1]), Convert.ToInt32(rawNumbers[(rawNumbers.Length / 2) + 1])) / Math.Min(Convert.ToInt32(rawNumbers[(rawNumbers.Length / 2) - 1]), Convert.ToInt32(rawNumbers[(rawNumbers.Length / 2) + 1]))));
            }
            else
            {
                Console.WriteLine("Please provide an odd number of numbers.");
            }

            /*2. Feladat
                Adott a szavak.txt szöveges állomány, melynek 500 sora van és soronként egy szót
                tartalmaz. Írj egy programot, amelyben feldolgozod a fájl tartalmát (ami nem
                módosítható!), a program írja ki a standard kimenetre, hogy hány olyan szó található a
                fájlban, amely több, mint négy szótagból áll. A fájl nem tartalmaz ékezetes karaktereket.
                Minden szó annyi szótagú, ahány magánhangzó van benne, az egy karakterből álló szavak
                egy szótagúak.
            */

            StreamReader streamReader = new("szavak.txt");
            int wordCounter = 0;
            int mostVowels = 0;
            char[] vowels = { 'a', 'e', 'i', 'u', 'o' };
            while (!streamReader.EndOfStream)
            {
                string word = streamReader.ReadLine();
                int vowelCounter = 0;
                foreach (var letter in word.ToLower())
                {
                    if (vowels.Contains(letter))
                    {
                        vowelCounter++;
                    }
                }

                if (vowelCounter > 4)
                {
                    wordCounter++;
                }

                if (vowelCounter > mostVowels)
                {
                    mostVowels = vowelCounter;
                }
            }
            Console.WriteLine($"A több, mint 4 szótagból álló szavak száma: {wordCounter}");
            Console.WriteLine($"A legnagyobb szótagszám: {mostVowels}");
            streamReader.Close();

            /*
             3. Feladat
            Írj egy programot, amelyben véletlenszerűen feltöltesz egy 6x6-os mátrixot az [55,155] 
            zárt intervallumból. A randomszámgenerátort a 33-as értékkel inicializáld! A program írja 
            ki a képernyőre a mátrixot, valamint a széleken elhelyezkedő elemek átlagát.
            Példa 3x3-es mátrix esetén
             */

            int[,] matrix = new int[6, 6];
            Random random = new Random(33);
            for (int i = 0; i != 6; i++)
            {
                for (int j = 0; j != 6; j++)
                {
                    matrix[i, j] = random.Next(55, 156);
                }
            }

            for (int i = 0; i != 6; i++)
            {
                for (int j = 0; j != 6; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }

            int sum = 0;
            int count = 0;
            for (int i = 0; i != 6; i++)
            {
                sum += matrix[i, 0];
                sum += matrix[i, 5];
                sum += matrix[0, i];
                sum += matrix[5, i];
                count += 4;
            }
            Console.WriteLine(sum / count);

            /*
             4. Feladat
            Egy digitális kép tárolásánál minden egyes képpont színét tároljuk. A képpontok színét az 
            RGB kód adja. Az RGB kód a vörös (R), zöld (G) és a kék (B) színösszetevő értékét 
            határozza meg. Ezen színösszetevők értéke 0 és 255 közötti egész szám lehet.

            A kep.txt fájlban egy 50×50 képpontos kép képpontjainak RGB kódjai vannak tárolva. A 
            fájlt nem módosíthatod! Az állomány a képet sorfolytonosan, a képpontok RGB kódját 
            pontosvesszővel elválasztva tartalmazza, minden képpontot egy újabb sorban.

            Írj egy programot, amelyben módosítsd a képet úgy, hogy ha a képpontok KÉK 
            színösszetevőinek értéke kisebb, mint 100, akkor hússzal növeld ezt az értéket! A 
            módosított kép képpontjainak színét írd ki a "kekitett.txt" nevű szövegfájlba a bemeneti 
            fájl formátumával egyezően! A képet sorfolytonosan tárold, minden képpontot új sorba, a 
            képpontok RGB kódját pontosvesszővel elválasztva írd ki!
            Ha a program sikeresen lefutott írj ki „#Kész!” üzenetet a standard kimenetre!
             */

            StreamReader sr = new("kep.txt");
            StreamWriter sw = new("kekitett.txt");
            while (!sr.EndOfStream)
            {
                //Console.WriteLine(sr.ReadLine());
                string[] line = sr.ReadLine().Split(";");
                int blue = Convert.ToInt32(line[2]);
                if (blue < 100)
                {
                    line[2] = Convert.ToString(blue + 20);
                }
                sw.WriteLine($"{line[0]};{line[1]};{line[2]}");
            }
            sr.Close();
            sw.Close();

            // 2.feladatlap 1.feladat

            Console.WriteLine("-------------------------------");

            StreamReader reader = new("input.txt");
            int counter = 0;
            while (!reader.EndOfStream)
            {
                char openBracket = '(';
                char closedBracket = ')';
                string line = reader.ReadLine();
                if (line[0] != closedBracket)
                {
                    Stack<char> stack = new Stack<char>();
                    foreach (var item in line)
                    {
                        if (item == openBracket)
                        {
                            stack.Push(item);
                        }
                        if (stack.Count != 0)
                        {
                            stack.Pop();
                        }
                    }

                    if (stack.Count == 0)
                    {
                        counter++;
                    }
                }
            }
            reader.Close();
            Console.WriteLine(counter);


            //2. Feladat
            Console.WriteLine("(())".IsValid());
            Console.WriteLine("))((".IsValid());

            //3. Feladat
        }
    }


}



